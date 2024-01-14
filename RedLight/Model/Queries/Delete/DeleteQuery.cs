namespace RedLight;

/// <summary>Построитель запроса удаления данных</summary>
public abstract class DeleteQuery : WhereQuery
{
    protected DeleteQuery(DatabaseConnection connection, string tableName) : base(connection, tableName, null) { }
}
