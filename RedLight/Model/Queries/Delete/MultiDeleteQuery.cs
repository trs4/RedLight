namespace RedLight;

/// <summary>Построитель запроса удаления множественных данных</summary>
public abstract class MultiDeleteQuery : DataMultiValueQuery
{
    protected MultiDeleteQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }
}
