using System;
using System.Collections.Generic;
using System.Linq;
using IcyRain.Tables;
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
    /// <param name="row">Вставляемый объект</param>
    public UpdateQuery CreateWithParseQuery<TResult, TEnum>(TResult row)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        string identityColumnName = table.Identity.Name ?? throw new InvalidOperationException(nameof(table.Identity));
        var query = CreateQuery<TEnum>();
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, identityColumnName, ((DataSet)(object)row).Values.First());
        else if (type == typeof(DataTable))
            Append(query, table, identityColumnName, (DataTable)(object)row);
        else if (type.IsClass && !type.IsSystem())
        {
            var identityPropertyInfo = type.GetProperty(identityColumnName) ?? throw new InvalidOperationException(identityColumnName);
            query.WithRawTerm(identityColumnName, Op.Equal, table.IdentityColumn, identityPropertyInfo.GetValue(row));

            foreach (var column in table.Columns)
            {
                var propertyInfo = type.GetProperty(column.Name);

                if (propertyInfo is null || column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                    continue;

                query.AddColumn(column, propertyInfo.GetValue(row));
            }
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void Append(UpdateQuery query, Table table, string identityColumnName, DataTable dataTable)
    {
        if (!dataTable.TryGetValue(identityColumnName, out var dataColumn))
            throw new InvalidOperationException(identityColumnName);

        query.WithRawTerm(identityColumnName, Op.Equal, table.IdentityColumn, dataColumn.GetObject(0)); // %%TODO

        foreach (var column in table.Columns)
        {
            if (!dataTable.TryGetValue(column.Name, out dataColumn) || column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                continue;

            query.AddColumn(column.Name, dataColumn.GetObject(0));
        }
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
    /// <param name="rows">Вставляемый объект</param>
    public MultiUpdateQuery CreateWithParseMultiQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        var query = CreateMultiQuery<TEnum>();
        string identityColumnName = table.Identity.Name ?? throw new InvalidOperationException(nameof(table.Identity));
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, identityColumnName, ((DataSet)(object)rows).Values.First());
        else if (type == typeof(DataTable))
            Append(query, table, identityColumnName, (DataTable)(object)rows);
        else if (type.IsClass && !type.IsSystem())
        {
            query.OnColumn(identityColumnName);

            foreach (var column in table.Columns)
            {
                var propertyInfo = type.GetProperty(column.Name);

                if (propertyInfo is null)
                    continue;

                if (!column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                    query.ReplaceDataColumn(column.Name, column.Name);

                var (dataType, nullable, isArray) = column.GetDataType();
                var dataColumn = DataColumn.Create(dataType, rows.Count, nullable, isArray); // %%TODO
                int index = 0;

                foreach (var row in rows)
                    dataColumn.SetObject(index++, propertyInfo.GetValue(row));

                query.AddColumn(column.Name, dataColumn, rows.Count);
            }
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void Append(MultiUpdateQuery query, Table table, string identityColumnName, DataTable dataTable)
    {
        query.OnColumn(identityColumnName);

        foreach (var column in table.Columns)
        {
            if (!dataTable.TryGetValue(column.Name, out var dataColumn))
                continue;

            if (!column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                query.ReplaceDataColumn(column.Name, column.Name);

            query.AddColumn(column.Name, dataColumn, dataTable.RowCount);
        }
    }

    protected abstract UpdateQuery Create(string tableName);

    protected abstract MultiUpdateQuery CreateMulti(string tableName);
}
