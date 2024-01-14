using System;
using System.Text;

namespace RedLight;

/// <summary>Колонка-идентификатор</summary>
public abstract class IdentityColumn
{
    protected IdentityColumn(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;
        SequenceName = sequenceName;
        Type = type;
        Increment = increment;
        MinValue = minValue;
        MaxValue = maxValue;
    }

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

    /// <summary>Максимальное значение</summary>
    public long MaxValue { get; }

    internal abstract void BuildSql(StringBuilder builder);

    public override string ToString() => Name;
}
