namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseSelectQueries : DatabaseSelectQueries
{
    public PostgreSqlDatabaseSelectQueries(DatabaseConnection connection) : base(connection) { }

    protected override SelectQuery<TResult> Create<TResult>(string tableName, string alias) => new PostgreSqlSelectQuery<TResult>(Connection, tableName, alias);

    protected override ConstSelectQuery CreateConst(string tableName) => new PostgreSqlConstSelectQuery(Connection, tableName);
}
