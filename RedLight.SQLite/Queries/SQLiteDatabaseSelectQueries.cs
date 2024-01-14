namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseSelectQueries : DatabaseSelectQueries
{
    public SQLiteDatabaseSelectQueries(DatabaseConnection connection) : base(connection) { }

    protected override SelectQuery<TResult> Create<TResult>(string tableName, string alias) => new SQLiteSelectQuery<TResult>(Connection, tableName, alias);

    protected override ConstSelectQuery CreateConst(string tableName) => new SQLiteConstSelectQuery(Connection, tableName);
}
