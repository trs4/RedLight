using System;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Именование таблиц и полей в запросах</summary>
public abstract class Naming
{
    #region Name with schema

    /// <summary>Получить экранированное имя со схемой данных</summary>
    public abstract string GetNameWithSchema(string name);

    /// <summary>Получить экранированное имя со схемой данных</summary>
    public abstract string GetNameWithSchema<TEnum>(TEnum name) where TEnum : Enum;

    /// <summary>Получить экранированное имя со схемой данных</summary>
    public abstract string GetNameWithSchema<TEnum>() where TEnum : Enum;

    #endregion
    #region Name

    /// <summary>Получить экранированное имя</summary>
    public abstract string GetName(string name);

    /// <summary>Получить экранированное имя</summary>
    public abstract string GetName<TEnum>(TEnum name) where TEnum : Enum;

    /// <summary>Получить экранированное имя</summary>
    public abstract string GetName<TEnum>() where TEnum : Enum;

    #endregion
    #region Clear name

    /// <summary>Получить исходное имя</summary>
    public abstract string GetClearName(string name);

    #endregion
    #region Internal

    protected const int MaxItemsInCache = 10_000;

    internal abstract string StrictEscapedTrim(string name);

    internal abstract void StrictEscapedTrim(StringBuilder builder, string name);

    internal abstract void ClearCache();

    #endregion
    #region Name with schema and alias

    [MethodImpl(Flags.HotPath)]
    internal void BuildNameWithSchemaAndAlias(StringBuilder builder, string name, string alias)
        => builder.Append(GetNameWithSchema(name)).Append(' ').Append(GetName(alias));

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithSchemaAndAlias(string name, string alias)
        => $"{GetNameWithSchema(name)} {GetName(alias)}";

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithSchemaAndAlias<TEnum1, TEnum2>(TEnum1 name, TEnum2 alias)
        where TEnum1 : Enum
        where TEnum2 : Enum
        => $"{GetNameWithSchema(name)} {GetName(alias)}";

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithSchemaAndAlias<TEnum1>(TEnum1 name, string alias)
        where TEnum1 : Enum
        => $"{GetNameWithSchema(name)} {GetName(alias)}";

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithSchemaAndAlias<TEnum2>(string name, TEnum2 alias)
        where TEnum2 : Enum
        => $"{GetNameWithSchema(name)} {GetName(alias)}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithSchemaAndAlias(string name, string alias)
        => $"{name} {alias}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithSchemaAndAlias<TEnum1, TEnum2>(TEnum1 name, TEnum2 alias)
        where TEnum1 : Enum
        where TEnum2 : Enum
        => $"{name} {alias}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithSchemaAndAlias<TEnum1>(TEnum1 name, string alias)
        where TEnum1 : Enum
        => $"{name} {alias}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithSchemaAndAlias<TEnum2>(string name, TEnum2 alias)
        where TEnum2 : Enum
        => $"{name} {alias}";

    #endregion
    #region Name with alias

    [MethodImpl(Flags.HotPath)]
    internal void BuildNameWithAlias(StringBuilder builder, string alias, string name)
        => builder.Append(GetName(alias)).Append('.').Append(GetName(name));

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithAlias(string alias, string name)
        => $"{GetName(alias)}.{GetName(name)}";

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithAlias<TEnum1, TEnum2>(TEnum1 alias, TEnum2 name)
        where TEnum1 : Enum
        where TEnum2 : Enum
        => $"{GetName(alias)}.{GetName(name)}";

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithAlias<TEnum1>(TEnum1 alias, string name)
        where TEnum1 : Enum
        => $"{GetName(alias)}.{GetName(name)}";

    [MethodImpl(Flags.HotPath)]
    internal string GetNameWithAlias<TEnum2>(string alias, TEnum2 name)
        where TEnum2 : Enum
        => $"{GetName(alias)}.{GetName(name)}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithAlias(string alias, string name)
        => $"{alias}.{name}";

    [MethodImpl(Flags.HotPath)]
    internal static void BuildRawNameWithAlias(StringBuilder builder, string alias, string name)
        => builder.Append(alias).Append('.').Append(name);

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithAlias<TEnum1, TEnum2>(TEnum1 alias, TEnum2 name)
        where TEnum1 : Enum
        where TEnum2 : Enum
        => $"{alias}.{name}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithAlias<TEnum1>(TEnum1 alias, string name)
        where TEnum1 : Enum
        => $"{alias}.{name}";

    [MethodImpl(Flags.HotPath)]
    internal static string GetRawNameWithAlias<TEnum2>(string alias, TEnum2 name)
        where TEnum2 : Enum
        => $"{alias}.{name}";

    #endregion
}
