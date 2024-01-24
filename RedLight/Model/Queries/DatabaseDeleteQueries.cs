using System;
using System.Collections.Generic;
using System.Linq;
using IcyRain.Tables;
using RedLight.Internal;

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


    /// <summary>Создаёт запрос удаления данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="row">Вставляемый объект</param>
    public DeleteQuery CreateWithParseQuery<TResult, TEnum>(TResult row)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        string columnName = table.Identity.Name ?? throw new InvalidOperationException(nameof(table.Identity));
        var query = CreateQuery<TEnum>();
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, columnName, ((DataSet)(object)row).Values.First());
        else if (type == typeof(DataTable))
            Append(query, table, columnName, (DataTable)(object)row);
        else if (type.IsClass && !type.IsSystem())
        {
            var propertyInfo = type.GetProperty(columnName) ?? throw new InvalidOperationException(columnName);
            query.WithRawTerm(columnName, Op.Equal, table.IdentityColumn, propertyInfo.GetValue(row));
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void Append(DeleteQuery query, Table table, string columnName, DataTable dataTable)
    {
        if (!dataTable.TryGetValue(columnName, out var dataColumn))
            throw new InvalidOperationException(columnName);

        query.WithRawTerm(columnName, Op.Equal, table.IdentityColumn, dataColumn.GetObject(0)); // %%TODO
    }

    /// <summary>Создаёт запрос добавления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Вставляемый объект</param>
    public DeleteQuery CreateWithParseQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        string columnName = table.Identity.Name ?? throw new InvalidOperationException(nameof(table.Identity));
        var query = CreateQuery<TEnum>();
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            AppendValues(query, table, columnName, ((DataSet)(object)rows).Values.First());
        else if (type == typeof(DataTable))
            AppendValues(query, table, columnName, (DataTable)(object)rows);
        else if (type.IsClass && !type.IsSystem())
        {
            var propertyInfo = type.GetProperty(columnName) ?? throw new InvalidOperationException(columnName);
            var dataType = DataType.Int32; // %%TODO
            var dataColumn = DataColumn.Create(dataType, rows.Count);
            int index = 0;

            foreach (var row in rows)
                dataColumn.SetObject(index++, propertyInfo.GetValue(row));

            query.Where.WithValuesColumnTerm(columnName, dataColumn, rows.Count);
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void AppendValues(DeleteQuery query, Table table, string columnName, DataTable dataTable)
    {
        if (!dataTable.TryGetValue(columnName, out var dataColumn))
            throw new InvalidOperationException(columnName);

        query.Where.WithValuesColumnTerm(columnName, dataColumn, dataTable.RowCount);
    }


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
