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

        if (type == typeof(List<int>))
        {
            bool multipleResult = options?.MultipleResult ?? false;
            var list = new List<int>();

            do
            {
                while (reader.Read())
                    list.Add(reader.GetInt32(0));
            } while (multipleResult && reader.NextResult());

            return (T)(object)list;
        }

        throw new NotImplementedException();
    }

    [MethodImpl(Flags.HotPath)]
    public static void Append<T>(ICollection<T> source, DbDataReader reader, QueryOptions options)
    {
        var type = typeof(T);

        if (type == typeof(List<int>))
        {
            bool multipleResult = options?.MultipleResult ?? false;
            var list = (List<int>)source;

            do
            {
                while (reader.Read())
                    list.Add(reader.GetInt32(0));
            } while (multipleResult && reader.NextResult());
        }

        throw new NotImplementedException();
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
