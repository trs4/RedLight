﻿using System;

namespace RedLight;

public static class WhereQueryFluent
{
    /// <summary>Собирает условия запроса</summary>
    /// <param name="buildTerms">Действие заполнения условий</param>
    public static TQuery With<TQuery>(this TQuery query, Action<TermBlock> buildTerms)
        where TQuery : WhereQuery
    {
        buildTerms?.Invoke(query.Where);
        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="valueColumn">Описание поля значения</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, Column valueColumn, object value)
        where TQuery : WhereQuery
    {
        ArgumentNullException.ThrowIfNull(valueColumn);
        string escapedColumnName = query.Connection.Naming.GetName(column);
        string escapedValue = query.Connection.Escaping.EscapeData(valueColumn, value);
        query.Where.AddTerm(new RawOperatorTerm(query, escapedColumnName, termOperator, escapedValue));
        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="valueColumn">Описание поля значения</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, Column valueColumn, object value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(valueColumn);
        string escapedColumnName = query.Connection.Naming.GetName(column);
        string escapedValue = query.Connection.Escaping.EscapeData(valueColumn, value);
        query.Where.AddTerm(new RawOperatorTerm(query, escapedColumnName, termOperator, escapedValue));
        return query;
    }


    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery>(this TQuery query, string column, Op termOperator, object value)
        where TQuery : WhereQuery
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);
        string escapedValue = query.Connection.Escaping.EscapeData(value);
        query.Where.AddTerm(new RawOperatorTerm(query, escapedColumnName, termOperator, escapedValue));
        return query;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TQuery WithTerm<TQuery, TEnum>(this TQuery query, TEnum column, Op termOperator, object value)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        string escapedColumnName = query.Connection.Naming.GetName(column);
        string escapedValue = query.Connection.Escaping.EscapeData(value);
        query.Where.AddTerm(new RawOperatorTerm(query, escapedColumnName, termOperator, escapedValue));
        return query;
    }

}
