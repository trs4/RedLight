using System;
using System.Data;
using System.Linq;
using System.Text;

namespace RedLight;

/// <summary>Построитель запроса чтения информации о базе данных</summary>
public class SchemaInfoQuery : Query, IRunQuery
{
    internal SchemaInfoQuery(DatabaseConnection connection) : base(connection) { }

    /// <summary>Максимальное время ожидания выполнения запроса</summary>
    public int Timeout { get; set; }

    /// <summary>Выполняет запрос с получением схемы данных</summary>
    /// <returns>Описание схемы данных</returns>
    public Database Get()
    {
        #region DataTables

        var dataTables = Connection.Executor.GetSchema("Tables");
        var dataColumns = Connection.Executor.GetSchema("Columns");

        var tableNameColumn = dataTables.Columns["TABLE_NAME"];
        var tableTypeColumn = dataTables.Columns["TABLE_TYPE"];

        var columnTableNameColumn = dataColumns.Columns["TABLE_NAME"];
        var columnNameColumn = dataColumns.Columns["COLUMN_NAME"];
        var columnTypeColumn = dataColumns.Columns["DATA_TYPE"];
        var columnNullableColumn = dataColumns.Columns["IS_NULLABLE"];
        var columnSizeColumn = dataColumns.Columns["CHARACTER_MAXIMUM_LENGTH"];
        var columnPrecisionColumn = dataColumns.Columns["NUMERIC_PRECISION"];
        var ordinalPositionColumn = dataColumns.Columns["ORDINAL_POSITION"];

        #endregion

        var schema = new Database(
            Connection.Parameters.DatabaseName,
            Connection.Parameters.ServerName,
            Connection.Parameters.FileExtension)
        {
            IsReadOnly = true,
        };

        foreach (var dataTableRow in dataTables.Rows.OfType<DataRow>())
        {
            string tableName = (string)dataTableRow[tableNameColumn];
            string tableType = (string)dataTableRow[tableTypeColumn];

            if (String.IsNullOrEmpty(tableName) || !CanAddTable(tableName, tableType))
                continue;

            var table = new Table(tableName);
            schema.AddTableInternal(table);
            var dataRows = dataColumns.Rows.OfType<DataRow>();

            if (ordinalPositionColumn is not null)
            {
                dataRows = ordinalPositionColumn.DataType == typeof(int)
                    ? dataRows.OrderBy(r => (int)r[ordinalPositionColumn])
                    : dataRows.OrderBy(r => (long)r[ordinalPositionColumn]);
            }

            foreach (var dataRow in dataRows)
            {
                string columnTableName = (string)dataRow[columnTableNameColumn];
                string columnName = (string)dataRow[columnNameColumn];

                if (columnName[0] == 65279) // Whitespace character
                    columnName = columnName.Substring(1);

                if (columnTableName != tableName || !CanAddColumn(columnName))
                    continue;

                var type = Connection.ColumnTypes.GetType(dataRow[columnTypeColumn]);
                bool nullable = ConvertToBool(dataRow[columnNullableColumn]);
                int size = ConvertToInt32(dataRow[columnSizeColumn]);
                int precision = ConvertToInt32(dataRow[columnPrecisionColumn]);

                var column = new Column(columnName, type, nullable, size, precision);
                table.AddColumnInternal(column);
            }
        }

        return schema;
    }

    protected virtual bool CanAddTable(string tableName, string tableType) => true;

    protected virtual bool CanAddColumn(string columnName) => true;

    private static bool ConvertToBool(object value)
    {
        if (value is DBNull)
            return false;
        if (value is bool boolValue)
            return boolValue;
        else if (value is string stringValue)
            return String.Equals(stringValue, "YES", StringComparison.OrdinalIgnoreCase);

        throw new NotSupportedException();
    }

    private static int ConvertToInt32(object value)
    {
        if (value is DBNull)
            return 0;
        else if (value is byte byteValue)
            return byteValue;
        else if (value is int intValue)
            return intValue;
        else if (value is long longValue)
            return (int)longValue;

        throw new NotSupportedException();
    }

    internal sealed override void BuildSql(StringBuilder builder, QueryOptions options) { }
}
