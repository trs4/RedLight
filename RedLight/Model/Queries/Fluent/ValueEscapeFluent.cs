using System;
using RedLight.Internal;

namespace RedLight;

internal static class ValueEscapeFluent
{
#pragma warning disable IDE0038 // Use pattern matching
    public static string EscapeData(this ValueEscape escaping, object value)
    {
        if (value is null)
            return Consts.Null;
        else if (value is bool)
            return escaping.Escape((bool)value);
        else if (value is byte)
            return escaping.Escape((byte)value);
        else if (value is short)
            return escaping.Escape((short)value);
        else if (value is int)
            return escaping.Escape((int)value);
        else if (value is long)
            return escaping.Escape((long)value);
        else if (value is float)
            return escaping.Escape((float)value);
        else if (value is double)
            return escaping.Escape((double)value);
        else if (value is decimal)
            return escaping.Escape((decimal)value);
        else if (value is string)
            return escaping.Escape((string)value);
        else if (value is DateTime)
            return escaping.Escape((DateTime)value);
        else if (value is TimeSpan)
            return escaping.Escape((TimeSpan)value);
        else if (value is Guid)
            return escaping.Escape((Guid)value);
        else if (value is byte[])
            return escaping.Escape((byte[])value);

        throw new NotSupportedException(value.GetType().FullName);
    }
#pragma warning restore IDE0038 // Use pattern matching

    public static string EscapeData(this ValueEscape escaping, Column valueColumn, object value) => valueColumn.Type switch
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
