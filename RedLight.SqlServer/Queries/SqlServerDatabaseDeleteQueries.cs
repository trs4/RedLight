namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseDeleteQueries : DatabaseDeleteQueries
{
    public SqlServerDatabaseDeleteQueries(DatabaseConnection connection) : base(connection) { }

    protected override DeleteQuery Create(string tableName) => new SqlServerDeleteQuery(Connection, tableName);

    protected override MultiDeleteQuery CreateMulti(string tableName) => new SqlServerMultiDeleteQuery(Connection, tableName);
}
