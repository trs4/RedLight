using RedLight.Internal;

namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseConnection : DatabaseConnection
{
    public SqlServerDatabaseConnection(DatabaseConnectionParameters parameters) : base(parameters) { }

    public override DatabaseProvider Provider => DatabaseProvider.SqlServer;

    public override Naming Naming => DboSquareBracketsNaming.Instance;

    internal override ParameterNaming ParameterNaming => AtParameterNaming.Instance;

    internal override ColumnTypes ColumnTypes => SqlServerColumnTypes.Instance;

    internal override ExplainQuery CreateExplainQuery(Query owner) => new SqlServerExplainQuery(owner);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias) => new SqlServerJoinQuery(owner, tableName, alias);

    internal override Executor CreateExecutor(DatabaseConnectionParameters parameters) => new SqlServerExecutor(parameters);

    protected override DatabaseFunctions CreateFunctions() => new SqlServerDatabaseFunctions();

    protected override DatabaseDetails CreateDetails() => new SqlServerDatabaseDetails(this);

    protected override ValueEscape CreateEscaping() => new SqlServerValueEscape(this);

    protected override DatabaseSchemaQueries CreateSchema() => new SqlServerDatabaseSchemaQueries(this);

    protected override DatabaseSelectQueries CreateSelect() => new SqlServerDatabaseSelectQueries(this);

    protected override DatabaseInsertQueries CreateInsert() => new SqlServerDatabaseInsertQueries(this);

    protected override DatabaseUpdateQueries CreateUpdate() => new SqlServerDatabaseUpdateQueries(this);

    protected override DatabaseDeleteQueries CreateDelete() => new SqlServerDatabaseDeleteQueries(this);
}
