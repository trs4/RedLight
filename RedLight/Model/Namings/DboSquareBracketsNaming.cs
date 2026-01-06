using System;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedLight;

/// <summary>Именование таблиц и полей в запросах с квадратными скобками</summary>
internal sealed class DboSquareBracketsNaming : Naming
{
    private DboSquareBracketsNaming() { }

    public static Naming Instance { get; } = new DboSquareBracketsNaming();

    private readonly static char[] _bracketSymbols = ['[', ']', '"'];
    private readonly ConcurrentDictionary<string, string> _nameWithSchemaCache = new(4, 1024);
    private readonly ConcurrentDictionary<string, string> _nameCache = new(4, 1024);
    private readonly ConcurrentDictionary<string, string> _clearNameCache = new(4, 128);

    #region Name with schema

    public override string GetNameWithSchema(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return _nameWithSchemaCache.GetOrAdd(name, AddNameWithSchema);
    }

    private static string AddNameWithSchema(string name)
    {
        if (name.Length == 0)
            throw new ArgumentException("Empty name");

        if (name[0] == '@') // temp variable
            return name;

        if (name.IndexOfAny(_bracketSymbols) == -1)
            return $"dbo.[{name}]";

        int index;

        if (name[^1] == ']') // [] brackets
        {
            index = name.LastIndexOf('[');

            if (index == -1)
                throw new InvalidOperationException(name);

            name = name.Substring(index + 1, name.Length - index - 2);
            return $"dbo.[{name}]";
        }

        // "" brackets
        if (name[^1] != '"') // Последний символ
            throw new InvalidOperationException(name);

        index = -1;

        for (int i = name.Length - 2; i >= 0; i--)
        {
            if (name[i] == '"')
            {
                index = i;
                break;
            }
        }

        if (index == -1)
            throw new InvalidOperationException(name);

        name = name.Substring(index + 1, name.Length - index - 2);
        return $"dbo.[{name}]";
    }

    public override string GetNameWithSchema<TEnum>(TEnum name) => EnumNamesWithSchema<TEnum>.Get(name);

    public override string GetNameWithSchema<TEnum>() => EnumNameWithSchema<TEnum>.Name;

    private static class EnumNamesWithSchema<T> where T : Enum
    {
        private static readonly FrozenDictionary<T, string> _map;

        static EnumNamesWithSchema()
        {
            var allValues = Enum.GetValues(typeof(T));
            var map = new Dictionary<T, string>(allValues.Length);

            foreach (var value in allValues.OfType<T>())
                map[value] = $"dbo.[{value}]";

            _map = map.ToFrozenDictionary();
        }

        public static string Get(T name) => _map[name];
    }

    private static class EnumNameWithSchema<T> where T : Enum
    {
        public static readonly string Name = $"dbo.[{typeof(T).Name}]";
    }

    #endregion
    #region Name

    public override string GetName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return _nameCache.GetOrAdd(name, AddName);
    }

    private static string AddName(string name)
    {
        int index = name.IndexOf('.');

        if (index > -1)
            name = name.Substring(index + 1);

        if (name.Length == 0)
            throw new ArgumentException("Empty name");

        if (name.IndexOfAny(_bracketSymbols) == -1)
            return $"[{name}]";

        if (name[0] == '"') // "" brackets
        {
            if (name[^1] != '"') // Крайние символы
                throw new InvalidOperationException(name);

            name = name.Substring(1, name.Length - 2);
            return $"[{name}]";
        }

        // "" brackets
        if (name[0] != '"' || name[^1] != '"') // Крайние символы
            throw new InvalidOperationException(name);

        return name;
    }

    public override string GetName<TEnum>(TEnum name) => EnumNames<TEnum>.Get(name);

    public override string GetName<TEnum>() => EnumName<TEnum>.Name;

    private static class EnumNames<T> where T : Enum
    {
        private static readonly FrozenDictionary<T, string> _map;

        static EnumNames()
        {
            var allValues = Enum.GetValues(typeof(T));
            var map = new Dictionary<T, string>(allValues.Length);

            foreach (var value in allValues.OfType<T>())
                map[value] = $"[{value}]";

            _map = map.ToFrozenDictionary();
        }

        public static string Get(T name) => _map[name];
    }

    private static class EnumName<T> where T : Enum
    {
        public static readonly string Name = $"[{typeof(T).Name}]";
    }

    #endregion
    #region Clear name

    public override string GetClearName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return _clearNameCache.GetOrAdd(name, AddClearName);
    }

    private static string AddClearName(string name)
    {
        if (name.Length == 0)
            throw new ArgumentException("Empty name");

        if (name.IndexOfAny(_bracketSymbols) == -1)
            return name;

        if (name[0] == '[') // [] brackets
        {
            if (name[^1] != ']') // Крайние символы
                throw new InvalidOperationException(name);

            return name.Substring(1, name.Length - 2);
        }

        // "" brackets
        if (name[0] != '"' || name[^1] != '"') // Крайние символы
            throw new InvalidOperationException(name);

        return name.Substring(1, name.Length - 2);
    }

    #endregion
    #region Internal

    internal override string StrictEscapedTrim(string name)
    {
        if (name.Contains('-'))
            name = name.Replace("-", "_");

        int startIndex = name.LastIndexOf('[');

        if (startIndex == -1)
            startIndex = 0;

        int finishIndex = name.LastIndexOf(']');

        if (startIndex == 0 && finishIndex == -1)
            return name;

        if (finishIndex == -1)
            finishIndex = name.Length - 1;

        return name.Substring(startIndex + 1, finishIndex - startIndex - 1);
    }

    internal override void StrictEscapedTrim(StringBuilder builder, string name)
    {
        if (name.Contains('-'))
            name = name.Replace("-", "_");

        int startIndex = name.LastIndexOf('[');

        if (startIndex == -1)
            startIndex = 0;

        int finishIndex = name.LastIndexOf(']');

        if (startIndex == 0 && finishIndex == -1)
        {
            builder.Append(name);
            return;
        }

        if (finishIndex == -1)
            finishIndex = name.Length - 1;

        builder.Append(name, startIndex + 1, finishIndex - startIndex - 1);
    }

    internal override void ClearCache()
    {
        if (_nameCache.Count >= MaxItemsInCache)
            _nameCache.Clear();

        if (_nameWithSchemaCache.Count >= MaxItemsInCache)
            _nameWithSchemaCache.Clear();

        if (_clearNameCache.Count >= MaxItemsInCache)
            _clearNameCache.Clear();
    }

    #endregion
}