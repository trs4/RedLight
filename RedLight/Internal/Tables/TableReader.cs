using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using IcyRain.Tables;

namespace RedLight.Internal;

internal static class TableReader
{
    [MethodImpl(Flags.HotPath)]
    public static T Create<T>(DbDataReader reader, QueryOptions options)
    {
        var type = typeof(T);

        if (Types.TryGetICollectionArgumentType(type, out var elementType))
        {
            var source = Activator.CreateInstance<T>();
            typeof(TableReader).GetMethod(nameof(Append)).MakeGenericMethod(elementType).Invoke(null, new object[] { source, reader, options });
            return source;
        }
        else
            throw new NotSupportedException();
    }

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

    [MethodImpl(Flags.HotPath)]
    public static DataSet CreateDataSet(DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;
        var dataSet = new DataSet();
        int tableNumber = 0;

        do
        {
            var dataTable = dataSet.AddTable((++tableNumber).ToString());
            var readAction = new RowReadAction(dataTable, reader);

            while (reader.Read())
                readAction.Read();
        } while (multipleResult && reader.NextResult());

        return dataSet;
    }

    [MethodImpl(Flags.HotPath)]
    public static DataTable CreateDataTable(DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;
        var dataTable = new DataTable();
        var readAction = new RowReadAction(dataTable, reader);

        do
        {
            while (reader.Read())
                readAction.Read();
        } while (multipleResult && reader.NextResult());

        return dataTable;
    }

}
