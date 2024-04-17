using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IcyRain.Tables;
using CommandBehavior = System.Data.CommandBehavior;

namespace RedLight.Internal;

internal sealed class DataSetTypeAction : TypeAction<DataSet>
{
    public override DataSet Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout)
    {
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            connection.Executor.BeginSession();
            reader = connection.Executor.RunReader(sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), behavior);
            return TableReader.CreateDataSet(connection, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            connection.Executor.EndSession();
        }
    }

    public override async Task<DataSet> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token)
    {
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            await connection.Executor.BeginSessionAsync().ConfigureAwait(false);

            reader = await connection.Executor.RunReaderAsync(
                sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), token, behavior).ConfigureAwait(false);

            return TableReader.CreateDataSet(connection, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            connection.Executor.EndSession();
        }
    }

    public override void BuildWithParseQuery(SelectQuery<DataSet> query, string alias, Table table)
    {
        foreach (var column in table.Columns)
            query.AddColumn(column.Name, alias);
    }

    public override void BuildWithParseQuery(InsertQuery<DataSet> query, Table table, DataSet row, bool returningIdentity, HashSet<string> excludedColumnNames)
        => DataTableTypeAction.Append(query, table, row.Values.First(), returningIdentity, excludedColumnNames);

    public override void BuildWithParseMultiQuery(MultiInsertQuery<DataSet> query, Table table, IReadOnlyCollection<DataSet> rows,
        bool returningIdentity, HashSet<string> excludedColumnNames)
        => DataTableTypeAction.Append(query, table, rows.First().Values.First(), returningIdentity, excludedColumnNames);

    public override void BuildWithParseMultiQuery(MultiInsertQuery<DataSet> query, Table table, DataSet row,
        bool returningIdentity, HashSet<string> excludedColumnNames)
        => DataTableTypeAction.Append(query, table, row.Values.First(), returningIdentity, excludedColumnNames);

    public override void BuildWithParseQuery(UpdateQuery query, Table table, DataSet row,
        HashSet<string> excludedColumnNames, string[] primaryKeyNames)
        => DataTableTypeAction.Append(query, table, primaryKeyNames, row.Values.First(), excludedColumnNames);

    public override void BuildWithParseMultiQuery(MultiUpdateQuery query, Table table, IReadOnlyCollection<DataSet> rows,
        HashSet<string> excludedColumnNames, string[] primaryKeyNames)
        => DataTableTypeAction.Append(query, table, primaryKeyNames, rows.First().Values.First(), excludedColumnNames);

    public override void BuildWithParseQuery(DeleteQuery query, Table table, DataSet row, string[] primaryKeyNames)
        => DataTableTypeAction.Append(query, table, primaryKeyNames, row.Values.First());

    public override void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<DataSet> rows, string primaryKeyName)
        => DataTableTypeAction.AppendValues(query, table, primaryKeyName, rows.First().Values.First());

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<DataSet> rows, string[] primaryKeyNames)
        => DataTableTypeAction.Append(query, table, primaryKeyNames, rows.First().Values.First());

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, DataSet row, string[] primaryKeyNames)
        => DataTableTypeAction.Append(query, table, primaryKeyNames, row.Values.First());
}
