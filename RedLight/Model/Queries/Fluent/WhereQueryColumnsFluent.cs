using System;

namespace RedLight;

public static class WhereQueryColumnsFluent
{
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, bool value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, bool value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, bool value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, bool value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, bool value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, bool value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, bool? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, bool? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, bool? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, bool? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, bool? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, bool? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, byte value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, byte value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, byte value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, byte value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, byte value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, byte value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, byte? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, byte? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, byte? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, byte? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, byte? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, byte? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, short value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, short value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, short value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, short value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, short value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, short value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, short? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, short? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, short? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, short? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, short? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, short? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, int value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, int value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, int value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, int value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, int value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, int value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, int? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, int? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, int? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, int? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, int? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, int? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, long value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, long value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, long value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, long value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, long value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, long value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, long? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, long? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, long? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, long? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, long? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, long? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, float value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, float value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, float value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, float value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, float value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, float value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, float? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, float? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, float? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, float? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, float? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, float? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, double value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, double value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, double value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, double value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, double value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, double value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, double? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, double? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, double? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, double? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, double? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, double? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, decimal value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, decimal value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, decimal value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, decimal value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, decimal value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, decimal value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, decimal? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, decimal? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, decimal? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, decimal? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, decimal? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, decimal? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, string value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, string value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, string value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, string value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, string value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, string value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermString(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, DateTime value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, DateTime value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, DateTime value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, DateTime value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, DateTime value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, DateTime value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, DateTime? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, DateTime? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, DateTime? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, DateTime? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, DateTime? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, DateTime? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, TimeSpan value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, TimeSpan value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, TimeSpan value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, TimeSpan value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, TimeSpan value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, TimeSpan value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, TimeSpan? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, TimeSpan? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, TimeSpan? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, TimeSpan? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, TimeSpan? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, TimeSpan? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Guid value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Guid value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, Guid value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Guid value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Guid value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, Guid value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Guid? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Guid? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, Guid? value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Guid? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Guid? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, Guid? value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, byte[] value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, byte[] value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, Op.Equal, value));

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
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string alias, string column, Op termOperator, byte[] value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, byte[] value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, Op.Equal, value));

        return query;
    }
    
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, byte[] value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, Op.Equal, value));

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

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, string alias, TEnum column, Op termOperator, byte[] value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetNameWithAlias(alias, column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, escapedColumnName, termOperator, value));

        return query;
    }

}