using System;

namespace RedLight;

public static class ValueQueryColumnsFluent
{
    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, bool value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new BoolValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, bool value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new BoolValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, bool? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableBoolValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, bool? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableBoolValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, byte value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new ByteValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, byte value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new ByteValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, byte? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableByteValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, byte? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableByteValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, short value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new ShortValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, short value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new ShortValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, short? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableShortValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, short? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableShortValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, int value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new IntValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, int value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new IntValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, int? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableIntValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, int? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableIntValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, long value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new LongValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, long value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new LongValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, long? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableLongValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, long? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableLongValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, float value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new FloatValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, float value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new FloatValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, float? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableFloatValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, float? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableFloatValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, double value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new DoubleValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, double value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new DoubleValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, double? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableDoubleValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, double? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableDoubleValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, decimal value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new DecimalValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, decimal value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new DecimalValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, decimal? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableDecimalValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, decimal? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableDecimalValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, string value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new StringValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, string value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new StringValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, DateTime value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new DateTimeValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, DateTime value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new DateTimeValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, DateTime? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableDateTimeValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, DateTime? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableDateTimeValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, Guid value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new GuidValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, Guid value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new GuidValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, Guid? value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new NullableGuidValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, Guid? value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new NullableGuidValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, byte[] value)
        where TQuery : ValueQuery
    {
        query.AddColumnCore(new ByteArrayValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

    /// <summary>Добавляет поле добавления данных</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, byte[] value)
        where TQuery : ValueQuery
        where TEnum : Enum
    {
        query.AddColumnCore(new ByteArrayValueColumn(query.Connection.Naming.GetName(name), value));
        return query;
    }

}