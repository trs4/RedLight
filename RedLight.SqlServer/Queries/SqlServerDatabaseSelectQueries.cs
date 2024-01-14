namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseSelectQueries : DatabaseSelectQueries
{
    public SqlServerDatabaseSelectQueries(DatabaseConnection connection) : base(connection) { }

    protected override SelectQuery<TResult> Create<TResult>(string tableName, string alias) => new SqlServerSelectQuery<TResult>(Connection, tableName, alias);

    protected override ConstSelectQuery CreateConst(string tableName) => new SqlServerConstSelectQuery(Connection, tableName);
}
