using System;

namespace RedLight;

internal static class ValueEscapeFluent
{
    public static string Escape(this ValueEscape escaping, Column valueColumn, object value) => valueColumn.Type switch
    {
        ColumnType.Boolean => escaping.Escape((bool)value),
        ColumnType.Byte => escaping.Escape((byte)value),
        ColumnType.Short => escaping.Escape((short)value),
        ColumnType.Integer => escaping.Escape((int)value),
        ColumnType.Long => escaping.Escape((long)value),
        ColumnType.Float => escaping.Escape((float)value),
        ColumnType.Double => escaping.Escape((double)value),
        ColumnType.Decimal => escaping.Escape((decimal)value),
        ColumnType.String => escaping.Escape((string)value),
        ColumnType.Guid => escaping.Escape((Guid)value),
        ColumnType.DateTime => escaping.Escape((DateTime)value),
        ColumnType.TimeSpan => escaping.Escape((TimeSpan)value),
        ColumnType.ByteArray => escaping.Escape((byte[])value),
        _ => throw new NotSupportedException(),
    };
}
