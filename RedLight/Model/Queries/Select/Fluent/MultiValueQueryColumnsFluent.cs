using System;
using System.Collections.Generic;

namespace RedLight;

public static class MultiValueQueryColumnsFluent
{
    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<bool> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new BoolMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<bool> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new BoolMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<bool?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableBoolMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<bool?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableBoolMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<byte> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new ByteMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<byte> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new ByteMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<byte?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableByteMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<byte?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableByteMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<short> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new ShortMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<short> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new ShortMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<short?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableShortMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<short?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableShortMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<int> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new IntMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<int> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new IntMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<int?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableIntMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<int?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableIntMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<long> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new LongMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<long> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new LongMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<long?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableLongMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<long?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableLongMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<float> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new FloatMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<float> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new FloatMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<float?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableFloatMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<float?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableFloatMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<double> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new DoubleMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<double> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new DoubleMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<double?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableDoubleMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<double?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableDoubleMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<decimal> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new DecimalMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<decimal> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new DecimalMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<decimal?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableDecimalMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<decimal?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableDecimalMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<string> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new StringMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<string> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new StringMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<DateTime> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new DateTimeMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<DateTime> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new DateTimeMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<DateTime?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableDateTimeMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<DateTime?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableDateTimeMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<Guid> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new GuidMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<Guid> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new GuidMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<Guid?> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new NullableGuidMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<Guid?> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableGuidMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, IReadOnlyList<byte[]> values)
        where TQuery : MultiValueQuery
    {
        query.AddColumnCore(new ByteArrayMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="values">Список значений</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, IReadOnlyList<byte[]> values)
        where TQuery : MultiValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new ByteArrayMultiValueColumn(query.Connection.Naming.GetName(name), values));
        return query;
    }

}