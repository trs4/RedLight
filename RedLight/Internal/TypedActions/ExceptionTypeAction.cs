using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight.Internal;

internal sealed class ExceptionTypeAction<T> : TypeAction<T>
{
    public override T Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout)
        => throw new NotSupportedException(typeof(T).FullName);

    public override Task<T> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token)
        => throw new NotSupportedException(typeof(T).FullName);

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
        HashSet<string> excludedColumnNames, IReadOnlyList<string> primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiUpdateQuery query, Table table, IReadOnlyCollection<T> rows,
        HashSet<string> excludedColumnNames, IReadOnlyList<string> primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(DeleteQuery query, Table table, T row, IReadOnlyList<string> primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<T> rows, string primaryKeyName)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<T> rows, IReadOnlyList<string> primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);

    public override void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, T row, IReadOnlyList<string> primaryKeyNames)
        => throw new NotSupportedException(typeof(T).FullName);
}
