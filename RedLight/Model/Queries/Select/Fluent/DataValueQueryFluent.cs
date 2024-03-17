using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using IcyRain.Tables;
using RedLight.Internal;

namespace RedLight;

public static class DataValueQueryFluent
{
    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="column">Столбец</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, Column column, object value)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(column);

        if (!_columnByDataType.TryGetValue(Extensions.GetHash(column), out var func))
            throw new NotSupportedException(column.GetType().FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(column.Name), value));
        return query;
    }


    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="columnType">Тип столбца</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, Type columnType, object value)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(columnType);

        if (!_columnByType.TryGetValue(columnType, out var func))
            throw new NotSupportedException(columnType.FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="columnType">Тип столбца</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, Type columnType, object value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(columnType);

        if (!_columnByType.TryGetValue(columnType, out var func))
            throw new NotSupportedException(columnType.FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), value));
        return query;
    }


    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    /// <param name="name">Имя поля</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, DataColumn dataColumn, int row, string name = null)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataColumn);

        if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
            throw new NotSupportedException(dataColumn.GetType().FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), dataColumn, row));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    /// <param name="name">Имя поля</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, DataColumn dataColumn, int row, TEnum name)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataColumn);

        if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
            throw new NotSupportedException(dataColumn.GetType().FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), dataColumn, row));
        return query;
    }


    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    /// <param name="row">Индекс строки</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable, int row)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);

        foreach (var pair in dataTable)
        {
            var dataColumn = pair.Value;

            if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
                throw new NotSupportedException(dataColumn.GetType().FullName);

            query.AddColumnCore(func(query.Connection.Naming.GetName(pair.Key), dataColumn, row));
        }

        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    /// <param name="row">Индекс строки</param>
    /// <param name="excludedColumnName">Исключаемый столбец</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable, int row, string excludedColumnName)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        ArgumentNullException.ThrowIfNull(excludedColumnName);

        foreach (var pair in dataTable)
        {
            if (pair.Key.Equals(excludedColumnName, StringComparison.OrdinalIgnoreCase))
                continue;

            var dataColumn = pair.Value;

            if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
                throw new NotSupportedException(dataColumn.GetType().FullName);

            query.AddColumnCore(func(query.Connection.Naming.GetName(pair.Key), dataColumn, row));
        }

        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    /// <param name="row">Индекс строки</param>
    /// <param name="excludedColumnNames">Исключить колонки</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable, int row, HashSet<string> excludedColumnNames)
        where TQuery : ValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);

        if (excludedColumnNames is null || excludedColumnNames.Count == 0)
            return query.AddColumns(dataTable, row);

        foreach (var pair in dataTable)
        {
            if (excludedColumnNames.Contains(pair.Key))
                continue;

            var dataColumn = pair.Value;

            if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
                throw new NotSupportedException(dataColumn.GetType().FullName);

            query.AddColumnCore(func(query.Connection.Naming.GetName(pair.Key), dataColumn, row));
        }

        return query;
    }


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

    #region Internal

    private static readonly FrozenDictionary<int, Func<string, object, ValueColumn>> _columnByDataType
        = new Dictionary<int, Func<string, object, ValueColumn>>()
        {
            { Extensions.GetHash(DataType.Boolean), (name, value) => new BoolValueColumn(name, (bool)value) },
            { Extensions.GetHash(DataType.Boolean, isNullable: true), (name, value) => new NullableBoolValueColumn(name, (bool?)value) },
            { Extensions.GetHash(DataType.Char), (name, value) => new CharValueColumn(name, (char)value) },
            { Extensions.GetHash(DataType.Char, isNullable: true), (name, value) => new NullableCharValueColumn(name, (char?)value) },
            { Extensions.GetHash(DataType.SByte), (name, value) => new SByteValueColumn(name, (sbyte)value) },
            { Extensions.GetHash(DataType.SByte, isNullable: true), (name, value) => new NullableSByteValueColumn(name, (sbyte?)value) },
            { Extensions.GetHash(DataType.Byte), (name, value) => new ByteValueColumn(name, (byte)value) },
            { Extensions.GetHash(DataType.Byte, isNullable: true), (name, value) => new NullableByteValueColumn(name, (byte?)value) },
            { Extensions.GetHash(DataType.Byte, isArray: true), (name, value) => new ByteArrayValueColumn(name, (byte[])value) },
            { Extensions.GetHash(DataType.Int16), (name, value) => new ShortValueColumn(name, (short)value) },
            { Extensions.GetHash(DataType.Int16, isNullable: true), (name, value) => new NullableShortValueColumn(name, (short?)value) },
            { Extensions.GetHash(DataType.UInt16), (name, value) => new UShortValueColumn(name, (ushort)value) },
            { Extensions.GetHash(DataType.UInt16, isNullable: true), (name, value) => new NullableUShortValueColumn(name, (ushort?)value) },
            { Extensions.GetHash(DataType.Int32), (name, value) => new IntValueColumn(name, (int)value) },
            { Extensions.GetHash(DataType.Int32, isNullable: true), (name, value) => new NullableIntValueColumn(name, (int?)value) },
            { Extensions.GetHash(DataType.UInt32), (name, value) => new UIntValueColumn(name, (uint)value) },
            { Extensions.GetHash(DataType.UInt32, isNullable: true), (name, value) => new NullableUIntValueColumn(name, (uint?)value) },
            { Extensions.GetHash(DataType.Int64), (name, value) => new LongValueColumn(name, (long)value) },
            { Extensions.GetHash(DataType.Int64, isNullable: true), (name, value) => new NullableLongValueColumn(name, (long?)value) },
            { Extensions.GetHash(DataType.UInt64), (name, value) => new ULongValueColumn(name, (ulong)value) },
            { Extensions.GetHash(DataType.UInt64, isNullable: true), (name, value) => new NullableULongValueColumn(name, (ulong?)value) },
            { Extensions.GetHash(DataType.Single), (name, value) => new FloatValueColumn(name, (float)value) },
            { Extensions.GetHash(DataType.Single, isNullable: true), (name, value) => new NullableFloatValueColumn(name, (float?)value) },
            { Extensions.GetHash(DataType.Double), (name, value) => new DoubleValueColumn(name, (double)value) },
            { Extensions.GetHash(DataType.Double, isNullable: true), (name, value) => new NullableDoubleValueColumn(name, (double?)value) },
            { Extensions.GetHash(DataType.Decimal), (name, value) => new DecimalValueColumn(name, (decimal)value) },
            { Extensions.GetHash(DataType.Decimal, isNullable: true), (name, value) => new NullableDecimalValueColumn(name, (decimal?)value) },
            { Extensions.GetHash(DataType.String), (name, value) => new StringValueColumn(name, (string)value ?? string.Empty) },
            { Extensions.GetHash(DataType.String, isNullable: true), (name, value) => new StringValueColumn(name, (string)value) },
            { Extensions.GetHash(DataType.Guid), (name, value) => new GuidValueColumn(name, (Guid)value) },
            { Extensions.GetHash(DataType.Guid, isNullable: true), (name, value) => new NullableGuidValueColumn(name, (Guid?)value) },
            { Extensions.GetHash(DataType.DateTime), (name, value) => new DateTimeValueColumn(name, (DateTime)value) },
            { Extensions.GetHash(DataType.DateTime, isNullable: true), (name, value) => new NullableDateTimeValueColumn(name, (DateTime?)value) },
            { Extensions.GetHash(DataType.TimeSpan), (name, value) => new TimeSpanValueColumn(name, (TimeSpan)value) },
            { Extensions.GetHash(DataType.TimeSpan, isNullable: true), (name, value) => new NullableTimeSpanValueColumn(name, (TimeSpan?)value) },
        }.ToFrozenDictionary();

    private static readonly FrozenDictionary<Type, Func<string, object, ValueColumn>> _columnByType
        = new Dictionary<Type, Func<string, object, ValueColumn>>()
        {
            { typeof(bool), (name, value) => new BoolValueColumn(name, (bool)value) },
            { typeof(bool?), (name, value) => new NullableBoolValueColumn(name, (bool?)value) },
            { typeof(char), (name, value) => new CharValueColumn(name, (char)value) },
            { typeof(char?), (name, value) => new NullableCharValueColumn(name, (char?)value) },
            { typeof(sbyte), (name, value) => new SByteValueColumn(name, (sbyte)value) },
            { typeof(sbyte?), (name, value) => new NullableSByteValueColumn(name, (sbyte?)value) },
            { typeof(byte), (name, value) => new ByteValueColumn(name, (byte)value) },
            { typeof(byte?), (name, value) => new NullableByteValueColumn(name, (byte?)value) },
            { typeof(byte[]), (name, value) => new ByteArrayValueColumn(name, (byte[])value) },
            { typeof(short), (name, value) => new ShortValueColumn(name, (short)value) },
            { typeof(short?), (name, value) => new NullableShortValueColumn(name, (short?)value) },
            { typeof(ushort), (name, value) => new UShortValueColumn(name, (ushort)value) },
            { typeof(ushort?), (name, value) => new NullableUShortValueColumn(name, (ushort?)value) },
            { typeof(int), (name, value) => new IntValueColumn(name, (int)value) },
            { typeof(int?), (name, value) => new NullableIntValueColumn(name, (int?)value) },
            { typeof(uint), (name, value) => new UIntValueColumn(name, (uint)value) },
            { typeof(uint?), (name, value) => new NullableUIntValueColumn(name, (uint?)value) },
            { typeof(long), (name, value) => new LongValueColumn(name, (long)value) },
            { typeof(long?), (name, value) => new NullableLongValueColumn(name, (long?)value) },
            { typeof(ulong), (name, value) => new ULongValueColumn(name, (ulong)value) },
            { typeof(ulong?), (name, value) => new NullableULongValueColumn(name, (ulong?)value) },
            { typeof(float), (name, value) => new FloatValueColumn(name, (float)value) },
            { typeof(float?), (name, value) => new NullableFloatValueColumn(name, (float?)value) },
            { typeof(double), (name, value) => new DoubleValueColumn(name, (double)value) },
            { typeof(double?), (name, value) => new NullableDoubleValueColumn(name, (double?)value) },
            { typeof(decimal), (name, value) => new DecimalValueColumn(name, (decimal)value) },
            { typeof(decimal?), (name, value) => new NullableDecimalValueColumn(name, (decimal?)value) },
            { typeof(string), (name, value) => new StringValueColumn(name, (string)value) },
            { typeof(Guid), (name, value) => new GuidValueColumn(name, (Guid)value) },
            { typeof(Guid?), (name, value) => new NullableGuidValueColumn(name, (Guid?)value) },
            { typeof(DateTime), (name, value) => new DateTimeValueColumn(name, (DateTime)value) },
            { typeof(DateTime?), (name, value) => new NullableDateTimeValueColumn(name, (DateTime?)value) },
            { typeof(TimeSpan), (name, value) => new TimeSpanValueColumn(name, (TimeSpan)value) },
            { typeof(TimeSpan?), (name, value) => new NullableTimeSpanValueColumn(name, (TimeSpan?)value) },
        }.ToFrozenDictionary();

    private static readonly FrozenDictionary<int, Func<string, DataColumn, int, ValueColumn>> _readFromColumns
        = new Dictionary<int, Func<string, DataColumn, int, ValueColumn>>()
        {
            {
                Extensions.GetHash(DataType.Boolean),
                (name, dataColumn, row) => new BoolValueColumn(name, ((BooleanDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Boolean, isNullable: true),
                (name, dataColumn, row) => new NullableBoolValueColumn(name, ((NullableBooleanDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Char),
                (name, dataColumn, row) => new CharValueColumn(name, ((CharDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Char, isNullable: true),
                (name, dataColumn, row) => new NullableCharValueColumn(name, ((NullableCharDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.SByte),
                (name, dataColumn, row) => new SByteValueColumn(name, ((SByteDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.SByte, isNullable: true),
                (name, dataColumn, row) => new NullableSByteValueColumn(name, ((NullableSByteDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Byte),
                (name, dataColumn, row) => new ByteValueColumn(name, ((ByteDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Byte, isNullable: true),
                (name, dataColumn, row) => new NullableByteValueColumn(name, ((NullableByteDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Byte, isArray: true),
                (name, dataColumn, row) => new ByteArrayValueColumn(name,((ByteArrayDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Int16),
                (name, dataColumn, row) => new ShortValueColumn(name,((Int16DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Int16, isNullable: true),
                (name, dataColumn, row) => new NullableShortValueColumn(name,((NullableInt16DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.UInt16),
                (name, dataColumn, row) => new UShortValueColumn(name,((UInt16DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.UInt16, isNullable: true),
                (name, dataColumn, row) => new NullableUShortValueColumn(name,((NullableUInt16DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Int32),
                (name, dataColumn, row) => new IntValueColumn(name,((Int32DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Int32, isNullable: true),
                (name, dataColumn, row) => new NullableIntValueColumn(name,((NullableInt32DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.UInt32),
                (name, dataColumn, row) => new UIntValueColumn(name,((UInt32DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.UInt32, isNullable: true),
                (name, dataColumn, row) => new NullableUIntValueColumn(name,((NullableUInt32DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Int64),
                (name, dataColumn, row) => new LongValueColumn(name,((Int64DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Int64, isNullable: true),
                (name, dataColumn, row) => new NullableLongValueColumn(name,((NullableInt64DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.UInt64),
                (name, dataColumn, row) => new ULongValueColumn(name,((UInt64DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.UInt64, isNullable: true),
                (name, dataColumn, row) => new NullableULongValueColumn(name,((NullableUInt64DataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Single),
                (name, dataColumn, row) => new FloatValueColumn(name,((SingleDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Single, isNullable: true),
                (name, dataColumn, row) => new NullableFloatValueColumn(name,((NullableSingleDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Double),
                (name, dataColumn, row) => new DoubleValueColumn(name,((DoubleDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Double, isNullable: true),
                (name, dataColumn, row) => new NullableDoubleValueColumn(name,((NullableDoubleDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Decimal),
                (name, dataColumn, row) => new DecimalValueColumn(name,((DecimalDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Decimal, isNullable: true),
                (name, dataColumn, row) => new NullableDecimalValueColumn(name,((NullableDecimalDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.String),
                (name, dataColumn, row) => new StringValueColumn(name,((StringDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.String, isNullable: true),
                (name, dataColumn, row) => new StringValueColumn(name,((NullableStringDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Guid),
                (name, dataColumn, row) => new GuidValueColumn(name,((GuidDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.Guid, isNullable: true),
                (name, dataColumn, row) => new NullableGuidValueColumn(name,((NullableGuidDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.DateTime),
                (name, dataColumn, row) => new DateTimeValueColumn(name,((DateTimeDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.DateTime, isNullable: true),
                (name, dataColumn, row) => new NullableDateTimeValueColumn(name,((NullableDateTimeDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.TimeSpan),
                (name, dataColumn, row) => new TimeSpanValueColumn(name,((TimeSpanDataColumn)dataColumn).Get(row))
            },
            {
                Extensions.GetHash(DataType.TimeSpan, isNullable: true),
                (name, dataColumn, row) => new NullableTimeSpanValueColumn(name,((NullableTimeSpanDataColumn)dataColumn).Get(row))
            },
        }.ToFrozenDictionary();

#pragma warning disable IDE0038 // Use pattern matching
    private static ValueColumn CreateColumn(string name, object value)
    {
        if (value is null)
            return new NullValueColumn(name);
        else if (value is bool)
            return new BoolValueColumn(name, (bool)value);
        else if (value is char)
            return new CharValueColumn(name, (char)value);
        else if (value is sbyte)
            return new SByteValueColumn(name, (sbyte)value);
        else if (value is byte)
            return new ByteValueColumn(name, (byte)value);
        else if (value is byte[])
            return new ByteArrayValueColumn(name, (byte[])value);
        else if (value is short)
            return new ShortValueColumn(name, (short)value);
        else if (value is ushort)
            return new UShortValueColumn(name, (ushort)value);
        else if (value is int)
            return new IntValueColumn(name, (int)value);
        else if (value is uint)
            return new UIntValueColumn(name, (uint)value);
        else if (value is long)
            return new LongValueColumn(name, (long)value);
        else if (value is ulong)
            return new ULongValueColumn(name, (ulong)value);
        else if (value is float)
            return new FloatValueColumn(name, (float)value);
        else if (value is double)
            return new DoubleValueColumn(name, (double)value);
        else if (value is decimal)
            return new DecimalValueColumn(name, (decimal)value);
        else if (value is string)
            return new StringValueColumn(name, (string)value);
        else if (value is Guid)
            return new GuidValueColumn(name, (Guid)value);
        else if (value is DateTime)
            return new DateTimeValueColumn(name, (DateTime)value);
        else if (value is TimeSpan)
            return new TimeSpanValueColumn(name, (TimeSpan)value);

        throw new NotSupportedException(value.GetType().FullName);
    }
#pragma warning restore IDE0038 // Use pattern matching

    #endregion
}
