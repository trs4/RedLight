using System;

namespace RedLight;

public static class WhereQueryColumnsFluent
{
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, bool value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, bool value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, bool? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, bool? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, byte value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, byte value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, byte? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, byte? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, short value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, short value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, short? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, short? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, int value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, int value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, int? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, int? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, long value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, long value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, long? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, long? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, float value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, float value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, float? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, float? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, double value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, double value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, double? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, double? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, decimal value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, decimal value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, decimal? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, decimal? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, string value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, string value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, DateTime value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, DateTime value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, DateTime? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, DateTime? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, TimeSpan value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, TimeSpan value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, TimeSpan? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, TimeSpan? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, Guid value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, Guid value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, Guid? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, Guid? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, byte[] value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, byte[] value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, termOperator, value));

        return query;
    }

}