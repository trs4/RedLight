using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using IcyRain.Tables;

namespace RedLight.Internal;

internal abstract class TypeAction<T>
{
    static TypeAction()
        => Instance = (TypeAction<T>)Create();

    public static TypeAction<T> Instance { get; }

    private static object Create()
    {
        var type = typeof(T);

        if (type == typeof(DataSet))
            return new DataSetTypeAction();
        else if (type == typeof(DataTable))
            return new DataTableTypeAction();
        else if (Types.TryGetICollectionArgumentType(type, out var elementType))
        {
            var definitionType = type.IsGenericType ? type.GetGenericTypeDefinition() : null;

            if (definitionType == typeof(List<>))
                return Activator.CreateInstance(typeof(ListTypeAction<>).MakeGenericType(elementType));
            else if (definitionType == typeof(HashSet<>))
                return Activator.CreateInstance(typeof(HashSetTypeAction<>).MakeGenericType(elementType));

            return Activator.CreateInstance(typeof(ICollectionTypeAction<,>).MakeGenericType(elementType, type));
        }
        else if (type.IsSystem())
            return new ScalarTypeAction<T>();
        else if (type.IsClass)
            return new ClassTypeAction<T>();
        else
            return new ExceptionTypeAction<T>();
    }

    public virtual T FillCollection(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
        => throw new NotSupportedException(typeof(T).FullName);

    public virtual void FillCollection(DatabaseConnection connection, T source, DbDataReader reader, QueryOptions options)
        => throw new NotSupportedException(typeof(T).FullName);

    public abstract T Get(DatabaseConnection connection, string sql, QueryOptions options, int timeout);

    public abstract Task<T> GetAsync(DatabaseConnection connection, string sql, QueryOptions options, int timeout, CancellationToken token);

    public abstract void BuildWithParseQuery(SelectQuery<T> query, string alias, Table table);

    public abstract void BuildWithParseQuery(InsertQuery<T> query, Table table, T row, bool returningIdentity, HashSet<string> excludedColumnNames);

    public abstract void BuildWithParseMultiQuery(MultiInsertQuery<T> query, Table table, IReadOnlyCollection<T> rows,
        bool returningIdentity, HashSet<string> excludedColumnNames);

    public abstract void BuildWithParseMultiQuery(MultiInsertQuery<T> query, Table table, T row,
        bool returningIdentity, HashSet<string> excludedColumnNames);

    public abstract void BuildWithParseQuery(UpdateQuery query, Table table, T row,
        HashSet<string> excludedColumnNames, string[] primaryKeyNames);

    public abstract void BuildWithParseMultiQuery(MultiUpdateQuery query, Table table, IReadOnlyCollection<T> rows,
        HashSet<string> excludedColumnNames, string[] primaryKeyNames);

    public abstract void BuildWithParseQuery(DeleteQuery query, Table table, T row, string[] primaryKeyNames);

    public abstract void BuildWithParseQuery(DeleteQuery query, Table table, IReadOnlyCollection<T> rows, string primaryKeyName);

    public abstract void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, IReadOnlyCollection<T> rows, string[] primaryKeyNames);

    public abstract void BuildWithParseMultiQuery(MultiDeleteQuery query, Table table, T row, string[] primaryKeyNames);
}
