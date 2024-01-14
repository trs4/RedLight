using System;

namespace RedLight;

/// <summary>Запросы изменения данных</summary>
public abstract class DatabaseUpdateQueries
{
    protected DatabaseUpdateQueries(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Создаёт запрос изменения данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public UpdateQuery CreateQuery(string tableName)
        => Create(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос изменения данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public UpdateQuery CreateQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => Create(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос изменения данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public UpdateQuery CreateQuery<TEnum>()
        where TEnum : Enum
        => Create(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос изменения множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiUpdateQuery CreateMultiQuery(string tableName)
        => CreateMulti(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос изменения множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiUpdateQuery CreateMultiQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateMulti(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос изменения множественных данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public MultiUpdateQuery CreateMultiQuery<TEnum>()
        where TEnum : Enum
        => CreateMulti(Connection.Naming.GetNameWithSchema<TEnum>());

    protected abstract UpdateQuery Create(string tableName);

    protected abstract MultiUpdateQuery CreateMulti(string tableName);
}
