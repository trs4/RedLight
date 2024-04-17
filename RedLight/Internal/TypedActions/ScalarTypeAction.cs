using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight.Internal;

internal sealed class ScalarTypeAction<T> : TypeAction<T>
{
    public override T Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout)
    {
        object result = connection.Executor.RunScalar(sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout));
        return Extensions.Convert<T>(result);
    }

    public override async Task<T> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token)
    {
        object result = await connection.Executor.RunScalarAsync(
            sql, connection.Prepare(options), DatabaseConnection.GetTimeout(timeout), token).ConfigureAwait(false);

        return Extensions.Convert<T>(result);
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
    {
        foreach (string primaryKeyName in primaryKeyNames)
            query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), row);
    }

    public override void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<T> rows, string primaryKeyName)
        => query.Where.WithValuesTerm(primaryKeyName, rows);

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<T> rows, string[] primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, T row, string[] primaryKeyNames)
    {
        foreach (string primaryKeyName in primaryKeyNames)
            query.WithTerm(primaryKeyName, Op.Equal, table.FindColumn(primaryKeyName), row);
    }

}
