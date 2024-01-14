using System;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса управления данными таблицы</summary>
public abstract class WhereQuery : RunQuery
{
    protected TermBlock _where;

    protected WhereQuery(DatabaseConnection connection, string tableName, string alias)
        : base(connection)
    {
        TableName = String.IsNullOrWhiteSpace(tableName) ? throw new ArgumentNullException(nameof(tableName)) : tableName;
        Alias = alias;
    }

    /// <summary>Имя таблицы</summary>
    public string TableName { get; }

    /// <summary>Псевдоним таблицы</summary>
    public string Alias { get; }

    /// <summary>Список подсказок запроса</summary>
    public Hints Hints { get; set; }

    /// <summary>Блок условий для выборки данных</summary>
    public TermBlock Where => _where ??= new(this);

    #region Internal

    /// <summary>Указывает что есть хотя бы одно условие в блоке условий для выборки данных</summary>
    protected bool ExistTermsInWhereBlock => _where?.Count > 0;

    [MethodImpl(Flags.HotPath)]
    protected void BuildWhereBlock(StringBuilder builder, QueryOptions options)
    {
        if (_where?.Count > 0)
            _where.BuildSql(builder, options, Consts.Where);
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildWhereBlock(StringBuilder builder, QueryOptions options, TermBlock additionalBlockTerm)
    {
        if (_where?.Count > 0 || additionalBlockTerm != null)
            Where.BuildSql(builder, options, Consts.Where, additionalBlockTerm);
    }

    [MethodImpl(Flags.HotPath)]
    protected TermBlock CreateCheckExistenceTerm(string joinColumn)
    {
        string rawColumn = Naming.GetRawNameWithAlias(Alias, joinColumn);
        var checkExistenceTerm = new TermBlock(this);
        checkExistenceTerm.WithRawTerm(rawColumn, Op.Is, Consts.Null);
        return checkExistenceTerm;
    }

    [MethodImpl(Flags.HotPath)]
    protected JoinQuery CreateCheckExistenceJoin()
    {
        var checkExistenceJoin = Connection.CreateJoin(this, TableName, Alias);
        checkExistenceJoin.Type = JoinQueryMode.LeftOuter;
        return checkExistenceJoin;
    }

    #endregion
}
