using System;
using System.Text;

namespace RedLight;

/// <summary>Колонка запроса</summary>
public abstract class QueryColumn
{
    protected QueryColumn(string alias)
        => Alias = alias;

    /// <summary>Псевдоним</summary>
    public string Alias { get; }

    internal virtual void BuildSql(StringBuilder builder, bool withAlias = false)
    {
        if (withAlias && !String.IsNullOrEmpty(Alias))
            builder.Append(" AS ").Append(Alias);
    }

}
