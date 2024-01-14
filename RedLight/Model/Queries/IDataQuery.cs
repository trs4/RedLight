namespace RedLight;

/// <summary>Запрос изменения данных</summary>
public interface IDataQuery
{
    /// <summary>Интерфейс взаимодействия с базой данных</summary>
    DatabaseConnection Connection { get; }

    /// <summary>Имя таблицы</summary>
    string TableName { get; }

    /// <summary>Псевдоним таблицы</summary>
    string Alias { get; }

    /// <summary>Псевдоним таблицы данных</summary>
    string DataAlias { get; }
}