namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseSchemaQueries : DatabaseSchemaQueries
{
    public PostgreSqlDatabaseSchemaQueries(DatabaseConnection connection) : base(connection) { }

    public override CreateDatabaseQuery CreateDatabaseQuery(string databaseName) => new PostgreSqlCreateDatabaseQuery(Connection, databaseName);

    public override DeleteDatabaseQuery DeleteDatabaseQuery(string databaseName) => new PostgreSqlDeleteDatabaseQuery(Connection, databaseName);

    protected override CreateTableQuery CreateCreateTable(string tableName) => new PostgreSqlCreateTableQuery(Connection, tableName);

    protected override DeleteTableQuery CreateDeleteTable(string tableName) => new PostgreSqlDeleteTableQuery(Connection, tableName);

    protected override CreateColumnQuery CreateCreateColumn(string tableName) => new PostgreSqlCreateColumnQuery(Connection, tableName);

    protected override ModifyColumnQuery CreateModifyColumn(string tableName) => new PostgreSqlModifyColumnQuery(Connection, tableName);

    protected override DeleteColumnQuery CreateDeleteColumn(string tableName) => new PostgreSqlDeleteColumnQuery(Connection, tableName);
}
