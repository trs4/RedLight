using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseConnection : DatabaseConnection
{
    public SQLiteDatabaseConnection(DatabaseConnectionParameters parameters) : base(parameters) { }

    public override DatabaseProvider Provider => DatabaseProvider.SQLite;

    public override Naming Naming => SquareBracketsNaming.Instance;

    internal override ParameterNaming ParameterNaming => AtParameterNaming.Instance;

    internal override ColumnTypes ColumnTypes => SQLiteColumnTypes.Instance;

    internal override ExplainQuery CreateExplainQuery(Query owner) => new SQLiteExplainQuery(owner);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias) => new SQLiteJoinQuery(owner, tableName, alias);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias, ConstSelectQuery values)
        => new SQLiteJoinQuery(owner, tableName, alias, values);

    internal override Executor CreateExecutor(DatabaseConnectionParameters parameters) => new SQLiteExecutor(parameters);

    protected override DatabaseFunctions CreateFunctions() => new SQLiteDatabaseFunctions();

    protected override DatabaseDetails CreateDetails() => new SQLiteDatabaseDetails(this);

    protected override ValueEscape CreateEscaping() => new SQLiteValueEscape(this);

    protected override DatabaseSchemaQueries CreateSchema() => new SQLiteDatabaseSchemaQueries(this);

    protected override DatabaseSelectQueries CreateSelect() => new SQLiteDatabaseSelectQueries(this);

    protected override DatabaseInsertQueries CreateInsert() => new SQLiteDatabaseInsertQueries(this);

    protected override DatabaseUpdateQueries CreateUpdate() => new SQLiteDatabaseUpdateQueries(this);

    protected override DatabaseDeleteQueries CreateDelete() => new SQLiteDatabaseDeleteQueries(this);
}
