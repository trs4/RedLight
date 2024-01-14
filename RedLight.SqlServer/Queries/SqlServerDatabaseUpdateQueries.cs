namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseUpdateQueries : DatabaseUpdateQueries
{
    public SqlServerDatabaseUpdateQueries(DatabaseConnection connection) : base(connection) { }

    protected override UpdateQuery Create(string tableName) => new SqlServerUpdateQuery(Connection, tableName);

    protected override MultiUpdateQuery CreateMulti(string tableName) => new SqlServerMultiUpdateQuery(Connection, tableName);
}
