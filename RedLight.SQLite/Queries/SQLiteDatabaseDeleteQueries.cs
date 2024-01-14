namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseDeleteQueries : DatabaseDeleteQueries
{
    public SQLiteDatabaseDeleteQueries(DatabaseConnection connection) : base(connection) { }

    protected override DeleteQuery Create(string tableName) => new SQLiteDeleteQuery(Connection, tableName);

    protected override MultiDeleteQuery CreateMulti(string tableName) => new SQLiteMultiDeleteQuery(Connection, tableName);
}
