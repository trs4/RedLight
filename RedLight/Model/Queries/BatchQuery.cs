using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight;

/// <summary>Группа запросов</summary>
public class BatchQuery : Query, IRunQuery, IList<Query>
{
    private readonly List<Query> _queries = [];

    internal BatchQuery(DatabaseConnection connection) : base(connection) { }

    /// <summary>Максимальное время ожидания выполнения запроса</summary>
    public int Timeout => _queries.OfType<IRunQuery>().Sum(q => q.Timeout);

    internal sealed override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        foreach (var query in _queries)
        {
            query.BuildSql(builder, options);
            builder.Append(";\r\n\r\n");
        }
    }

    /// <summary>Выполняет список запросов</summary>
    /// <returns>Количество обработанных строк</returns>
    public int Run()
    {
        using var session = DatabaseConnectionSession.Open(Connection);
        int rowsAffected = 0;

        foreach (var query in _queries)
        {
            if (query is RunQuery runQuery)
            {
                int queryRowsAffected = runQuery.Run();

                if (queryRowsAffected > 0)
                    rowsAffected += queryRowsAffected;
            }
            else if (query is SchemaQuery schemaQuery)
                schemaQuery.Run();
        }

        return rowsAffected;
    }

    /// <summary>Выполняет список запросов</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Количество обработанных строк</returns>
    public async Task<int> RunAsync(CancellationToken token = default)
    {
        using var session = DatabaseConnectionSession.Open(Connection);
        int rowsAffected = 0;

        foreach (var query in _queries)
        {
            if (token.IsCancellationRequested)
                return rowsAffected;

            if (query is RunQuery runQuery)
            {
                int queryRowsAffected = await runQuery.RunAsync(token).ConfigureAwait(false);

                if (queryRowsAffected > 0)
                    rowsAffected += queryRowsAffected;
            }
            else if (query is SchemaQuery schemaQuery)
                await schemaQuery.RunAsync(token).ConfigureAwait(false);
        }

        return rowsAffected;
    }

    #region IList

    public Query this[int index]
    {
        get => _queries[index];
        set => throw new NotSupportedException();
    }

    public int Count => _queries.Count;

    bool ICollection<Query>.IsReadOnly => false;

    public void Add(Query query)
    {
        ArgumentNullException.ThrowIfNull(query);

        if (query is RunQuery || query is SchemaQuery)
            _queries.Add(query);
        else
            throw new NotSupportedException(query.GetType().FullName);
    }

    public void Clear() => _queries.Clear();

    public bool Contains(Query query) => _queries.Contains(query);

    void ICollection<Query>.CopyTo(Query[] array, int arrayIndex) => _queries.CopyTo(array, arrayIndex);

    public int IndexOf(Query query) => _queries.IndexOf(query);

    public void Insert(int index, Query query)
    {
        ArgumentNullException.ThrowIfNull(query);

        if (query is RunQuery || query is SchemaQuery)
            _queries.Insert(index, query);
        else
            throw new NotSupportedException(query.GetType().FullName);
    }

    public bool Remove(Query query) => _queries.Remove(query);

    public void RemoveAt(int index) => _queries.RemoveAt(index);

    IEnumerator<Query> IEnumerable<Query>.GetEnumerator() => _queries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _queries.GetEnumerator();

    #endregion
}
