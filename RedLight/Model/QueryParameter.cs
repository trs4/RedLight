using System;

namespace RedLight;

/// <summary>Параметр запроса</summary>
public sealed class QueryParameter
{
    public QueryParameter(string name, object value, ColumnType type, bool nullable = true, int maxSize = -1)
    {
        Name = String.IsNullOrEmpty(name) || name.Contains(' ') ? throw new ArgumentNullException(nameof(name)) : name;
        Type = type;
        Nullable = nullable;
        MaxSize = maxSize;
        Value = value;
    }

    /// <summary>Имя</summary>
    public string Name { get; }

    /// <summary>Тип</summary>
    public ColumnType Type { get; }

    /// <summary>Поддерживает пустые значения</summary>
    public bool Nullable { get; }

    /// <summary>Максимально допустимый размер значения</summary>
    public int MaxSize { get; }

    /// <summary>Значение</summary>
    public object Value { get; }

    public override string ToString() => $"{Name}: {Value ?? "NULL"}";
}
