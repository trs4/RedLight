using System;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Изменение колонки</summary>
public abstract class ModifyColumn
{
    protected ModifyColumn(SchemaQuery query, string name, ColumnType type, bool nullable,
        int size, int precision, string defaultValue, string defaultConstraint)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Query = query;
        Name = name;
        Type = type;
        Nullable = nullable;
        Size = size;
        Precision = precision;
        DefaultValue = defaultValue;
        DefaultConstraint = defaultConstraint;
    }

    /// <summary>Запрос изменения таблицы</summary>
    public SchemaQuery Query { get; }

    /// <summary>Имя поля</summary>
    public string Name { get; }

    /// <summary>Тип колонки</summary>
    public ColumnType Type { get; }

    /// <summary>Типу значения можно задать пустое значение</summary>
    public bool Nullable { get; }

    /// <summary>Размер поля</summary>
    public int Size { get; }

    /// <summary>Точность</summary>
    public int Precision { get; }

    /// <summary>Значение по умолчанию</summary>
    public string DefaultValue { get; }

    /// <summary>Ограничение</summary>
    public string DefaultConstraint { get; }

    internal abstract void BuildSql(StringBuilder builder);

    protected void AppendDefaultConstraintName(StringBuilder builder)
    {
        var naming = Query.Connection.Naming;
        builder.Append("DF_").AppendStrictEscapedTrim(naming, Query.TableName).Append('_').AppendStrictEscapedTrim(naming, Name);
    }

    public override string ToString() => Name;
}
