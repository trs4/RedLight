namespace RedLight.SQLite;

internal sealed class SQLiteConstSelectQuery : ConstSelectQuery
{
    public SQLiteConstSelectQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }
}
