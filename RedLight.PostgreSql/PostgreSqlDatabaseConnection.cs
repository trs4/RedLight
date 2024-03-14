using RedLight.Internal;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseConnection : DatabaseConnection
{
    public PostgreSqlDatabaseConnection(DatabaseConnectionParameters parameters) : base(parameters) { }

    public override DatabaseProvider Provider => DatabaseProvider.PostgreSql;

    public override Naming Naming => DboQuotesBracketsNaming.Instance;

    internal override ParameterNaming ParameterNaming => AtParameterNaming.Instance;

    internal override ColumnTypes ColumnTypes => PostgreSqlColumnTypes.Instance;

    internal override ExplainQuery CreateExplainQuery(Query owner) => new PostgreSqlExplainQuery(owner);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias) => new PostgreSqlJoinQuery(owner, tableName, alias);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias, ConstSelectQuery values)
        => new PostgreSqlJoinQuery(owner, tableName, alias, values);

    internal override Executor CreateExecutor(DatabaseConnectionParameters parameters) => new PostgreSqlExecutor(parameters);

    protected override DatabaseFunctions CreateFunctions() => new PostgreSqlDatabaseFunctions();

    protected override DatabaseDetails CreateDetails() => new PostgreSqlDatabaseDetails(this);

    protected override ValueEscape CreateEscaping() => new PostgreSqlValueEscape(this);

    protected override DatabaseSchemaQueries CreateSchema() => new PostgreSqlDatabaseSchemaQueries(this);

    protected override DatabaseSelectQueries CreateSelect() => new PostgreSqlDatabaseSelectQueries(this);

    protected override DatabaseInsertQueries CreateInsert() => new PostgreSqlDatabaseInsertQueries(this);

    protected override DatabaseUpdateQueries CreateUpdate() => new PostgreSqlDatabaseUpdateQueries(this);

    protected override DatabaseDeleteQueries CreateDelete() => new PostgreSqlDatabaseDeleteQueries(this);
}
