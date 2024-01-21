using System;

namespace RedLight;

public static class MultiInsertQueryColumnsFluent
{
    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа bool</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool</param>
    public static MultiInsertQuery<TResult> AddBoolReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, bool> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа bool</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool</param>
    public static MultiInsertQuery<TResult> AddBoolReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, bool> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, bool value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermBool(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, bool value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermBool(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа bool?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool?</param>
    public static MultiInsertQuery<TResult> AddNullableBoolReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, bool?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа bool?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool?</param>
    public static MultiInsertQuery<TResult> AddNullableBoolReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, bool?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, bool? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, bool? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableBool(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа byte</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte</param>
    public static MultiInsertQuery<TResult> AddByteReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, byte> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа byte</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte</param>
    public static MultiInsertQuery<TResult> AddByteReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, byte> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, byte value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByte(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, byte value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByte(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа byte?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte?</param>
    public static MultiInsertQuery<TResult> AddNullableByteReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, byte?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа byte?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte?</param>
    public static MultiInsertQuery<TResult> AddNullableByteReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, byte?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, byte? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, byte? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableByte(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа short</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short</param>
    public static MultiInsertQuery<TResult> AddShortReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, short> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа short</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short</param>
    public static MultiInsertQuery<TResult> AddShortReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, short> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, short value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermShort(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, short value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermShort(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа short?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short?</param>
    public static MultiInsertQuery<TResult> AddNullableShortReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, short?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа short?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short?</param>
    public static MultiInsertQuery<TResult> AddNullableShortReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, short?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, short? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, short? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableShort(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа int</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int</param>
    public static MultiInsertQuery<TResult> AddIntReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, int> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа int</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int</param>
    public static MultiInsertQuery<TResult> AddIntReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, int> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, int value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermInt(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, int value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermInt(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа int?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int?</param>
    public static MultiInsertQuery<TResult> AddNullableIntReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, int?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа int?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int?</param>
    public static MultiInsertQuery<TResult> AddNullableIntReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, int?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, int? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, int? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableInt(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа long</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long</param>
    public static MultiInsertQuery<TResult> AddLongReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, long> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа long</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long</param>
    public static MultiInsertQuery<TResult> AddLongReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, long> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, long value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermLong(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, long value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermLong(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа long?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long?</param>
    public static MultiInsertQuery<TResult> AddNullableLongReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, long?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа long?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long?</param>
    public static MultiInsertQuery<TResult> AddNullableLongReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, long?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, long? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, long? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableLong(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа float</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float</param>
    public static MultiInsertQuery<TResult> AddFloatReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, float> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа float</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float</param>
    public static MultiInsertQuery<TResult> AddFloatReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, float> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, float value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, float value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermFloat(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа float?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float?</param>
    public static MultiInsertQuery<TResult> AddNullableFloatReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, float?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа float?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float?</param>
    public static MultiInsertQuery<TResult> AddNullableFloatReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, float?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, float? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, float? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableFloat(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа double</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double</param>
    public static MultiInsertQuery<TResult> AddDoubleReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, double> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа double</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double</param>
    public static MultiInsertQuery<TResult> AddDoubleReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, double> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, double value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, double value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDouble(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа double?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double?</param>
    public static MultiInsertQuery<TResult> AddNullableDoubleReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, double?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа double?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double?</param>
    public static MultiInsertQuery<TResult> AddNullableDoubleReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, double?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, double? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, double? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDouble(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа decimal</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal</param>
    public static MultiInsertQuery<TResult> AddDecimalReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, decimal> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа decimal</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal</param>
    public static MultiInsertQuery<TResult> AddDecimalReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, decimal> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, decimal value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, decimal value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDecimal(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа decimal?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal?</param>
    public static MultiInsertQuery<TResult> AddNullableDecimalReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, decimal?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа decimal?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal?</param>
    public static MultiInsertQuery<TResult> AddNullableDecimalReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, decimal?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, decimal? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, decimal? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDecimal(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа string</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа string</param>
    public static MultiInsertQuery<TResult> AddStringReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, string> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа string</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа string</param>
    public static MultiInsertQuery<TResult> AddStringReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, string> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, string value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermString(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, string value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermString(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа DateTime</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime</param>
    public static MultiInsertQuery<TResult> AddDateTimeReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, DateTime> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа DateTime</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime</param>
    public static MultiInsertQuery<TResult> AddDateTimeReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, DateTime> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, DateTime value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, DateTime value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermDateTime(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа DateTime?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime?</param>
    public static MultiInsertQuery<TResult> AddNullableDateTimeReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, DateTime?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа DateTime?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime?</param>
    public static MultiInsertQuery<TResult> AddNullableDateTimeReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, DateTime?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, DateTime? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, DateTime? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableDateTime(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа TimeSpan</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan</param>
    public static MultiInsertQuery<TResult> AddTimeSpanReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, TimeSpan> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа TimeSpan</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan</param>
    public static MultiInsertQuery<TResult> AddTimeSpanReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, TimeSpan> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, TimeSpan value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, TimeSpan value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermTimeSpan(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа TimeSpan?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan?</param>
    public static MultiInsertQuery<TResult> AddNullableTimeSpanReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, TimeSpan?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа TimeSpan?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan?</param>
    public static MultiInsertQuery<TResult> AddNullableTimeSpanReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, TimeSpan?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, TimeSpan? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, TimeSpan? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableTimeSpan(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа Guid</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid</param>
    public static MultiInsertQuery<TResult> AddGuidReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, Guid> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа Guid</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid</param>
    public static MultiInsertQuery<TResult> AddGuidReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, Guid> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, Guid value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, Guid value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermGuid(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа Guid?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid?</param>
    public static MultiInsertQuery<TResult> AddNullableGuidReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, Guid?> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа Guid?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid?</param>
    public static MultiInsertQuery<TResult> AddNullableGuidReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, Guid?> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, Guid? value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, Guid? value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermNullableGuid(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа byte[]</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte[]</param>
    public static MultiInsertQuery<TResult> AddByteArrayReturningColumn<TResult>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, byte[]> readColumn)
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля типа byte[]</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte[]</param>
    public static MultiInsertQuery<TResult> AddByteArrayReturningColumn<TResult, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, byte[]> readColumn)
        where TEnum : Enum
        => query.AddReturningColumn(name, readColumn);

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, byte[] value)
        where TQuery : MultiInsertQuery
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, byte[] value)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        string escapedColumn = query.Connection.Naming.GetName(column);

        query.Where.AddTerm(new OperatorTermByteArray(
            query, Naming.GetRawNameWithAlias(query.DataAlias, escapedColumn), termOperator, value));

        return query;
    }

}