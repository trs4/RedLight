using System;

namespace RedLight;

public static class TermExtensions
{
    /// <summary>Добавляет логический оператор</summary>
    /// <param name="logicalOperator">Логический оператор блока условий</param>
    public static TermBlock With(this TermBlock termBlock, LogicalOperator logicalOperator)
    {
        termBlock.LogicalOperator = logicalOperator;
        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm(
        this TermBlock termBlock, string column1, Op termOperator, string column2)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetName(column1),
            termOperator, termBlock.Connection.Naming.GetName(column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 column1, Op termOperator, TEnum2 column2)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetName(column1),
            termOperator, termBlock.Connection.Naming.GetName(column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="alias1">левый псевдоним таблицы</param>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="alias2">Правый псевдоним таблицы</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm(
        this TermBlock termBlock, string alias1, string column1, Op termOperator, string alias2, string column2)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias1, column1),
            termOperator, termBlock.Connection.Naming.GetNameWithAlias(alias2, column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="alias1">левый псевдоним таблицы</param>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="alias2">Правый псевдоним таблицы</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, string alias1, TEnum1 column1, Op termOperator, string alias2, TEnum2 column2)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias1, column1),
            termOperator, termBlock.Connection.Naming.GetNameWithAlias(alias2, column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="alias1">левый псевдоним таблицы</param>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm(
        this TermBlock termBlock, string alias1, string column1, Op termOperator, string column2)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias1, column1),
            termOperator, termBlock.Connection.Naming.GetName(column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="alias1">левый псевдоним таблицы</param>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, string alias1, TEnum1 column1, Op termOperator, TEnum2 column2)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias1, column1),
            termOperator, termBlock.Connection.Naming.GetName(column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm(
        this TermBlock termBlock, string column1, Op termOperator, string alias2, string column2)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetName(column1),
            termOperator, termBlock.Connection.Naming.GetNameWithAlias(alias2, column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="column1">Левое имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="column2">Правое имя поля</param>
    public static TermBlock WithColumnsTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 column1, Op termOperator, string alias2, TEnum2 column2)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetName(column1),
            termOperator, termBlock.Connection.Naming.GetNameWithAlias(alias2, column2)));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="escapedValue">Значение</param>
    public static TermBlock WithRawValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, string escapedValue)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, escapedValue));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="escapedValue">Значение</param>
    public static TermBlock WithRawValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, string escapedValue)
        where TEnum : Enum
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, escapedValue));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="escapedValue">Значение</param>
    public static TermBlock WithRawValueColumnTerm(
        this TermBlock termBlock, string alias, string column, Op termOperator, string escapedValue)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, escapedValue));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="escapedValue">Значение</param>
    public static TermBlock WithRawValueColumnTerm<TEnum>(
        this TermBlock termBlock, string alias, TEnum column, Op termOperator, string escapedValue)
        where TEnum : Enum
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, escapedValue));

        return termBlock;
    }

    /// <summary>Добавляет условие по значениям</summary>
    /// <param name="escapedValue1">Левое значение</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="escapedValue2">Правое значение</param>
    public static TermBlock WithRawTerm(this TermBlock termBlock, string escapedValue1, Op termOperator, string escapedValue2)
    {
        termBlock.AddTerm(new RawOperatorTerm(
            termBlock, escapedValue1, termOperator, escapedValue2));

        return termBlock;
    }

}
