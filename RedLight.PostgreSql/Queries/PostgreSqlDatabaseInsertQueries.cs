namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseInsertQueries : DatabaseInsertQueries
{
    public PostgreSqlDatabaseInsertQueries(DatabaseConnection connection) : base(connection) { }

    protected override InsertQuery<TResult> Create<TResult>(string tableName) => new PostgreSqlInsertQuery<TResult>(Connection, tableName);

    protected override MultiInsertQuery<TResult> CreateMulti<TResult>(string tableName) => new PostgreSqlMultiInsertQuery<TResult>(Connection, tableName);
}
