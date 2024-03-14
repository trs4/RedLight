namespace RedLight.PostgreSql;

internal sealed class PostgreSqlConstSelectQuery : ConstSelectQuery
{
    public PostgreSqlConstSelectQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }
}
