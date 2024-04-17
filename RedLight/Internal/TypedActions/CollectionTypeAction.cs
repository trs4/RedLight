using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using CommandBehavior = System.Data.CommandBehavior;

namespace RedLight.Internal;

internal abstract class CollectionTypeAction<T> : TypeAction<T>
{
    public sealed override T Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout)
    {
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            connection.Executor.BeginSession();
            reader = connection.Executor.RunReader(sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), behavior);
            return FillCollection(connection, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            connection.Executor.EndSession();
        }
    }

    public sealed override async Task<T> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token)
    {
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            await connection.Executor.BeginSessionAsync().ConfigureAwait(false);

            reader = await connection.Executor.RunReaderAsync(
                sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), token, behavior).ConfigureAwait(false);

            return FillCollection(connection, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            connection.Executor.EndSession();
        }
    }

    public override void BuildWithParseQuery(SelectQuery<T> query, string alias, Table table)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(InsertQuery<T> query, Table table, T row, bool returningIdentity, HashSet<string> excludedColumnNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiInsertQuery<T> query, Table table, IReadOnlyCollection<T> rows,
        bool returningIdentity, HashSet<string> excludedColumnNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiInsertQuery<T> query, Table table, T row,
        bool returningIdentity, HashSet<string> excludedColumnNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(UpdateQuery query, Table table, T row,
        HashSet<string> excludedColumnNames, string[] primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiUpdateQuery query, Table table, IReadOnlyCollection<T> rows,
        HashSet<string> excludedColumnNames, string[] primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(DeleteQuery query, Table table, T row, string[] primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<T> rows, string primaryKeyName)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<T> rows, string[] primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, T row, string[] primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);
}
