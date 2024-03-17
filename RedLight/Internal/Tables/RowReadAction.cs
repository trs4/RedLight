using System;
using System.Collections.Generic;
using System.Data.Common;
using IcyRain.Tables;

namespace RedLight.Internal;

public sealed class RowReadAction
{
    private readonly static Dictionary<Type, Func<DatabaseConnection, DataTable, int, string, ColumnReadAction>> _columns = new()
    {
        { typeof(bool), (connection, dataTable, index, name) => new ColumnReadActionBool(connection, dataTable, index, name) },
        { typeof(byte), (connection, dataTable, index, name) => new ColumnReadActionByte(connection, dataTable, index, name) },
        { typeof(short), (connection, dataTable, index, name) => new ColumnReadActionShort(connection, dataTable, index, name) },
        { typeof(int), (connection, dataTable, index, name) => new ColumnReadActionInt(connection, dataTable, index, name) },
        { typeof(long), (connection, dataTable, index, name) => new ColumnReadActionLong(connection, dataTable, index, name) },
        { typeof(float), (connection, dataTable, index, name) => new ColumnReadActionFloat(connection, dataTable, index, name) },
        { typeof(double), (connection, dataTable, index, name) => new ColumnReadActionDouble(connection, dataTable, index, name) },
        { typeof(decimal), (connection, dataTable, index, name) => new ColumnReadActionDecimal(connection, dataTable, index, name) },
        { typeof(string), (connection, dataTable, index, name) => new ColumnReadActionString(connection, dataTable, index, name) },
        { typeof(DateTime), (connection, dataTable, index, name) => new ColumnReadActionDateTime(connection, dataTable, index, name) },
        { typeof(Guid), (connection, dataTable, index, name) => new ColumnReadActionGuid(connection, dataTable, index, name) },
        { typeof(byte[]), (connection, dataTable, index, name) => new ColumnReadActionByteArray(connection, dataTable, index, name) },
    };

    private readonly static Dictionary<Type, Func<DatabaseConnection, DataTable, int, string, ColumnReadAction>> _nullableColumns = new()
    {
        { typeof(bool), (connection, dataTable, index, name) => new ColumnReadActionNullableBool(connection, dataTable, index, name) },
        { typeof(byte), (connection, dataTable, index, name) => new ColumnReadActionNullableByte(connection, dataTable, index, name) },
        { typeof(short), (connection, dataTable, index, name) => new ColumnReadActionNullableShort(connection, dataTable, index, name) },
        { typeof(int), (connection, dataTable, index, name) => new ColumnReadActionNullableInt(connection, dataTable, index, name) },
        { typeof(long), (connection, dataTable, index, name) => new ColumnReadActionNullableLong(connection, dataTable, index, name) },
        { typeof(float), (connection, dataTable, index, name) => new ColumnReadActionNullableFloat(connection, dataTable, index, name) },
        { typeof(double), (connection, dataTable, index, name) => new ColumnReadActionNullableDouble(connection, dataTable, index, name) },
        { typeof(decimal), (connection, dataTable, index, name) => new ColumnReadActionNullableDecimal(connection, dataTable, index, name) },
        { typeof(string), (connection, dataTable, index, name) => new ColumnReadActionNullableString(connection, dataTable, index, name) },
        { typeof(DateTime), (connection, dataTable, index, name) => new ColumnReadActionNullableDateTime(connection, dataTable, index, name) },
        { typeof(Guid), (connection, dataTable, index, name) => new ColumnReadActionNullableGuid(connection, dataTable, index, name) },
    };

    private readonly DataTable _dataTable;
    private readonly DbDataReader _reader;
    private readonly ColumnReadAction[] _readActions;

    public RowReadAction(DatabaseConnection connection, DataTable dataTable, DbDataReader reader)
    {
        _dataTable = dataTable ?? throw new ArgumentNullException(nameof(dataTable));
        _reader = reader ?? throw new ArgumentNullException(nameof(reader));
        _readActions = new ColumnReadAction[reader.FieldCount];
        var schema = reader.GetSchemaTable();

        for (int row = 0; row < schema.Rows.Count; row++)
        {
            var dataRow = schema.Rows[row];
            string columnName = dataRow["ColumnName"] as string;
            var columnType = dataRow["DataType"] as Type;
            bool nullable = dataRow["AllowDBNull"] is bool boolValue && boolValue;

            if (nullable)
            {
                if (_nullableColumns.TryGetValue(columnType, out var columnFunc))
                    _readActions[row] = columnFunc(connection, dataTable, row, columnName);
                else
                    throw new InvalidOperationException($"{columnName}: {columnType.FullName}");
            }
            else
            {
                if (_columns.TryGetValue(columnType, out var columnFunc))
                    _readActions[row] = columnFunc(connection, dataTable, row, columnName);
                else
                    throw new InvalidOperationException($"{columnName}: {columnType.FullName}");
            }
        }
    }

    public void Read()
    {
        int row = _dataTable.RowCount++;

        for (int i = 0; i < _readActions.Length; i++)
            _readActions[i].Read(_reader, row);
    }

}
