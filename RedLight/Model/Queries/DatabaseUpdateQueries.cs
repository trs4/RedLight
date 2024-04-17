using System;
using System.Collections.Generic;
using RedLight.Internal;

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

    /// <summary>Создаёт запрос изменения данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="row">Обновляемый объект</param>
    /// <param name="excludedColumns">Исключить колонки</param>
    public UpdateQuery CreateWithParseQuery<TResult, TEnum>(TResult row, IReadOnlyCollection<string> excludedColumns = null)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var excludedColumnNames = Extensions.GetExcludedColumnNames(excludedColumns);
        var query = CreateQuery<TEnum>();
        TypeAction<TResult>.Instance.BuildWithParseQuery(query, table, row, excludedColumnNames, primaryKeyNames);
        return query;
    }


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

    /// <summary>Создаёт запрос изменения множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Обновляемые объекты</param>
    /// <param name="excludedColumns">Исключить колонки</param>
    public MultiUpdateQuery CreateWithParseMultiQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows, IReadOnlyCollection<string> excludedColumns = null)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        var query = CreateMultiQuery<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var excludedColumnNames = Extensions.GetExcludedColumnNames(excludedColumns);
        TypeAction<TResult>.Instance.BuildWithParseMultiQuery(query, table, rows, excludedColumnNames, primaryKeyNames);
        return query;
    }

    protected abstract UpdateQuery Create(string tableName);

    protected abstract MultiUpdateQuery CreateMulti(string tableName);
}
