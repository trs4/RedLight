using System;
using System.Collections.Generic;
using IcyRain.Tables;

namespace RedLight;

public static class MultiValueQueryFluent
{
    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, DataColumn dataColumn, int rowCount)
        where TQuery : MultiValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataColumn);
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), dataColumn, rowCount));
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
        query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(name), dataColumn, rowCount));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="dataTable">Таблица данных</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, DataTable dataTable)
        where TQuery : MultiValueQuery
    {
        ArgumentNullException.ThrowIfNull(dataTable);

        foreach (var pair in dataTable)
            query.AddColumnCore(CreateColumn(query.Connection.Naming.GetName(pair.Key), pair.Value, dataTable.RowCount));

        return query;
    }

    private static MultiValueColumn CreateColumn(string name, DataColumn dataColumn, int rowCount)
    {
        if (dataColumn.IsArray)
            return CreateArrayColumnCore(name, dataColumn, rowCount);
        else if (dataColumn.IsNullable)
            return CreateNullableColumnCore(name, dataColumn, rowCount);
        else
            return CreateColumnCore(name, dataColumn, rowCount);
    }

    private static MultiValueColumn CreateColumnCore(string name, DataColumn dataColumn, int rowCount) => dataColumn.Type switch
    {
        DataType.Boolean => new BoolMultiValueColumn(name, ((BooleanDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Byte => new ByteMultiValueColumn(name, ((ByteDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int16 => new ShortMultiValueColumn(name, ((Int16DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int32 => new IntMultiValueColumn(name, ((Int32DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int64 => new LongMultiValueColumn(name, ((Int64DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Single => new FloatMultiValueColumn(name, ((SingleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Double => new DoubleMultiValueColumn(name, ((DoubleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Decimal => new DecimalMultiValueColumn(name, ((DecimalDataColumn)dataColumn).GetValues(rowCount)),
        DataType.String => new StringMultiValueColumn(name, ((StringDataColumn)dataColumn).GetValues(rowCount)),
        DataType.DateTime => new DateTimeMultiValueColumn(name, ((DateTimeDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Guid => new GuidMultiValueColumn(name, ((GuidDataColumn)dataColumn).GetValues(rowCount)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

    private static MultiValueColumn CreateNullableColumnCore(string name, DataColumn dataColumn, int rowCount) => dataColumn.Type switch
    {
        DataType.Boolean => new NullableBoolMultiValueColumn(name, ((NullableBooleanDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Byte => new NullableByteMultiValueColumn(name, ((NullableByteDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int16 => new NullableShortMultiValueColumn(name, ((NullableInt16DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int32 => new NullableIntMultiValueColumn(name, ((NullableInt32DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int64 => new NullableLongMultiValueColumn(name, ((NullableInt64DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Single => new NullableFloatMultiValueColumn(name, ((NullableSingleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Double => new NullableDoubleMultiValueColumn(name, ((NullableDoubleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Decimal => new NullableDecimalMultiValueColumn(name, ((NullableDecimalDataColumn)dataColumn).GetValues(rowCount)),
        DataType.String => new StringMultiValueColumn(name, ((NullableStringDataColumn)dataColumn).GetValues(rowCount)),
        DataType.DateTime => new NullableDateTimeMultiValueColumn(name, ((NullableDateTimeDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Guid => new NullableGuidMultiValueColumn(name, ((NullableGuidDataColumn)dataColumn).GetValues(rowCount)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private static MultiValueColumn CreateArrayColumnCore(string name, DataColumn dataColumn, int rowIndex)
    {
        if (dataColumn.Type == DataType.Byte)
            return new ByteArrayMultiValueColumn(name, ((ByteArrayDataColumn)dataColumn).GetValues(rowIndex));

        throw new NotSupportedException(dataColumn.GetType().FullName);
    }
#pragma warning restore CA1859 // Use concrete types when possible for improved performance

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

}
