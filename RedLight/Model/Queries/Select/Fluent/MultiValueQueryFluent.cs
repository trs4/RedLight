using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;
using IcyRain.Tables;
using RedLight.Internal;

namespace RedLight;

public static class MultiValueQueryFluent
{
    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="column">Столбец</param>
    /// <param name="value">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, Column column, ICollection value)
        where TQuery : MultiValueQuery
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
    /// <param name="value">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, Type columnType, ICollection value)
        where TQuery : MultiValueQuery
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
    /// <param name="value">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, Type columnType, ICollection value)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(columnType);

        if (!_columnByType.TryGetValue(columnType, out var func))
            throw new NotSupportedException(columnType.FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), value));
        return query;
    }


    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, DataColumn dataColumn, int rowCount)
        where TQuery : MultiValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataColumn);

        if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
            throw new NotSupportedException(dataColumn.GetType().FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), dataColumn, rowCount));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, DataColumn dataColumn, int rowCount)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataColumn);

        if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
            throw new NotSupportedException(dataColumn.GetType().FullName);

        query.AddColumnCore(func(query.Connection.Naming.GetName(name), dataColumn, rowCount));
        return query;
    }


    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable)
        where TQuery : MultiValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);

        foreach (var pair in dataTable)
        {
            var dataColumn = pair.Value;

            if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
                throw new NotSupportedException(dataColumn.GetType().FullName);

            query.AddColumnCore(func(query.Connection.Naming.GetName(pair.Key), dataColumn, dataTable.RowCount));
        }

        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    /// <param name="excludedColumnName">Исключаемый столбец</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable, string excludedColumnName)
        where TQuery : MultiValueQuery
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

            query.AddColumnCore(func(query.Connection.Naming.GetName(pair.Key), dataColumn, dataTable.RowCount));
        }

        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    /// <param name="excludedColumnNames">Исключить колонки</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable, HashSet<string> excludedColumnNames)
        where TQuery : MultiValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);

        if (excludedColumnNames?.Count == 0)
            return query.AddColumns(dataTable);

        foreach (var pair in dataTable)
        {
            if (excludedColumnNames.Contains(pair.Key))
                continue;

            var dataColumn = pair.Value;

            if (!_readFromColumns.TryGetValue(Extensions.GetHash(dataColumn), out var func))
                throw new NotSupportedException(dataColumn.GetType().FullName);

            query.AddColumnCore(func(query.Connection.Naming.GetName(pair.Key), dataColumn, dataTable.RowCount));
        }

        return query;
    }


    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<object> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<object> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="escapedValues">Выражения</param>
    public static TQuery AddRawColumn<TQuery>(this TQuery query, string name, IReadOnlyList<string> escapedValues)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new RawMultiValueColumn(query.Connection.Naming.GetName(name), escapedValues));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="escapedValues">Выражения</param>
    public static TQuery AddRawColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<string> escapedValues)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new RawMultiValueColumn(query.Connection.Naming.GetName(name), escapedValues));
        return query;
    }

    #region Internal

    private static readonly FrozenDictionary<int, Func<string, ICollection, MultiValueColumn>> _columnByDataType
        = new Dictionary<int, Func<string, ICollection, MultiValueColumn>>()
        {
            { Extensions.GetHash(DataType.Boolean), (name, value) => new BoolMultiValueColumn(name, (IReadOnlyList<bool>)value) },
            { Extensions.GetHash(DataType.Boolean, isNullable: true), (name, value) => new NullableBoolMultiValueColumn(name, (IReadOnlyList<bool?>)value) },
            { Extensions.GetHash(DataType.Byte), (name, value) => new ByteMultiValueColumn(name, (IReadOnlyList<byte>)value) },
            { Extensions.GetHash(DataType.Byte, isNullable: true), (name, value) => new NullableByteMultiValueColumn(name, (IReadOnlyList<byte?>)value) },
            { Extensions.GetHash(DataType.Byte, isArray: true), (name, value) => new ByteArrayMultiValueColumn(name, (IReadOnlyList<byte[]>)value) },
            { Extensions.GetHash(DataType.Int16), (name, value) => new ShortMultiValueColumn(name, (IReadOnlyList<short>)value) },
            { Extensions.GetHash(DataType.Int16, isNullable: true), (name, value) => new NullableShortMultiValueColumn(name, (IReadOnlyList<short?>)value) },
            { Extensions.GetHash(DataType.Int32), (name, value) => new IntMultiValueColumn(name, (IReadOnlyList<int>)value) },
            { Extensions.GetHash(DataType.Int32, isNullable: true), (name, value) => new NullableIntMultiValueColumn(name, (IReadOnlyList<int?>)value) },
            { Extensions.GetHash(DataType.Int64), (name, value) => new LongMultiValueColumn(name, (IReadOnlyList<long>)value) },
            { Extensions.GetHash(DataType.Int64, isNullable: true), (name, value) => new NullableLongMultiValueColumn(name, (IReadOnlyList<long?>)value) },
            { Extensions.GetHash(DataType.Single), (name, value) => new FloatMultiValueColumn(name, (IReadOnlyList<float>)value) },
            { Extensions.GetHash(DataType.Single, isNullable: true), (name, value) => new NullableFloatMultiValueColumn(name, (IReadOnlyList<float?>)value) },
            { Extensions.GetHash(DataType.Double), (name, value) => new DoubleMultiValueColumn(name, (IReadOnlyList<double>)value) },
            { Extensions.GetHash(DataType.Double, isNullable: true), (name, value) => new NullableDoubleMultiValueColumn(name, (IReadOnlyList<double?>)value) },
            { Extensions.GetHash(DataType.Decimal), (name, value) => new DecimalMultiValueColumn(name, (IReadOnlyList<decimal>)value) },
            { Extensions.GetHash(DataType.Decimal, isNullable: true), (name, value) => new NullableDecimalMultiValueColumn(name, (IReadOnlyList<decimal?>)value) },
            { Extensions.GetHash(DataType.String), (name, value) => new StringMultiValueColumn(name, Extensions.NotNull((IReadOnlyList<string>)value)) },
            { Extensions.GetHash(DataType.String, isNullable: true), (name, value) => new StringMultiValueColumn(name, (IReadOnlyList<string>)value) },
            { Extensions.GetHash(DataType.DateTime), (name, value) => new DateTimeMultiValueColumn(name, (IReadOnlyList<DateTime>)value) },
            { Extensions.GetHash(DataType.DateTime, isNullable: true), (name, value) => new NullableDateTimeMultiValueColumn(name, (IReadOnlyList<DateTime?>)value) },
            { Extensions.GetHash(DataType.TimeSpan), (name, value) => new TimeSpanMultiValueColumn(name, (IReadOnlyList<TimeSpan>)value) },
            { Extensions.GetHash(DataType.TimeSpan, isNullable: true), (name, value) => new NullableTimeSpanMultiValueColumn(name, (IReadOnlyList<TimeSpan?>)value) },
            { Extensions.GetHash(DataType.Guid), (name, value) => new GuidMultiValueColumn(name, (IReadOnlyList<Guid>)value) },
            { Extensions.GetHash(DataType.Guid, isNullable: true), (name, value) => new NullableGuidMultiValueColumn(name, (IReadOnlyList<Guid?>)value) },
        }.ToFrozenDictionary();

    private static readonly FrozenDictionary<Type, Func<string, ICollection, MultiValueColumn>> _columnByType
        = new Dictionary<Type, Func<string, ICollection, MultiValueColumn>>()
        {
            { typeof(bool), (name, value) => new BoolMultiValueColumn(name, (IReadOnlyList<bool>)value) },
            { typeof(bool?), (name, value) => new NullableBoolMultiValueColumn(name, (IReadOnlyList<bool?>)value) },
            { typeof(byte), (name, value) => new ByteMultiValueColumn(name, (IReadOnlyList<byte>)value) },
            { typeof(byte?), (name, value) => new NullableByteMultiValueColumn(name, (IReadOnlyList<byte?>)value) },
            { typeof(byte[]), (name, value) => new ByteArrayMultiValueColumn(name, (IReadOnlyList<byte[]>)value) },
            { typeof(short), (name, value) => new ShortMultiValueColumn(name, (IReadOnlyList<short>)value) },
            { typeof(short?), (name, value) => new NullableShortMultiValueColumn(name, (IReadOnlyList<short?>)value) },
            { typeof(int), (name, value) => new IntMultiValueColumn(name, (IReadOnlyList<int>)value) },
            { typeof(int?), (name, value) => new NullableIntMultiValueColumn(name, (IReadOnlyList<int?>)value) },
            { typeof(long), (name, value) => new LongMultiValueColumn(name, (IReadOnlyList<long>)value) },
            { typeof(long?), (name, value) => new NullableLongMultiValueColumn(name, (IReadOnlyList<long?>)value) },
            { typeof(float), (name, value) => new FloatMultiValueColumn(name, (IReadOnlyList<float>)value) },
            { typeof(float?), (name, value) => new NullableFloatMultiValueColumn(name, (IReadOnlyList<float?>)value) },
            { typeof(double), (name, value) => new DoubleMultiValueColumn(name, (IReadOnlyList<double>)value) },
            { typeof(double?), (name, value) => new NullableDoubleMultiValueColumn(name, (IReadOnlyList<double?>)value) },
            { typeof(decimal), (name, value) => new DecimalMultiValueColumn(name, (IReadOnlyList<decimal>)value) },
            { typeof(decimal?), (name, value) => new NullableDecimalMultiValueColumn(name, (IReadOnlyList<decimal?>)value) },
            { typeof(string), (name, value) => new StringMultiValueColumn(name, (IReadOnlyList<string>)value) },
            { typeof(DateTime), (name, value) => new DateTimeMultiValueColumn(name, (IReadOnlyList<DateTime>)value) },
            { typeof(DateTime?), (name, value) => new NullableDateTimeMultiValueColumn(name, (IReadOnlyList<DateTime?>)value) },
            { typeof(TimeSpan), (name, value) => new TimeSpanMultiValueColumn(name, (IReadOnlyList<TimeSpan>)value) },
            { typeof(TimeSpan?), (name, value) => new NullableTimeSpanMultiValueColumn(name, (IReadOnlyList<TimeSpan?>)value) },
            { typeof(Guid), (name, value) => new GuidMultiValueColumn(name, (IReadOnlyList<Guid>)value) },
            { typeof(Guid?), (name, value) => new NullableGuidMultiValueColumn(name, (IReadOnlyList<Guid?>)value) },
        }.ToFrozenDictionary();

    private static readonly FrozenDictionary<int, Func<string, DataColumn, int, MultiValueColumn>> _readFromColumns
        = new Dictionary<int, Func<string, DataColumn, int, MultiValueColumn>>()
        {
            {
                Extensions.GetHash(DataType.Boolean),
                (name, dataColumn, rowCount) => new BoolMultiValueColumn(name, ((BooleanDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Boolean, isNullable: true),
                (name, dataColumn, rowCount) => new NullableBoolMultiValueColumn(name, ((NullableBooleanDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Byte),
                (name, dataColumn, rowCount) => new ByteMultiValueColumn(name, ((ByteDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Byte, isNullable: true),
                (name, dataColumn, rowCount) => new NullableByteMultiValueColumn(name, ((NullableByteDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Byte, isArray: true),
                (name, dataColumn, rowCount) => new ByteArrayMultiValueColumn(name, ((ByteArrayDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Int16),
                (name, dataColumn, rowCount) => new ShortMultiValueColumn(name, ((Int16DataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Int16, isNullable: true),
                (name, dataColumn, rowCount) => new NullableShortMultiValueColumn(name, ((NullableInt16DataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Int32),
                (name, dataColumn, rowCount) => new IntMultiValueColumn(name, ((Int32DataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Int32, isNullable: true),
                (name, dataColumn, rowCount) => new NullableIntMultiValueColumn(name, ((NullableInt32DataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Int64),
                (name, dataColumn, rowCount) => new LongMultiValueColumn(name, ((Int64DataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Int64, isNullable: true),
                (name, dataColumn, rowCount) => new NullableLongMultiValueColumn(name, ((NullableInt64DataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Single),
                (name, dataColumn, rowCount) => new FloatMultiValueColumn(name, ((SingleDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Single, isNullable: true),
                (name, dataColumn, rowCount) => new NullableFloatMultiValueColumn(name, ((NullableSingleDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Double),
                (name, dataColumn, rowCount) => new DoubleMultiValueColumn(name, ((DoubleDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Double, isNullable: true),
                (name, dataColumn, rowCount) => new NullableDoubleMultiValueColumn(name, ((NullableDoubleDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Decimal),
                (name, dataColumn, rowCount) => new DecimalMultiValueColumn(name, ((DecimalDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Decimal, isNullable: true),
                (name, dataColumn, rowCount) => new NullableDecimalMultiValueColumn(name, ((NullableDecimalDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.String),
                (name, dataColumn, rowCount) => new StringMultiValueColumn(name, ((StringDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.String, isNullable: true),
                (name, dataColumn, rowCount) => new StringMultiValueColumn(name, ((NullableStringDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.DateTime),
                (name, dataColumn, rowCount) => new DateTimeMultiValueColumn(name, ((DateTimeDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.DateTime, isNullable: true),
                (name, dataColumn, rowCount) => new NullableDateTimeMultiValueColumn(name, ((NullableDateTimeDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.TimeSpan),
                (name, dataColumn, rowCount) => new TimeSpanMultiValueColumn(name, ((TimeSpanDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.TimeSpan, isNullable: true),
                (name, dataColumn, rowCount) => new NullableTimeSpanMultiValueColumn(name, ((NullableTimeSpanDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Guid),
                (name, dataColumn, rowCount) => new GuidMultiValueColumn(name, ((GuidDataColumn)dataColumn).GetValues(rowCount))
            },
            {
                Extensions.GetHash(DataType.Guid, isNullable: true),
                (name, dataColumn, rowCount) => new NullableGuidMultiValueColumn(name, ((NullableGuidDataColumn)dataColumn).GetValues(rowCount))
            },
        }.ToFrozenDictionary();

#pragma warning disable IDE0038 // Use pattern matching
    private static MultiValueColumn CreateColumn(string name, IReadOnlyList<object> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        if (values is IReadOnlyList<bool>)
            return new BoolMultiValueColumn(name, (IReadOnlyList<bool>)values);
        else if (values is IReadOnlyList<byte>)
            return new ByteMultiValueColumn(name, (IReadOnlyList<byte>)values);
        else if (values is IReadOnlyList<short>)
            return new ShortMultiValueColumn(name, (IReadOnlyList<short>)values);
        else if (values is IReadOnlyList<int>)
            return new IntMultiValueColumn(name, (IReadOnlyList<int>)values);
        else if (values is IReadOnlyList<long>)
            return new LongMultiValueColumn(name, (IReadOnlyList<long>)values);
        else if (values is IReadOnlyList<float>)
            return new FloatMultiValueColumn(name, (IReadOnlyList<float>)values);
        else if (values is IReadOnlyList<double>)
            return new DoubleMultiValueColumn(name, (IReadOnlyList<double>)values);
        else if (values is IReadOnlyList<decimal>)
            return new DecimalMultiValueColumn(name, (IReadOnlyList<decimal>)values);
        else if (values is IReadOnlyList<string>)
            return new StringMultiValueColumn(name, (IReadOnlyList<string>)values);
        else if (values is IReadOnlyList<DateTime>)
            return new DateTimeMultiValueColumn(name, (IReadOnlyList<DateTime>)values);
        else if (values is IReadOnlyList<Guid>)
            return new GuidMultiValueColumn(name, (IReadOnlyList<Guid>)values);
        else if (values is IReadOnlyList<byte[]>)
            return new ByteArrayMultiValueColumn(name, (IReadOnlyList<byte[]>)values);

        // Nullable types
        if (values is IReadOnlyList<bool?>)
            return new NullableBoolMultiValueColumn(name, (IReadOnlyList<bool?>)values);
        else if (values is IReadOnlyList<byte?>)
            return new NullableByteMultiValueColumn(name, (IReadOnlyList<byte?>)values);
        else if (values is IReadOnlyList<short?>)
            return new NullableShortMultiValueColumn(name, (IReadOnlyList<short?>)values);
        else if (values is IReadOnlyList<int?>)
            return new NullableIntMultiValueColumn(name, (IReadOnlyList<int?>)values);
        else if (values is IReadOnlyList<long?>)
            return new NullableLongMultiValueColumn(name, (IReadOnlyList<long?>)values);
        else if (values is IReadOnlyList<float?>)
            return new NullableFloatMultiValueColumn(name, (IReadOnlyList<float?>)values);
        else if (values is IReadOnlyList<double?>)
            return new NullableDoubleMultiValueColumn(name, (IReadOnlyList<double?>)values);
        else if (values is IReadOnlyList<decimal?>)
            return new NullableDecimalMultiValueColumn(name, (IReadOnlyList<decimal?>)values);
        else if (values is IReadOnlyList<DateTime?>)
            return new NullableDateTimeMultiValueColumn(name, (IReadOnlyList<DateTime?>)values);
        else if (values is IReadOnlyList<Guid?>)
            return new NullableGuidMultiValueColumn(name, (IReadOnlyList<Guid?>)values);

        throw new NotSupportedException(values.GetType().FullName);
    }
#pragma warning restore IDE0038 // Use pattern matching

    #endregion
}
