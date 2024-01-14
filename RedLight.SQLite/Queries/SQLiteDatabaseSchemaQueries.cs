namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseSchemaQueries : DatabaseSchemaQueries
{
    public SQLiteDatabaseSchemaQueries(DatabaseConnection connection) : base(connection) { }

    public override CreateDatabaseQuery CreateDatabaseQuery(string databaseName) => new SQLiteCreateDatabaseQuery(Connection, databaseName);

    public override DeleteDatabaseQuery DeleteDatabaseQuery(string databaseName) => new SQLiteDeleteDatabaseQuery(Connection, databaseName);

    protected override CreateTableQuery CreateCreateTable(string tableName) => new SQLiteCreateTableQuery(Connection, tableName);

    protected override DeleteTableQuery CreateDeleteTable(string tableName) => new SQLiteDeleteTableQuery(Connection, tableName);

    protected override CreateColumnQuery CreateCreateColumn(string tableName) => new SQLiteCreateColumnQuery(Connection, tableName);

    protected override ModifyColumnQuery CreateModifyColumn(string tableName) => new SQLiteModifyColumnQuery(Connection, tableName);

    protected override DeleteColumnQuery CreateDeleteColumn(string tableName) => new SQLiteDeleteColumnQuery(Connection, tableName);
}
