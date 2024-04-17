using System.Data.Common;
using IcyRain.Tables;

namespace RedLight.Internal;

internal static class TableReader
{
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
