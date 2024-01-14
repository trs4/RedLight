namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseUpdateQueries : DatabaseUpdateQueries
{
    public SQLiteDatabaseUpdateQueries(DatabaseConnection connection) : base(connection) { }

    protected override UpdateQuery Create(string tableName) => new SQLiteUpdateQuery(Connection, tableName);

    protected override MultiUpdateQuery CreateMulti(string tableName) => new SQLiteMultiUpdateQuery(Connection, tableName);
}
