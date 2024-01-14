namespace RedLight;

/// <summary>Удаление таблицы</summary>
public abstract class DeleteTableQuery : SchemaQuery
{
    protected DeleteTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }
}
