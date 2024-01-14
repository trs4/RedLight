using System;
using IcyRain.Tables;

namespace RedLight;

/// <summary>Запросы добавления данных</summary>
public abstract class DatabaseInsertQueries
{
    protected DatabaseInsertQueries(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public InsertQuery CreateQuery(string tableName)
        => Create<DataResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public InsertQuery CreateQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => Create<DataResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public InsertQuery CreateQuery<TEnum>()
        where TEnum : Enum
        => Create<DataResult>(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос добавления данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <param name="tableName">Имя таблицы</param>
    public InsertQuery<TResult> CreateQuery<TResult>(string tableName)
        => Create<TResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="tableName">Имя таблицы</param>
    public InsertQuery<TResult> CreateQuery<TResult, TEnum>(TEnum tableName)
        where TEnum : Enum
        => Create<TResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public InsertQuery<TResult> CreateQuery<TResult, TEnum>()
        where TEnum : Enum
        => Create<TResult>(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiInsertQuery CreateMultiQuery(string tableName)
        => CreateMulti<DataResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiInsertQuery CreateMultiQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateMulti<DataResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public MultiInsertQuery CreateMultiQuery<TEnum>()
        where TEnum : Enum
        => CreateMulti<DataResult>(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <param name="tableName">Имя таблицы</param>
    public MultiInsertQuery<TResult> CreateMultiQuery<TResult>(string tableName)
        => CreateMulti<TResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="tableName">Имя таблицы</param>
    public MultiInsertQuery<TResult> CreateMultiQuery<TResult, TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateMulti<TResult>(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public MultiInsertQuery<TResult> CreateMultiQuery<TResult, TEnum>()
        where TEnum : Enum
        => CreateMulti<TResult>(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос добавления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="dataTable">Таблица значений</param>
    /// <param name="rowIndex">Индекс строки</param>
    public InsertQuery CreateQuery(string tableName, DataTable dataTable, int rowIndex)
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = Create<DataResult>(Connection.Naming.GetNameWithSchema(tableName));
        query.AddColumns(dataTable, rowIndex);
        return query;
    }

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="dataTable">Таблица значений</param>
    /// <param name="rowIndex">Индекс строки</param>
    public InsertQuery CreateQuery<TEnum>(TEnum tableName, DataTable dataTable, int rowIndex)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = Create<DataResult>(Connection.Naming.GetNameWithSchema(tableName));
        query.AddColumns(dataTable, rowIndex);
        return query;
    }

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="dataTable">Таблица значений</param>
    /// <param name="rowIndex">Индекс строки</param>
    public InsertQuery CreateQuery<TEnum>(DataTable dataTable, int rowIndex)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = Create<DataResult>(Connection.Naming.GetNameWithSchema<TEnum>());
        query.AddColumns(dataTable, rowIndex);
        return query;
    }


    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="dataTable">Таблица значений</param>
    public MultiInsertQuery CreateMultiQuery(string tableName, DataTable dataTable)
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = CreateMulti<DataResult>(Connection.Naming.GetNameWithSchema(tableName));
        query.AddColumns(dataTable);
        return query;
    }

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="dataTable">Таблица значений</param>
    public MultiInsertQuery CreateMultiQuery<TEnum>(TEnum tableName, DataTable dataTable)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = CreateMulti<DataResult>(Connection.Naming.GetNameWithSchema(tableName));
        query.AddColumns(dataTable);
        return query;
    }

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="dataTable">Таблица значений</param>
    public MultiInsertQuery CreateMultiQuery<TEnum>(DataTable dataTable)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = CreateMulti<DataResult>(Connection.Naming.GetNameWithSchema<TEnum>());
        query.AddColumns(dataTable);
        return query;
    }

    protected abstract InsertQuery<TResult> Create<TResult>(string tableName);

    protected abstract MultiInsertQuery<TResult> CreateMulti<TResult>(string tableName);
}
