namespace RedLight;

/// <summary>Удаление базы данных</summary>
public abstract class DeleteDatabaseQuery : DatabaseQuery
{
    protected DeleteDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }
}