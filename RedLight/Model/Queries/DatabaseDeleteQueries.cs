using System;

namespace RedLight;

/// <summary>Запросы удаления данных</summary>
public abstract class DatabaseDeleteQueries
{
    protected DatabaseDeleteQueries(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Создаёт запрос удаления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteQuery CreateQuery(string tableName)
        => Create(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteQuery CreateQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => Create(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public DeleteQuery CreateQuery<TEnum>()
        where TEnum : Enum
        => Create(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiDeleteQuery CreateMultiQuery(string tableName)
        => CreateMulti(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiDeleteQuery CreateMultiQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateMulti(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public MultiDeleteQuery CreateMultiQuery<TEnum>()
        where TEnum : Enum
        => CreateMulti(Connection.Naming.GetNameWithSchema<TEnum>());

    protected abstract DeleteQuery Create(string tableName);

    protected abstract MultiDeleteQuery CreateMulti(string tableName);
}
