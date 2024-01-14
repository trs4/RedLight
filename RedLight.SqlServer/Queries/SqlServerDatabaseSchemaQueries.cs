namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseSchemaQueries : DatabaseSchemaQueries
{
    public SqlServerDatabaseSchemaQueries(DatabaseConnection connection) : base(connection) { }

    public override CreateDatabaseQuery CreateDatabaseQuery(string databaseName) => new SqlServerCreateDatabaseQuery(Connection, databaseName);

    public override DeleteDatabaseQuery DeleteDatabaseQuery(string databaseName) => new SqlServerDeleteDatabaseQuery(Connection, databaseName);

    protected override CreateTableQuery CreateCreateTable(string tableName) => new SqlServerCreateTableQuery(Connection, tableName);

    protected override DeleteTableQuery CreateDeleteTable(string tableName) => new SqlServerDeleteTableQuery(Connection, tableName);

    protected override CreateColumnQuery CreateCreateColumn(string tableName) => new SqlServerCreateColumnQuery(Connection, tableName);

    protected override ModifyColumnQuery CreateModifyColumn(string tableName) => new SqlServerModifyColumnQuery(Connection, tableName);

    protected override DeleteColumnQuery CreateDeleteColumn(string tableName) => new SqlServerDeleteColumnQuery(Connection, tableName);
}
