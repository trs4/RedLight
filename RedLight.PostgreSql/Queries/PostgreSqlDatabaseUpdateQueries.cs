namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseUpdateQueries : DatabaseUpdateQueries
{
    public PostgreSqlDatabaseUpdateQueries(DatabaseConnection connection) : base(connection) { }

    protected override UpdateQuery Create(string tableName) => new PostgreSqlUpdateQuery(Connection, tableName);

    protected override MultiUpdateQuery CreateMulti(string tableName) => new PostgreSqlMultiUpdateQuery(Connection, tableName);
}
