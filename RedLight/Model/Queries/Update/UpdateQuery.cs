namespace RedLight;

/// <summary>Построитель запроса изменения данных</summary>
public abstract class UpdateQuery : ValueQuery
{
    protected UpdateQuery(DatabaseConnection connection, string tableName) : base(connection, tableName, null) { }
}
