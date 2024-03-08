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
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, primaryKeyNames, ((DataSet)(object)row).Values.First(), excludedColumnNames);
        else if (type == typeof(DataTable))
            Append(query, table, primaryKeyNames, (DataTable)(object)row, excludedColumnNames);
        else if (type.IsClass && !type.IsSystem())
        {
            var columns = new Column[primaryKeyNames.Length];

            for (int i = 0; i < primaryKeyNames.Length; i++)
            {
                string primaryKeyName = primaryKeyNames[i];
                var column = table.FindColumn(primaryKeyName);
                var primaryKeyPropertyInfo = type.GetProperty(primaryKeyName) ?? throw new InvalidOperationException(primaryKeyName);
                query.WithTerm(primaryKeyName, Op.Equal, column, primaryKeyPropertyInfo.GetValue(row));
                columns[i] = column;
            }

            foreach (var column in table.Columns)
            {
                var propertyInfo = type.GetProperty(column.Name);

                if (propertyInfo is null || columns.Any(c => ReferenceEquals(column, c)))
                    continue;

                if (excludedColumnNames?.Contains(column.Name) ?? false)
                    continue;

                query.AddColumn(column, propertyInfo.GetValue(row));
            }
        }
        else
            throw new NotImplementedException();

        return query;
    }

    private static void Append(UpdateQuery query, Table table, string[] primaryKeyNames, DataTable dataTable, HashSet<string> excludedColumnNames)
    {
        var columns = new Column[primaryKeyNames.Length];

        for (int i = 0; i < primaryKeyNames.Length; i++)
        {
            string primaryKeyName = primaryKeyNames[i];
            var column = table.FindColumn(primaryKeyName);

            if (!dataTable.TryGetValue(primaryKeyName, out var dataColumn))
                throw new InvalidOperationException(primaryKeyName);

            query.WithTerm(primaryKeyName, Op.Equal, column, dataColumn.GetObject(0)); // %%TODO
            columns[i] = column;
        }

        foreach (var column in table.Columns)
        {
            if (!dataTable.TryGetValue(column.Name, out var dataColumn) || columns.Any(c => ReferenceEquals(column, c)))
                continue;

            if (excludedColumnNames?.Contains(column.Name) ?? false)
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
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, primaryKeyNames, ((DataSet)(object)rows.First()).Values.First(), excludedColumnNames); // %%TODO
        else if (type == typeof(DataTable))
            Append(query, table, primaryKeyNames, (DataTable)(object)rows.First(), excludedColumnNames); // %%TODO
        else if (type.IsClass && !type.IsSystem())
        {
            foreach (string primaryKeyName in primaryKeyNames)
                query.OnColumn(primaryKeyName);

            foreach (var column in table.Columns)
            {
                var propertyInfo = type.GetProperty(column.Name);

                if (propertyInfo is null)
                    continue;

                if (!primaryKeyNames.Any(primaryKeyName => column.Name.Equals(primaryKeyName, StringComparison.OrdinalIgnoreCase)))
                    query.ReplaceDataColumn(column.Name, column.Name);

                if (excludedColumnNames?.Contains(column.Name) ?? false)
                    continue;

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

    private static void Append(MultiUpdateQuery query, Table table, string[] primaryKeyNames, DataTable dataTable, HashSet<string> excludedColumnNames)
    {
        foreach (string primaryKeyName in primaryKeyNames)
            query.OnColumn(primaryKeyName);

        foreach (var column in table.Columns)
        {
            if (!dataTable.TryGetValue(column.Name, out var dataColumn))
                continue;

            if (!primaryKeyNames.Any(primaryKeyName => column.Name.Equals(primaryKeyName, StringComparison.OrdinalIgnoreCase)))
                query.ReplaceDataColumn(column.Name, column.Name);

            if (excludedColumnNames?.Contains(column.Name) ?? false)
                continue;

            query.AddColumn(column.Name, dataColumn, dataTable.RowCount);
        }
    }

    protected abstract UpdateQuery Create(string tableName);

    protected abstract MultiUpdateQuery CreateMulti(string tableName);
}
