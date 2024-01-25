using System;
using IcyRain.Tables;

namespace RedLight;

/// <summary>Расширения для колонки</summary>
public static class ColumnExtensions
{
    /// <summary>Получить тип колонки</summary>
    /// <param name="column">Колонка</param>
    public static (DataType type, bool nullable, bool isArray) GetDataType(this Column column)
    {
        if (column.Nullable)
        {
            return column.Type switch
            {
                ColumnType.Boolean => (DataType.Boolean, true, false),
                ColumnType.Byte => (DataType.Byte, true, false),
                ColumnType.Short => (DataType.Int16, true, false),
                ColumnType.Integer => (DataType.Int32, true, false),
                ColumnType.Long => (DataType.Int64, true, false),
                ColumnType.Float => (DataType.Single, true, false),
                ColumnType.Double => (DataType.Double, true, false),
                ColumnType.Decimal => (DataType.Decimal, true, false),
                ColumnType.String => (DataType.String, true, false),
                ColumnType.Guid => (DataType.Guid, true, false),
                ColumnType.DateTime => (DataType.DateTime, true, false),
                ColumnType.TimeSpan => (DataType.TimeSpan, true, false),
                _ => throw new NotSupportedException(column.Type.ToString()),
            };
        }

        return column.Type switch
        {
            ColumnType.Boolean => (DataType.Boolean, false, false),
            ColumnType.Byte => (DataType.Byte, false, false),
            ColumnType.Short => (DataType.Int16, false, false),
            ColumnType.Integer => (DataType.Int32, false, false),
            ColumnType.Long => (DataType.Int64, false, false),
            ColumnType.Float => (DataType.Single, false, false),
            ColumnType.Double => (DataType.Double, false, false),
            ColumnType.Decimal => (DataType.Decimal, false, false),
            ColumnType.String => (DataType.String, false, false),
            ColumnType.Guid => (DataType.Guid, false, false),
            ColumnType.DateTime => (DataType.DateTime, false, false),
            ColumnType.TimeSpan => (DataType.TimeSpan, false, false),
            ColumnType.ByteArray => (DataType.Byte, false, true),
            _ => throw new NotSupportedException(column.Type.ToString()),
        };
    }

}
