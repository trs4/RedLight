namespace RedLight;

/// <summary>Параметр запроса</summary>
public sealed class QueryParameter
{
    internal QueryParameter(string name, object value, ColumnType type, bool nullable = true, int maxSize = -1)
    {
        Name = name;
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
