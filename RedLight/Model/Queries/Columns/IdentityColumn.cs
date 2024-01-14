using System;
using System.Text;

namespace RedLight;

/// <summary>Колонка-идентификатор</summary>
public abstract class IdentityColumn
{
    protected IdentityColumn(string name, string sequenceName, ColumnType type, long increment, long minValue)
    {
        Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
        SequenceName = sequenceName;
        Type = type;
        Increment = increment;
        MinValue = minValue;
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

    internal abstract void BuildSql(StringBuilder builder);

    public override string ToString() => Name;
}
