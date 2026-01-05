using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using IcyRain.Tables;

namespace RedLight.Internal;

internal sealed class ClassTypeAction<T> : TypeAction<T>
{
    private static readonly Dictionary<string, PropertyInfo> _properties;

    static ClassTypeAction()
    {
        var properties = typeof(T).GetProperties();
        _properties = new(properties.Length);

        foreach (var property in properties)
            _properties[property.Name] = property;
    }

    public override T Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout)
        => throw new NotSupportedException(typeof(T).FullName);

    public override Task<T> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(SelectQuery<T> query, string alias, Table table)
    {
        foreach (var column in table.Columns)
        {
            if (!_properties.TryGetValue(column.Name, out var propertyInfo))
                continue;

            query.AddColumn(column.Name, alias);
            query.AddReadAction(column, (obj, value) => propertyInfo.SetValue(obj, value));
        }
    }

    public override void BuildWithParseQuery(InsertQuery<T> query, Table table, T row, bool returningIdentity, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = table.Identity?.Name;

        if (identityColumnName is not null)
        {
            foreach (var column in table.Columns)
            {
                if (!_properties.TryGetValue(column.Name, out var propertyInfo))
                    continue;

                if (returningIdentity && column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
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
                if (!_properties.TryGetValue(column.Name, out var propertyInfo) || (excludedColumnNames?.Contains(column.Name) ?? false))
                    continue;

                query.AddColumn(column, propertyInfo.GetValue(row));
            }
        }
    }

    public override void BuildWithParseMultiQuery(MultiInsertQuery<T> query, Table table, IReadOnlyCollection<T> rows,
        bool returningIdentity, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = table.Identity?.Name;

        if (identityColumnName is not null)
        {
            foreach (var column in table.Columns)
            {
                if (!_properties.TryGetValue(column.Name, out var propertyInfo))
                    continue;

                if (returningIdentity && column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
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
                if (!_properties.TryGetValue(column.Name, out var propertyInfo) || (excludedColumnNames?.Contains(column.Name) ?? false))
                    continue;

                query.AddColumn(column, ScalarReadBuilder.Fill(propertyInfo, rows));
            }
        }
    }

    public override void BuildWithParseMultiQuery(MultiInsertQuery<T> query, Table table, T row,
        bool returningIdentity, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = table.Identity?.Name;

        if (identityColumnName is not null)
        {
            foreach (var column in table.Columns)
            {
                if (!_properties.TryGetValue(column.Name, out var propertyInfo))
                    continue;

                if (returningIdentity && column.Name.Equals(identityColumnName, StringComparison.OrdinalIgnoreCase))
                {
                    query.AddReturningColumnCore(query.Connection.Naming.GetName(column.Name));
                    query.AddReadAction(column, (obj, value) => propertyInfo.SetValue(obj, value));
                    continue;
                }

                if (excludedColumnNames?.Contains(column.Name) ?? false)
                    continue;

                query.AddColumn(column, new object[] { propertyInfo.GetValue(row) });
            }
        }
        else
        {
            foreach (var column in table.Columns)
            {
                if (!_properties.TryGetValue(column.Name, out var propertyInfo) || (excludedColumnNames?.Contains(column.Name) ?? false))
                    continue;

                query.AddColumn(column, new object[] { propertyInfo.GetValue(row) });
            }
        }
    }

    public override void BuildWithParseQuery(UpdateQuery query, Table table, T row,
        HashSet<string> excludedColumnNames, IReadOnlyList<string> primaryKeyNames)
    {
        var columns = new Column[primaryKeyNames.Count];

        for (int i = 0; i < primaryKeyNames.Count; i++)
        {
            string primaryKeyName = primaryKeyNames[i];
            var column = table.FindColumn(primaryKeyName);

            if (!_properties.TryGetValue(primaryKeyName, out var primaryKeyPropertyInfo))
                throw new InvalidOperationException(primaryKeyName);

            query.WithTerm(primaryKeyName, Op.Equal, column, primaryKeyPropertyInfo.GetValue(row));
            columns[i] = column;
        }

        foreach (var column in table.Columns)
        {
            if (!_properties.TryGetValue(column.Name, out var propertyInfo) || columns.Any(c => ReferenceEquals(column, c)))
                continue;

            if (excludedColumnNames?.Contains(column.Name) ?? false)
                continue;

            query.AddColumn(column, propertyInfo.GetValue(row));
        }
    }

    public override void BuildWithParseMultiQuery(MultiUpdateQuery query, Table table, IReadOnlyCollection<T> rows,
        HashSet<string> excludedColumnNames, IReadOnlyList<string> primaryKeyNames)
    {
        foreach (string primaryKeyName in primaryKeyNames)
            query.OnColumn(primaryKeyName);

        foreach (var column in table.Columns)
        {
            if (!_properties.TryGetValue(column.Name, out var propertyInfo))
                continue;

            if (!primaryKeyNames.Any(primaryKeyName => column.Name.Equals(primaryKeyName, StringComparison.OrdinalIgnoreCase)))
                query.ReplaceDataColumn(column.Name, column.Name);

            if (excludedColumnNames?.Contains(column.Name) ?? false)
                continue;

            var (dataType, nullable, isArray) = column.GetDataType();
            var dataColumn = DataColumn.Create(dataType, rows.Count, nullable, isArray);
            int index = 0;

            foreach (var row in rows)
                dataColumn.SetObject(index++, propertyInfo.GetValue(row));

            query.AddColumn(column.Name, dataColumn, rows.Count);
        }
    }

    public override void BuildWithParseQuery(DeleteQuery query, Table table, T row, IReadOnlyList<string> primaryKeyNames)
    {
        foreach (string primaryKeyName in primaryKeyNames)
        {
            if (!_properties.TryGetValue(primaryKeyName, out var primaryKeyPropertyInfo))
                throw new InvalidOperationException(primaryKeyName);

            query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), primaryKeyPropertyInfo.GetValue(row));
        }
    }

    public override void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<T> rows, string primaryKeyName)
    {
        if (!_properties.TryGetValue(primaryKeyName, out var primaryKeyPropertyInfo))
            throw new InvalidOperationException(primaryKeyName);

        var dataType = DataType.Int32; // %%TODO
        var dataColumn = DataColumn.Create(dataType, rows.Count);
        int index = 0;

        foreach (var row in rows)
            dataColumn.SetObject(index++, primaryKeyPropertyInfo.GetValue(row));

        query.Where.WithValuesColumnTerm(primaryKeyName, dataColumn, rows.Count);
    }

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<T> rows, IReadOnlyList<string> primaryKeyNames)
    {
        foreach (var column in table.Columns)
        {
            if (!_properties.TryGetValue(column.Name, out var propertyInfo))
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

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, T row, IReadOnlyList<string> primaryKeyNames)
    {
        foreach (string primaryKeyName in primaryKeyNames)
        {
            if (!_properties.TryGetValue(primaryKeyName, out var primaryKeyPropertyInfo))
                throw new InvalidOperationException(primaryKeyName);

            query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), primaryKeyPropertyInfo.GetValue(row));
        }
    }

}
