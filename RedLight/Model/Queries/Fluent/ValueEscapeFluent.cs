using System;
using System.Text.Json;
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

    public static string EscapeData<TEnum>(this ValueEscape escaping, TEnum columnName, object value)
        where TEnum : Enum
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

        return EscapeSpecialData(escaping, columnName, value);
    }

    private static string EscapeSpecialData<TEnum>(ValueEscape escaping, TEnum columnName, object value)
        where TEnum : Enum
    {
        var table = TableGenerator.From<TEnum>();
        var column = table.FindColumn(columnName.ToString());

        if (value is IConvertible convertible)
            return EscapeData(escaping, column.Type, convertible);
        else if (value is JsonElement jsonElement)
            return EscapeData(escaping, column.Type, jsonElement);

        throw new NotSupportedException(value.GetType().FullName);
    }
#pragma warning restore IDE0038 // Use pattern matching

    private static string EscapeData(ValueEscape escaping, ColumnType type, IConvertible value) => type switch
    {
        ColumnType.Boolean => escaping.Escape(value.ToBoolean(null)),
        ColumnType.Byte => escaping.Escape(value.ToByte(null)),
        ColumnType.Short => escaping.Escape(value.ToInt16(null)),
        ColumnType.Integer => escaping.Escape(value.ToInt32(null)),
        ColumnType.Long => escaping.Escape(value.ToInt64(null)),
        ColumnType.Float => escaping.Escape(value.ToSingle(null)),
        ColumnType.Double => escaping.Escape(value.ToDouble(null)),
        ColumnType.Decimal => escaping.Escape(value.ToDecimal(null)),
        ColumnType.String => escaping.Escape(value.ToString(null)),
        ColumnType.Guid => escaping.Escape(Guid.Parse(value.ToString(null))),
        ColumnType.DateTime => escaping.Escape(DateTime.Parse(value.ToString(null))),
        ColumnType.TimeSpan => escaping.Escape(TimeSpan.Parse(value.ToString(null))),
        ColumnType.ByteArray => escaping.Escape((byte[])value.ToType(typeof(byte[]), null)),
        _ => throw new NotSupportedException(value.GetType().FullName),
    };

    private static string EscapeData(ValueEscape escaping, ColumnType type, JsonElement value) => type switch
    {
        ColumnType.Boolean => escaping.Escape(value.GetBoolean()),
        ColumnType.Byte => escaping.Escape(value.GetByte()),
        ColumnType.Short => escaping.Escape(value.GetInt16()),
        ColumnType.Integer => escaping.Escape(value.GetInt32()),
        ColumnType.Long => escaping.Escape(value.GetInt64()),
        ColumnType.Float => escaping.Escape(value.GetSingle()),
        ColumnType.Double => escaping.Escape(value.GetDouble()),
        ColumnType.Decimal => escaping.Escape(value.GetDecimal()),
        ColumnType.String => escaping.Escape(value.GetString()),
        ColumnType.Guid => escaping.Escape(value.GetGuid()),
        ColumnType.DateTime => escaping.Escape(value.GetDateTime()),
        ColumnType.TimeSpan => escaping.Escape(TimeSpan.Parse(value.GetString())),
        ColumnType.ByteArray => escaping.Escape(value.GetBytesFromBase64()),
        _ => throw new NotSupportedException(value.GetType().FullName),
    };

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
        _ => throw new NotSupportedException(value?.GetType().FullName),
    };
}
