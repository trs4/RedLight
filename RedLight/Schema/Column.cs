using System;

namespace RedLight;

/// <summary>Описание поля таблицы</summary>
public sealed class Column
{
    public Column(string name, ColumnType type,
        bool nullable = false, int size = 0, int precision = 0,
        string defaultValue = null, string defaultConstraint = null)
    {
        Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
        Type = type;
        Nullable = nullable;
        Size = size;
        Precision = precision;
        DefaultValue = defaultValue;
        DefaultConstraint = defaultConstraint;
    }

    /// <summary>Имя поля</summary>
    public string Name { get; }

    /// <summary>Тип поля</summary>
    public ColumnType Type { get; }

    /// <summary>Типу значения можно задать пустое значение</summary>
    public bool Nullable { get; }

    /// <summary>Размер поля</summary>
    public int Size { get; }

    /// <summary>Точность</summary>
    public int Precision { get; }

    /// <summary>Значение по-умолчанию</summary>
    public string DefaultValue { get; }

    /// <summary>Имя ограничения по-умолчанию</summary>
    public string DefaultConstraint { get; }

    /// <summary>Описание таблицы</summary>
    public Table Table { get; internal set; }

    public override string ToString() => Name;
}
