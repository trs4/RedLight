using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IcyRain.Tables;
using CommandBehavior = System.Data.CommandBehavior;

namespace RedLight.Internal;

internal sealed class DataTableTypeAction : TypeAction<DataTable>
{
    public override DataTable Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout)
    {
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            connection.Executor.BeginSession();
            reader = connection.Executor.RunReader(sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), behavior);
            return TableReader.CreateDataTable(connection, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            connection.Executor.EndSession();
        }
    }

    public override async Task<DataTable> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token)
    {
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            await connection.Executor.BeginSessionAsync().ConfigureAwait(false);

            reader = await connection.Executor.RunReaderAsync(
                sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), token, behavior).ConfigureAwait(false);

            return TableReader.CreateDataTable(connection, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            connection.Executor.EndSession();
        }
    }

    public override void BuildWithParseQuery(SelectQuery<DataTable> query, string alias, Table table)
    {
        foreach (var column in table.Columns)
            query.AddColumn(column.Name, alias);
    }

    public override void BuildWithParseQuery(InsertQuery<DataTable> query, Table table, DataTable row, bool returningIdentity, HashSet<string> excludedColumnNames)
        => Append(query, table, row, returningIdentity, excludedColumnNames);

    public static void Append<TResult>(InsertQuery<TResult> query, Table table, DataTable dataTable,
        bool returningIdentity, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = null;
        DataColumn returningColumn = null;

        if (returningIdentity)
        {
            identityColumnName = table.Identity?.Name;

            if (identityColumnName is not null)
                dataTable.TryGetValue(identityColumnName, out returningColumn);
        }

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

    public override void BuildWithParseMultiQuery(MultiInsertQuery<DataTable> query, Table table, IReadOnlyCollection<DataTable> rows,
        bool returningIdentity, HashSet<string> excludedColumnNames)
        => Append(query, table, rows.First(), returningIdentity, excludedColumnNames);

    public override void BuildWithParseMultiQuery(MultiInsertQuery<DataTable> query, Table table, DataTable row,
        bool returningIdentity, HashSet<string> excludedColumnNames)
        => Append(query, table, row, returningIdentity, excludedColumnNames);

    public static void Append<TResult>(MultiInsertQuery<TResult> query, Table table, DataTable dataTable,
        bool returningIdentity, HashSet<string> excludedColumnNames)
    {
        string identityColumnName = null;
        DataColumn returningColumn = null;

        if (returningIdentity)
        {
            identityColumnName = table.Identity?.Name;

            if (identityColumnName is not null)
                dataTable.TryGetValue(identityColumnName, out returningColumn);
        }

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

    public override void BuildWithParseQuery(UpdateQuery query, Table table, DataTable row,
        HashSet<string> excludedColumnNames, IReadOnlyList<string> primaryKeyNames)
        => Append(query, table, primaryKeyNames, row, excludedColumnNames);

    public static void Append(UpdateQuery query, Table table, IReadOnlyList<string> primaryKeyNames, DataTable dataTable, HashSet<string> excludedColumnNames)
    {
        var columns = new Column[primaryKeyNames.Count];

        for (int i = 0; i < primaryKeyNames.Count; i++)
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

    public override void BuildWithParseMultiQuery(MultiUpdateQuery query, Table table, IReadOnlyCollection<DataTable> rows,
        HashSet<string> excludedColumnNames, IReadOnlyList<string> primaryKeyNames)
        => Append(query, table, primaryKeyNames, rows.First(), excludedColumnNames);

    public static void Append(MultiUpdateQuery query, Table table, IReadOnlyList<string> primaryKeyNames, DataTable dataTable, HashSet<string> excludedColumnNames)
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

    public override void BuildWithParseQuery(DeleteQuery query, Table table, DataTable row, IReadOnlyList<string> primaryKeyNames)
        => Append(query, table, primaryKeyNames, row);

    public static void Append(DeleteQuery query, Table table, IReadOnlyList<string> primaryKeyNames, DataTable dataTable)
    {
        foreach (string primaryKeyName in primaryKeyNames)
        {
            if (!dataTable.TryGetValue(primaryKeyName, out var dataColumn))
                throw new InvalidOperationException(primaryKeyName);

            query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), dataColumn.GetObject(0)); // %%TODO
        }
    }

    public override void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<DataTable> rows, string primaryKeyName)
        => AppendValues(query, table, primaryKeyName, rows.First());

    public static void AppendValues(DeleteQuery query, Table table, string primaryKeyName, DataTable dataTable)
    {
        if (!dataTable.TryGetValue(primaryKeyName, out var dataColumn))
            throw new InvalidOperationException(primaryKeyName);

        query.Where.WithValuesColumnTerm(primaryKeyName, dataColumn, dataTable.RowCount);
    }

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<DataTable> rows, IReadOnlyList<string> primaryKeyNames)
        => Append(query, table, primaryKeyNames, rows.First());

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, DataTable row, IReadOnlyList<string> primaryKeyNames)
        => Append(query, table, primaryKeyNames, row);

    public static void Append(MultiDeleteQuery query, Table table, IReadOnlyList<string> primaryKeyNames, DataTable dataTable)
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

}
