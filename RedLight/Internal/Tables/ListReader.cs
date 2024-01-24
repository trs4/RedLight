using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class ListReader
{
    [MethodImpl(Flags.HotPath)]
    public static void Append<T>(DatabaseConnection connection, ICollection<T> source, DbDataReader reader, QueryOptions options)
    {
        if (source is List<T> list)
            AppendCore(connection, list, reader, options);
        else if (source is HashSet<T> hashSet)
            AppendCore(connection, hashSet, reader, options);
        else if (source is ICollection<T> collection)
            AppendCore(connection, collection, reader, options);
        else
            throw new NotSupportedException();
    }

    private static void AppendCore<T>(DatabaseConnection connection, List<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(connection, source, reader);
        } while (multipleResult && reader.NextResult());
    }

    private static void AppendCore<T>(DatabaseConnection connection, HashSet<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(connection, source, reader);
        } while (multipleResult && reader.NextResult());
    }

    private static void AppendCore<T>(DatabaseConnection connection, ICollection<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(connection, source, reader);
        } while (multipleResult && reader.NextResult());
    }

}
