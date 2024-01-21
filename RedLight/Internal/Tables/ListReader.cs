using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class ListReader
{
    [MethodImpl(Flags.HotPath)]
    public static void Append<T>(ICollection<T> source, DbDataReader reader, QueryOptions options)
    {
        if (source is List<T> list)
            AppendCore(list, reader, options);
        else if (source is HashSet<T> hashSet)
            AppendCore(hashSet, reader, options);
        else if (source is ICollection<T> collection)
            AppendCore(collection, reader, options);
        else
            throw new NotSupportedException();
    }

    private static void AppendCore<T>(List<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(source, reader);
        } while (multipleResult && reader.NextResult());
    }

    private static void AppendCore<T>(HashSet<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(source, reader);
        } while (multipleResult && reader.NextResult());
    }

    private static void AppendCore<T>(ICollection<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(source, reader);
        } while (multipleResult && reader.NextResult());
    }

}
