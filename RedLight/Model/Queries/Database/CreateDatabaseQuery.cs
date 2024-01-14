namespace RedLight;

/// <summary>Создание базы данных</summary>
public abstract class CreateDatabaseQuery : DatabaseQuery
{
    protected CreateDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }
}
