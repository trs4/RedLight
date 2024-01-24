namespace RedLight;

/// <summary>Параметр запроса</summary>
public abstract class QueryParameter
{
    protected QueryParameter(string name, object value)
    {
        Name = name;
        Value = value;
    }

    /// <summary>Имя</summary>
    public string Name { get; }

    /// <summary>Тип</summary>
    public abstract ColumnType Type { get; }

    /// <summary>Поддерживает пустые значения</summary>
    public abstract bool Nullable { get; }

    /// <summary>Максимально допустимый размер значения</summary>
    public int MaxSize { get; set; } = -1;

    /// <summary>Значение</summary>
    public object Value { get; }

    public override string ToString() => $"{Name}: {Value ?? "NULL"}";
}
