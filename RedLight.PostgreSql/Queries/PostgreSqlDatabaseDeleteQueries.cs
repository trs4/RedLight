namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseDeleteQueries : DatabaseDeleteQueries
{
    public PostgreSqlDatabaseDeleteQueries(DatabaseConnection connection) : base(connection) { }

    protected override DeleteQuery Create(string tableName) => new PostgreSqlDeleteQuery(Connection, tableName);

    protected override MultiDeleteQuery CreateMulti(string tableName) => new PostgreSqlMultiDeleteQuery(Connection, tableName);
}
