namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseInsertQueries : DatabaseInsertQueries
{
    public SqlServerDatabaseInsertQueries(DatabaseConnection connection) : base(connection) { }

    protected override InsertQuery<TResult> Create<TResult>(string tableName) => new SqlServerInsertQuery<TResult>(Connection, tableName);

    protected override MultiInsertQuery<TResult> CreateMulti<TResult>(string tableName) => new SqlServerMultiInsertQuery<TResult>(Connection, tableName);
}
