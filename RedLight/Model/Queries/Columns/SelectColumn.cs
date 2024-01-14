using System;
using System.Text;

namespace RedLight;

/// <summary>Колонка выборки данных</summary>
public sealed class SelectColumn : QueryColumn
{
    internal SelectColumn(string tableName, string name, string alias)
        : base(alias)
    {
        TableName = tableName;
        Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;
    }

    /// <summary>Имя таблицы</summary>
    public string TableName { get; }

    /// <summary>Имя поля</summary>
    public string Name { get; }

    internal override void BuildSql(StringBuilder builder, bool withAlias = false)
    {
        if (TableName != null)
            builder.Append(TableName).Append('.');

        builder.Append(Name);
        base.BuildSql(builder, withAlias);
    }

    public override string ToString() => Name;
}
