using System;
using System.Text;

namespace RedLight;

/// <summary>Колонка без экранирования</summary>
public sealed class RawColumn : QueryColumn
{
    internal RawColumn(string name, string alias)
        : base(alias)
        => Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;

    /// <summary>Имя поля</summary>
    public string Name { get; }

    internal override void BuildSql(StringBuilder builder, bool withAlias = false)
    {
        builder.Append(Name);
        base.BuildSql(builder, withAlias);
    }

    public override string ToString() => Name;
}
