namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseInsertQueries : DatabaseInsertQueries
{
    public SQLiteDatabaseInsertQueries(DatabaseConnection connection) : base(connection) { }

    protected override InsertQuery<TResult> Create<TResult>(string tableName) => new SQLiteInsertQuery<TResult>(Connection, tableName);

    protected override MultiInsertQuery<TResult> CreateMulti<TResult>(string tableName) => new SQLiteMultiInsertQuery<TResult>(Connection, tableName);
}
