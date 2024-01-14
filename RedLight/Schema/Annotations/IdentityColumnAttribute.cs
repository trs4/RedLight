using System;

namespace RedLight;

/// <summary>Описание поля-идентификатора таблицы</summary>
[AttributeUsage(AttributeTargets.Field)]
public sealed class IdentityColumnAttribute : Attribute
{
    public IdentityColumnAttribute(string name, ColumnType type, long increment = 1, long minValue = 1, string sequenceName = null)
        : this(type, increment, minValue, sequenceName)
        => Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;

    public IdentityColumnAttribute(ColumnType type, long increment = 1, long minValue = 1, string sequenceName = null)
    {
        Type = type;
        Increment = increment;
        MinValue = minValue;
        SequenceName = sequenceName;
    }

    public IdentityColumnAttribute(long increment = 1, long minValue = 1, string sequenceName = null)
        : this(ColumnType.Integer, increment, minValue, sequenceName) { }

    /// <summary>Имя поля</summary>
    public string Name { get; }

    /// <summary>Имя последовательности</summary>
    public string SequenceName { get; }

    /// <summary>Тип колонки</summary>
    public ColumnType Type { get; }

    /// <summary>Интервал между значениями</summary>
    public long Increment { get; }

    /// <summary>Минимальное значение</summary>
    public long MinValue { get; }

    internal IdentityColumnAttribute ForTable(Column column)
        => Name is null ? new IdentityColumnAttribute(column.Name, Type, Increment, MinValue, SequenceName) : this;
}
