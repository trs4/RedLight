using System;
using System.Text;

namespace RedLight;

/// <summary>Объединение с другой таблицей</summary>
public abstract class JoinQuery : Query
{
    protected JoinQuery(Query owner, string tableName, string alias)
        : base(owner?.Connection, owner)
    {
        TableName = String.IsNullOrWhiteSpace(tableName) ? throw new ArgumentNullException(nameof(tableName)) : tableName;
        Alias = alias;
        On = new TermBlock(this);
    }

    /// <summary>Имя таблицы, с которой осуществляется объединение</summary>
    public string TableName { get; }

    /// <summary>Псевдоним таблицы, с которой осуществляется объединение</summary>
    public string Alias { get; }

    /// <summary>Блок условий для объединения</summary>
    public TermBlock On { get; }

    /// <summary>Тип объединение</summary>
    public JoinQueryMode Type { get; set; } = JoinQueryMode.Inner;

    /// <summary>Список подсказок запроса</summary>
    public Hints Hints { get; set; } = Hints.NoLock;

    #region Internal

    internal abstract void BuildJoinSql(StringBuilder builder, QueryOptions options, TermBlock additionalBlockTerm = null);

    internal sealed override void BuildSql(StringBuilder builder, QueryOptions options) => BuildJoinSql(builder, options);

    /// <summary>Название типа пересечения</summary>
    protected virtual string GetTypeString() => Type switch
    {
        JoinQueryMode.Simple => "JOIN ",
        JoinQueryMode.LeftOuter => "LEFT OUTER JOIN ",
        JoinQueryMode.CrossApply => "CROSS APPLY ",
        JoinQueryMode.OuterApply => "OUTER APPLY ",
        _ => "INNER JOIN ",
    };

    #endregion
}
