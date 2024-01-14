using System;
using System.Collections.Generic;
using IcyRain.Tables;

namespace RedLight;

public static class DataValueQueryFluent
{
    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowIndex">Индекс строки</param>
    /// <param name="name">Имя поля</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, DataColumn dataColumn, int rowIndex, string name = null)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataColumn);
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), dataColumn, rowIndex));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowIndex">Индекс строки</param>
    /// <param name="name">Имя поля</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, DataColumn dataColumn, int rowIndex, TEnum name)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataColumn);
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), dataColumn, rowIndex));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    /// <param name="rowIndex">Индекс строки</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable, int rowIndex)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);

        foreach (var pair in dataTable)
            query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(pair.Key), pair.Value, rowIndex));

        return query;
    }

    private static ValueColumn CreateColumn(string name, DataColumn dataColumn, int rowIndex)
    {
        if (dataColumn.IsArray)
            return CreateArrayColumnCore(name, dataColumn, rowIndex);
        else if (dataColumn.IsNullable)
            return CreateNullableColumnCore(name, dataColumn, rowIndex);
        else
            return CreateColumnCore(name, dataColumn, rowIndex);
    }

    private static ValueColumn CreateColumnCore(string name, DataColumn dataColumn, int rowIndex) => dataColumn.Type switch
    {
        DataType.Boolean => new BoolValueColumn(name, ((BooleanDataColumn)dataColumn).Get(rowIndex)),
        DataType.Byte => new ByteValueColumn(name, ((ByteDataColumn)dataColumn).Get(rowIndex)),
        DataType.Int16 => new ShortValueColumn(name, ((Int16DataColumn)dataColumn).Get(rowIndex)),
        DataType.Int32 => new IntValueColumn(name, ((Int32DataColumn)dataColumn).Get(rowIndex)),
        DataType.Int64 => new LongValueColumn(name, ((Int64DataColumn)dataColumn).Get(rowIndex)),
        DataType.Single => new FloatValueColumn(name, ((SingleDataColumn)dataColumn).Get(rowIndex)),
        DataType.Double => new DoubleValueColumn(name, ((DoubleDataColumn)dataColumn).Get(rowIndex)),
        DataType.Decimal => new DecimalValueColumn(name, ((DecimalDataColumn)dataColumn).Get(rowIndex)),
        DataType.String => new StringValueColumn(name, ((StringDataColumn)dataColumn).Get(rowIndex)),
        DataType.DateTime => new DateTimeValueColumn(name, ((DateTimeDataColumn)dataColumn).Get(rowIndex)),
        DataType.Guid => new GuidValueColumn(name, ((GuidDataColumn)dataColumn).Get(rowIndex)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

    private static ValueColumn CreateNullableColumnCore(string name, DataColumn dataColumn, int rowIndex) => dataColumn.Type switch
    {
        DataType.Boolean => new NullableBoolValueColumn(name, ((NullableBooleanDataColumn)dataColumn).Get(rowIndex)),
        DataType.Byte => new NullableByteValueColumn(name, ((NullableByteDataColumn)dataColumn).Get(rowIndex)),
        DataType.Int16 => new NullableShortValueColumn(name, ((NullableInt16DataColumn)dataColumn).Get(rowIndex)),
        DataType.Int32 => new NullableIntValueColumn(name, ((NullableInt32DataColumn)dataColumn).Get(rowIndex)),
        DataType.Int64 => new NullableLongValueColumn(name, ((NullableInt64DataColumn)dataColumn).Get(rowIndex)),
        DataType.Single => new NullableFloatValueColumn(name, ((NullableSingleDataColumn)dataColumn).Get(rowIndex)),
        DataType.Double => new NullableDoubleValueColumn(name, ((NullableDoubleDataColumn)dataColumn).Get(rowIndex)),
        DataType.Decimal => new NullableDecimalValueColumn(name, ((NullableDecimalDataColumn)dataColumn).Get(rowIndex)),
        DataType.String => new StringValueColumn(name, ((NullableStringDataColumn)dataColumn).Get(rowIndex)),
        DataType.DateTime => new NullableDateTimeValueColumn(name, ((NullableDateTimeDataColumn)dataColumn).Get(rowIndex)),
        DataType.Guid => new NullableGuidValueColumn(name, ((NullableGuidDataColumn)dataColumn).Get(rowIndex)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private static ValueColumn CreateArrayColumnCore(string name, DataColumn dataColumn, int rowIndex)
    {
        if (dataColumn.Type == DataType.Byte)
            return new ByteArrayValueColumn(name, ((ByteArrayDataColumn)dataColumn).Get(rowIndex));

        throw new NotSupportedException(dataColumn.GetType().FullName);
    }
#pragma warning restore CA1859 // Use concrete types when possible for improved performance

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, object value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет список полей добавления данных</summary>
    /// <param name="values">Список полей со значениями</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, Dictionary<string, object> values)
        where TQuery : ValueQuery
    {
        foreach (var pair in values)
            query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(pair.Key), pair.Value));

        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, object value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="escapedValue">Выражение</param>
    public static TQuery AddRawValueColumn<TQuery>(this TQuery query, string name, string escapedValue)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new RawValueColumn(query.Connection.Naming.GetName(name), escapedValue));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="escapedValue">Выражение</param>
    public static TQuery AddRawValueColumn<TQuery, TEnum>(this TQuery query, TEnum name, string escapedValue)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new RawValueColumn(query.Connection.Naming.GetName(name), escapedValue));
        return query;
    }

    private static ValueColumn CreateColumn(string name, object value)
    {
        if (value is null)
            return new NullValueColumn(name);
        else if (value is bool boolValue)
            return new BoolValueColumn(name, boolValue);
        else if (value is byte byteValue)
            return new ByteValueColumn(name, byteValue);
        else if (value is short shortValue)
            return new ShortValueColumn(name, shortValue);
        else if (value is int intValue)
            return new IntValueColumn(name, intValue);
        else if (value is long longValue)
            return new LongValueColumn(name, longValue);
        else if (value is float floatValue)
            return new FloatValueColumn(name, floatValue);
        else if (value is double doubleValue)
            return new DoubleValueColumn(name, doubleValue);
        else if (value is decimal decimalValue)
            return new DecimalValueColumn(name, decimalValue);
        else if (value is string stringValue)
            return new StringValueColumn(name, stringValue);
        else if (value is DateTime dateTimeValue)
            return new DateTimeValueColumn(name, dateTimeValue);
        else if (value is Guid guidValue)
            return new GuidValueColumn(name, guidValue);
        else if (value is byte[] byteArrayValue)
            return new ByteArrayValueColumn(name, byteArrayValue);

        throw new NotSupportedException(value.GetType().FullName);
    }

}
