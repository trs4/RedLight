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
    /// <param name="row">Удаляемый объект</param>
    public DeleteQuery CreateWithParseQuery<TResult, TEnum>(TResult row)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var query = CreateQuery<TEnum>();
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, primaryKeyNames, ((DataSet)(object)row).Values.First());
        else if (type == typeof(DataTable))
            Append(query, table, primaryKeyNames, (DataTable)(object)row);
        else if (type.IsClass && !type.IsSystem())
        {
            foreach (string primaryKeyName in primaryKeyNames)
            {
                var primaryKeyPropertyInfo = type.GetProperty(primaryKeyName) ?? throw new InvalidOperationException(primaryKeyName);
                query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), primaryKeyPropertyInfo.GetValue(row));
            }
        }
        else
        {
            foreach (string primaryKeyName in primaryKeyNames)
                query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), row);
        }

        return query;
    }

    private static void Append(DeleteQuery query, Table table, string[] primaryKeyNames, DataTable dataTable)
    {
        foreach (string primaryKeyName in primaryKeyNames)
        {
            if (!dataTable.TryGetValue(primaryKeyName, out var dataColumn))
                throw new InvalidOperationException(primaryKeyName);

            query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), dataColumn.GetObject(0)); // %%TODO
        }
    }

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Удаляемые объекты</param>
    public DeleteQuery CreateWithParseQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        string primaryKeyName = primaryKeyNames.Length == 1 ? primaryKeyNames[0] : throw new InvalidOperationException("Use CreateWithParseMultiQuery");
        var query = CreateQuery<TEnum>();
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            AppendValues(query, table, primaryKeyName, ((DataSet)(object)rows.First()).Values.First()); // %%TODO
        else if (type == typeof(DataTable))
            AppendValues(query, table, primaryKeyName, (DataTable)(object)rows.First()); // %%TODO
        else if (type.IsClass && !type.IsSystem())
        {
            var primaryKeyPropertyInfo = type.GetProperty(primaryKeyName) ?? throw new InvalidOperationException(primaryKeyName);
            var dataType = DataType.Int32; // %%TODO
            var dataColumn = DataColumn.Create(dataType, rows.Count);
            int index = 0;

            foreach (var row in rows)
                dataColumn.SetObject(index++, primaryKeyPropertyInfo.GetValue(row));

            query.Where.WithValuesColumnTerm(primaryKeyName, dataColumn, rows.Count);
        }
        else
            query.Where.WithValuesTerm(primaryKeyName, rows);

        return query;
    }

    private static void AppendValues(DeleteQuery query, Table table, string primaryKeyName, DataTable dataTable)
    {
        if (!dataTable.TryGetValue(primaryKeyName, out var dataColumn))
            throw new InvalidOperationException(primaryKeyName);

        query.Where.WithValuesColumnTerm(primaryKeyName, dataColumn, dataTable.RowCount);
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

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Удаляемые объекты</param>
    public MultiDeleteQuery CreateWithParseMultiQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var query = CreateMultiQuery<TEnum>();
        var type = typeof(TResult);

        if (type == typeof(DataSet))
            Append(query, table, primaryKeyNames, ((DataSet)(object)rows.First()).Values.First()); // %%TODO
        else if (type == typeof(DataTable))
            Append(query, table, primaryKeyNames, (DataTable)(object)rows.First()); // %%TODO
        else if (type.IsClass && !type.IsSystem())
        {
            foreach (var column in table.Columns)
            {
                var propertyInfo = type.GetProperty(column.Name);

                if (propertyInfo is null)
                    continue;

                if (!primaryKeyNames.Any(primaryKeyName => column.Name.Equals(primaryKeyName, StringComparison.OrdinalIgnoreCase)))
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

    private static void Append(MultiDeleteQuery query, Table table, string[] primaryKeyNames, DataTable dataTable)
    {
        foreach (var column in table.Columns)
        {
            if (!dataTable.TryGetValue(column.Name, out var dataColumn))
                continue;

            if (!primaryKeyNames.Any(primaryKeyName => column.Name.Equals(primaryKeyName, StringComparison.OrdinalIgnoreCase)))
                continue;

            query.AddColumn(column.Name, dataColumn, dataTable.RowCount);
        }
    }

    protected abstract DeleteQuery Create(string tableName);

    protected abstract MultiDeleteQuery CreateMulti(string tableName);
}
