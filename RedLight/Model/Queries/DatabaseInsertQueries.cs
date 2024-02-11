using System;
using System.Collections.Generic;
using System.Linq;
using IcyRain.Tables;
using RedLight.Internal;

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

    /// <summary>Создаёт запрос добавления данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="row">Вставляемый объект</param>
    /// <param name="excludedColumns">Исключить колонки</param>
    public InsertQuery<TResult> CreateWithParseQuery<TResult, TEnum>(TResult row, IReadOnlyCollection<string> excludedColumns = null)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        var query = CreateQuery<TResult, TEnum>();
        var excludedColumnNames = Extensions.GetExcludedColumnNames(excludedColumns);
        query.Data = row;
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, ((DataSet)(object)row).Values.First(), excludedColumnNames);
        else if (type == typeof(DataTable))
            Append(query, table, (DataTable)(object)row, excludedColumnNames);
        else if (type.IsClass && !type.IsSystem())
        {
            string identityColumnName = table.Identity?.Name;

            if (identityColumnName is not null)
            {
                foreach (var column in table.Columns)
                {
                    var propertyInfo = type.GetProperty(column.Name);

                    if (propertyInfo is null)
                        continue;

                    if (column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                    {
                        query.AddReturningColumnCore(query.Connection.Naming.GetName(column.Name));
                        query.AddReadAction(column, (obj, value) => propertyInfo.SetValue(obj, value));
                        continue;
                    }

                    if (excludedColumnNames?.Contains(column.Name) ?? false)
                        continue;

                    query.AddColumn(column, propertyInfo.GetValue(row));
                }
            }
            else
            {
                foreach (var column in table.Columns)
                {
                    var propertyInfo = type.GetProperty(column.Name);

                    if (propertyInfo is null || (excludedColumnNames?.Contains(column.Name) ?? false))
                        continue;

                    query.AddColumn(column, propertyInfo.GetValue(row));
                }
            }
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void Append<TResult>(InsertQuery<TResult> query, Table table, DataTable dataTable, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = table.Identity?.Name;
        dataTable.TryGetValue(identityColumnName, out var returningColumn);

        if (returningColumn is not null)
        {
            (excludedColumnNames ??= new(StringComparer.OrdinalIgnoreCase)).Add(identityColumnName);
            query.AddColumns(dataTable, 0, excludedColumnNames);

            query.AddReturningColumnCore(query.Connection.Naming.GetName(identityColumnName));
            query.AddReadAction(table.IdentityColumn, (obj, value) => returningColumn.SetObject(0, value));
        }
        else
            query.AddColumns(dataTable, 0, excludedColumnNames);
    }


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

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Вставляемый объект</param>
    /// <param name="excludedColumns">Исключить колонки</param>
    public MultiInsertQuery<TResult> CreateWithParseMultiQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows, IReadOnlyCollection<string> excludedColumns = null)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        var query = CreateMultiQuery<TResult, TEnum>();
        var excludedColumnNames = Extensions.GetExcludedColumnNames(excludedColumns);
        query.Data = rows;
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, ((DataSet)(object)rows.First()).Values.First(), excludedColumnNames); // %%TODO
        else if (type == typeof(DataTable))
            Append(query, table, (DataTable)(object)rows.First(), excludedColumnNames); // %%TODO
        else if (type.IsClass && !type.IsSystem())
        {
            string identityColumnName = table.Identity?.Name;

            if (identityColumnName is not null)
            {
                foreach (var column in table.Columns)
                {
                    var propertyInfo = type.GetProperty(column.Name);

                    if (propertyInfo is null)
                        continue;

                    if (column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                    {
                        query.AddReturningColumnCore(query.Connection.Naming.GetName(column.Name));
                        query.AddReadAction(column, (obj, value) => propertyInfo.SetValue(obj, value));
                        continue;
                    }

                    if (excludedColumnNames?.Contains(column.Name) ?? false)
                        continue;

                    query.AddColumn(column, ScalarReadBuilder.Fill(propertyInfo, rows));
                }
            }
            else
            {
                foreach (var column in table.Columns)
                {
                    var propertyInfo = type.GetProperty(column.Name);

                    if (propertyInfo is null || (excludedColumnNames?.Contains(column.Name) ?? false))
                        continue;

                    query.AddColumn(column, ScalarReadBuilder.Fill(propertyInfo, rows));
                }
            }
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void Append<TResult>(MultiInsertQuery<TResult> query, Table table, DataTable dataTable, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = table.Identity?.Name;
        dataTable.TryGetValue(identityColumnName, out var returningColumn);

        if (returningColumn is not null)
        {
            (excludedColumnNames ??= new(StringComparer.OrdinalIgnoreCase)).Add(identityColumnName);
            query.AddColumns(dataTable, excludedColumnNames);

            query.AddReturningColumnCore(query.Connection.Naming.GetName(identityColumnName));
            query.AddReadAction(table.IdentityColumn, (obj, value) => returningColumn.SetObject(0, value));
        }
        else
            query.AddColumns(dataTable, excludedColumnNames);
    }


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
