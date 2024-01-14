using System;
using System.Collections.Generic;
using System.Data.Common;
using IcyRain.Tables;

namespace RedLight.Internal;

public sealed class RowReadAction
{
    private readonly static Dictionary<Type, Func<DataTable, int, string, ColumnReadAction>> _columns = new()
    {
        { typeof(bool), (dataTable, index, name) => new ColumnReadActionBool(dataTable, index, name) },
        { typeof(byte), (dataTable, index, name) => new ColumnReadActionByte(dataTable, index, name) },
        { typeof(short), (dataTable, index, name) => new ColumnReadActionShort(dataTable, index, name) },
        { typeof(int), (dataTable, index, name) => new ColumnReadActionInt(dataTable, index, name) },
        { typeof(long), (dataTable, index, name) => new ColumnReadActionLong(dataTable, index, name) },
        { typeof(float), (dataTable, index, name) => new ColumnReadActionFloat(dataTable, index, name) },
        { typeof(double), (dataTable, index, name) => new ColumnReadActionDouble(dataTable, index, name) },
        { typeof(decimal), (dataTable, index, name) => new ColumnReadActionDecimal(dataTable, index, name) },
        { typeof(string), (dataTable, index, name) => new ColumnReadActionString(dataTable, index, name) },
        { typeof(DateTime), (dataTable, index, name) => new ColumnReadActionDateTime(dataTable, index, name) },
        { typeof(Guid), (dataTable, index, name) => new ColumnReadActionGuid(dataTable, index, name) },
        { typeof(byte[]), (dataTable, index, name) => new ColumnReadActionByteArray(dataTable, index, name) },
    };

    private readonly static Dictionary<Type, Func<DataTable, int, string, ColumnReadAction>> _nullableColumns = new()
    {
        { typeof(bool), (dataTable, index, name) => new ColumnReadActionNullableBool(dataTable, index, name) },
        { typeof(byte), (dataTable, index, name) => new ColumnReadActionNullableByte(dataTable, index, name) },
        { typeof(short), (dataTable, index, name) => new ColumnReadActionNullableShort(dataTable, index, name) },
        { typeof(int), (dataTable, index, name) => new ColumnReadActionNullableInt(dataTable, index, name) },
        { typeof(long), (dataTable, index, name) => new ColumnReadActionNullableLong(dataTable, index, name) },
        { typeof(float), (dataTable, index, name) => new ColumnReadActionNullableFloat(dataTable, index, name) },
        { typeof(double), (dataTable, index, name) => new ColumnReadActionNullableDouble(dataTable, index, name) },
        { typeof(decimal), (dataTable, index, name) => new ColumnReadActionNullableDecimal(dataTable, index, name) },
        { typeof(string), (dataTable, index, name) => new ColumnReadActionNullableString(dataTable, index, name) },
        { typeof(DateTime), (dataTable, index, name) => new ColumnReadActionNullableDateTime(dataTable, index, name) },
        { typeof(Guid), (dataTable, index, name) => new ColumnReadActionNullableGuid(dataTable, index, name) },
    };

    private readonly DataTable _dataTable;
    private readonly DbDataReader _reader;
    private readonly ColumnReadAction[] _readActions;

    public RowReadAction(DataTable dataTable, DbDataReader reader)
    {
        _dataTable = dataTable ?? throw new ArgumentNullException(nameof(dataTable));
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        _readActions = new ColumnReadAction[reader.FieldCount];
        var schema = reader.GetSchemaTable();

        for (int rowIndex = 0; rowIndex < schema.Rows.Count; rowIndex++)
        {
            var row = schema.Rows[rowIndex];
            string columnName = row["ColumnName"] as string;
            var columnType = row["DataType"] as Type;
            bool nullable = row["AllowDBNull"] is bool boolValue && boolValue;

            if (nullable)
            {
                if (_nullableColumns.TryGetValue(columnType, out var columnFunc))
                    _readActions[rowIndex] = columnFunc(dataTable, rowIndex, columnName);
                else
                    throw new InvalidOperationException($"{columnName}: {columnType.FullName}");
            }
            else
            {
                if (_columns.TryGetValue(columnType, out var columnFunc))
                    _readActions[rowIndex] = columnFunc(dataTable, rowIndex, columnName);
                else
                    throw new InvalidOperationException($"{columnName}: {columnType.FullName}");
            }
        }
    }

    public void Read()
    {
        int row = ++_dataTable.RowCount;

        for (int columnIndex = 0; columnIndex < _readActions.Length; columnIndex++)
            _readActions[columnIndex].Read(_reader, row);
    }

}
