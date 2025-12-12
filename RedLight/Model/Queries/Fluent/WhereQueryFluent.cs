using System;
using System.Collections.Generic;
using IcyRain.Tables;

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


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithValuesColumnTerm<TQuery>(this TQuery query, string columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
    {
        query.Where.WithValuesColumnTerm(columnName, dataColumn, rowCount);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithValuesColumnTerm<TQuery, TEnum>(this TQuery query, TEnum columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        query.Where.WithValuesColumnTerm(columnName, dataColumn, rowCount);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithValuesColumnTerm<TQuery>(
        this TQuery query, string tableAlias, string columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
    {
        query.Where.WithValuesColumnTerm(tableAlias, columnName, dataColumn, rowCount);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithValuesColumnTerm<TQuery, TEnum1, TEnum2>(
        this TQuery query, TEnum1 tableAlias, TEnum2 columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        query.Where.WithValuesColumnTerm(tableAlias, columnName, dataColumn, rowCount);
        return query;
    }


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TQuery WithValuesTerm<TQuery, TValue>(this TQuery query, string columnName, IReadOnlyCollection<TValue> values)
        where TQuery : WhereQuery
    {
        query.Where.WithValuesTerm(columnName, values);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TQuery WithValuesTerm<TQuery, TValue, TEnum>(this TQuery query, TEnum columnName, IReadOnlyCollection<TValue> values)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        query.Where.WithValuesTerm(columnName, values);
        return query;
    }


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithNotValuesColumnTerm<TQuery>(this TQuery query, string columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
    {
        query.Where.WithNotValuesColumnTerm(columnName, dataColumn, rowCount);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithNotValuesColumnTerm<TQuery, TEnum>(this TQuery query, TEnum columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        query.Where.WithNotValuesColumnTerm(columnName, dataColumn, rowCount);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithNotValuesColumnTerm<TQuery>(
        this TQuery query, string tableAlias, string columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
    {
        query.Where.WithNotValuesColumnTerm(tableAlias, columnName, dataColumn, rowCount);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TQuery WithNotValuesColumnTerm<TQuery, TEnum1, TEnum2>(
        this TQuery query, TEnum1 tableAlias, TEnum2 columnName, DataColumn dataColumn, int rowCount)
        where TQuery : WhereQuery
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        query.Where.WithNotValuesColumnTerm(tableAlias, columnName, dataColumn, rowCount);
        return query;
    }


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TQuery WithNotValuesTerm<TQuery, TValue>(this TQuery query, string columnName, IReadOnlyCollection<TValue> values)
        where TQuery : WhereQuery
    {
        query.Where.WithNotValuesTerm(columnName, values);
        return query;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TQuery WithNotValuesTerm<TQuery, TValue, TEnum>(this TQuery query, TEnum columnName, IReadOnlyCollection<TValue> values)
        where TQuery : WhereQuery
        where TEnum : Enum
    {
        query.Where.WithNotValuesTerm(columnName, values);
        return query;
    }

}
