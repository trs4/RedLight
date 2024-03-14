namespace RedLight.SqlServer;

internal sealed class SqlServerConstSelectQuery : ConstSelectQuery
{
    public SqlServerConstSelectQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }
}
