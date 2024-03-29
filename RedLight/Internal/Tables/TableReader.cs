﻿using System;
using System.Data.Common;
using System.Runtime.CompilerServices;
using IcyRain.Tables;

namespace RedLight.Internal;

internal static class TableReader
{
    [MethodImpl(Flags.HotPath)]
    public static T Create<T>(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
    {
        var type = typeof(T);

        if (Types.TryGetICollectionArgumentType(type, out var elementType))
        {
            var source = Activator.CreateInstance<T>();
            typeof(ListReader).GetMethod(nameof(ListReader.Append)).MakeGenericMethod(elementType).Invoke(null, [connection, source, reader, options]);
            return source;
        }
        else
            throw new NotSupportedException();
    }

    [MethodImpl(Flags.HotPath)]
    public static DataSet CreateDataSet(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;
        var dataSet = new DataSet();
        int tableNumber = 0;

        do
        {
            var dataTable = dataSet.AddTable((++tableNumber).ToString());
            var readAction = new RowReadAction(connection, dataTable, reader);

            while (reader.Read())
                readAction.Read();
        } while (multipleResult && reader.NextResult());

        return dataSet;
    }

    [MethodImpl(Flags.HotPath)]
    public static DataTable CreateDataTable(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;
        var dataTable = new DataTable();
        var readAction = new RowReadAction(connection, dataTable, reader);

        do
        {
            while (reader.Read())
                readAction.Read();
        } while (multipleResult && reader.NextResult());

        return dataTable;
    }

}
