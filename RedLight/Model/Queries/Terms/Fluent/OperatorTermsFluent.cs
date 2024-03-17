using System;

namespace RedLight;

public static class OperatorTermsFluentApi
{
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, bool value)
    {
        termBlock.AddTerm(new OperatorTermBool(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, bool value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermBool(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, bool value)
    {
        termBlock.AddTerm(new OperatorTermBool(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, bool value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermBool(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, bool value)
    {
        termBlock.AddTerm(new OperatorTermBool(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, bool? value)
    {
        termBlock.AddTerm(new OperatorTermNullableBool(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, bool? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableBool(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, bool? value)
    {
        termBlock.AddTerm(new OperatorTermNullableBool(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, bool? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableBool(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, bool? value)
    {
        termBlock.AddTerm(new OperatorTermNullableBool(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, char value)
    {
        termBlock.AddTerm(new OperatorTermChar(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, char value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermChar(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, char value)
    {
        termBlock.AddTerm(new OperatorTermChar(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, char value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermChar(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, char value)
    {
        termBlock.AddTerm(new OperatorTermChar(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, char? value)
    {
        termBlock.AddTerm(new OperatorTermNullableChar(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, char? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableChar(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, char? value)
    {
        termBlock.AddTerm(new OperatorTermNullableChar(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, char? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableChar(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, char? value)
    {
        termBlock.AddTerm(new OperatorTermNullableChar(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, sbyte value)
    {
        termBlock.AddTerm(new OperatorTermSByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, sbyte value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermSByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, sbyte value)
    {
        termBlock.AddTerm(new OperatorTermSByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, sbyte value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermSByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, sbyte value)
    {
        termBlock.AddTerm(new OperatorTermSByte(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, sbyte? value)
    {
        termBlock.AddTerm(new OperatorTermNullableSByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, sbyte? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableSByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, sbyte? value)
    {
        termBlock.AddTerm(new OperatorTermNullableSByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, sbyte? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableSByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, sbyte? value)
    {
        termBlock.AddTerm(new OperatorTermNullableSByte(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, byte value)
    {
        termBlock.AddTerm(new OperatorTermByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, byte value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, byte value)
    {
        termBlock.AddTerm(new OperatorTermByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, byte value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, byte value)
    {
        termBlock.AddTerm(new OperatorTermByte(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, byte? value)
    {
        termBlock.AddTerm(new OperatorTermNullableByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, byte? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableByte(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, byte? value)
    {
        termBlock.AddTerm(new OperatorTermNullableByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, byte? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableByte(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, byte? value)
    {
        termBlock.AddTerm(new OperatorTermNullableByte(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, byte[] value)
    {
        termBlock.AddTerm(new OperatorTermByteArray(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, byte[] value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermByteArray(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, byte[] value)
    {
        termBlock.AddTerm(new OperatorTermByteArray(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, byte[] value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermByteArray(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, byte[] value)
    {
        termBlock.AddTerm(new OperatorTermByteArray(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, short value)
    {
        termBlock.AddTerm(new OperatorTermShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, short value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, short value)
    {
        termBlock.AddTerm(new OperatorTermShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, short value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, short value)
    {
        termBlock.AddTerm(new OperatorTermShort(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, short? value)
    {
        termBlock.AddTerm(new OperatorTermNullableShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, short? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, short? value)
    {
        termBlock.AddTerm(new OperatorTermNullableShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, short? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, short? value)
    {
        termBlock.AddTerm(new OperatorTermNullableShort(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, ushort value)
    {
        termBlock.AddTerm(new OperatorTermUShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, ushort value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermUShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, ushort value)
    {
        termBlock.AddTerm(new OperatorTermUShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, ushort value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermUShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, ushort value)
    {
        termBlock.AddTerm(new OperatorTermUShort(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, ushort? value)
    {
        termBlock.AddTerm(new OperatorTermNullableUShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, ushort? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableUShort(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, ushort? value)
    {
        termBlock.AddTerm(new OperatorTermNullableUShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, ushort? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableUShort(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, ushort? value)
    {
        termBlock.AddTerm(new OperatorTermNullableUShort(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, int value)
    {
        termBlock.AddTerm(new OperatorTermInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, int value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, int value)
    {
        termBlock.AddTerm(new OperatorTermInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, int value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, int value)
    {
        termBlock.AddTerm(new OperatorTermInt(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, int? value)
    {
        termBlock.AddTerm(new OperatorTermNullableInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, int? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, int? value)
    {
        termBlock.AddTerm(new OperatorTermNullableInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, int? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, int? value)
    {
        termBlock.AddTerm(new OperatorTermNullableInt(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, uint value)
    {
        termBlock.AddTerm(new OperatorTermUInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, uint value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermUInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, uint value)
    {
        termBlock.AddTerm(new OperatorTermUInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, uint value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermUInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, uint value)
    {
        termBlock.AddTerm(new OperatorTermUInt(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, uint? value)
    {
        termBlock.AddTerm(new OperatorTermNullableUInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, uint? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableUInt(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, uint? value)
    {
        termBlock.AddTerm(new OperatorTermNullableUInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, uint? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableUInt(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, uint? value)
    {
        termBlock.AddTerm(new OperatorTermNullableUInt(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, long value)
    {
        termBlock.AddTerm(new OperatorTermLong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, long value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermLong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, long value)
    {
        termBlock.AddTerm(new OperatorTermLong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, long value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermLong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, long value)
    {
        termBlock.AddTerm(new OperatorTermLong(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, long? value)
    {
        termBlock.AddTerm(new OperatorTermNullableLong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, long? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableLong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, long? value)
    {
        termBlock.AddTerm(new OperatorTermNullableLong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, long? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableLong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, long? value)
    {
        termBlock.AddTerm(new OperatorTermNullableLong(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, ulong value)
    {
        termBlock.AddTerm(new OperatorTermULong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, ulong value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermULong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, ulong value)
    {
        termBlock.AddTerm(new OperatorTermULong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, ulong value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermULong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, ulong value)
    {
        termBlock.AddTerm(new OperatorTermULong(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, ulong? value)
    {
        termBlock.AddTerm(new OperatorTermNullableULong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, ulong? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableULong(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, ulong? value)
    {
        termBlock.AddTerm(new OperatorTermNullableULong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, ulong? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableULong(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, ulong? value)
    {
        termBlock.AddTerm(new OperatorTermNullableULong(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, float value)
    {
        termBlock.AddTerm(new OperatorTermFloat(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, float value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermFloat(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, float value)
    {
        termBlock.AddTerm(new OperatorTermFloat(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, float value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermFloat(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, float value)
    {
        termBlock.AddTerm(new OperatorTermFloat(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, float? value)
    {
        termBlock.AddTerm(new OperatorTermNullableFloat(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, float? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableFloat(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, float? value)
    {
        termBlock.AddTerm(new OperatorTermNullableFloat(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, float? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableFloat(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, float? value)
    {
        termBlock.AddTerm(new OperatorTermNullableFloat(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, double value)
    {
        termBlock.AddTerm(new OperatorTermDouble(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, double value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermDouble(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, double value)
    {
        termBlock.AddTerm(new OperatorTermDouble(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, double value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermDouble(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, double value)
    {
        termBlock.AddTerm(new OperatorTermDouble(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, double? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDouble(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, double? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableDouble(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, double? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDouble(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, double? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableDouble(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, double? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDouble(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, decimal value)
    {
        termBlock.AddTerm(new OperatorTermDecimal(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, decimal value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermDecimal(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, decimal value)
    {
        termBlock.AddTerm(new OperatorTermDecimal(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, decimal value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermDecimal(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, decimal value)
    {
        termBlock.AddTerm(new OperatorTermDecimal(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, decimal? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDecimal(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, decimal? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableDecimal(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, decimal? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDecimal(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, decimal? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableDecimal(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, decimal? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDecimal(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, string value)
    {
        termBlock.AddTerm(new OperatorTermString(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, string value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermString(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, string value)
    {
        termBlock.AddTerm(new OperatorTermString(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, string value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermString(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, string value)
    {
        termBlock.AddTerm(new OperatorTermString(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, Guid value)
    {
        termBlock.AddTerm(new OperatorTermGuid(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, Guid value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermGuid(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, Guid value)
    {
        termBlock.AddTerm(new OperatorTermGuid(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, Guid value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermGuid(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, Guid value)
    {
        termBlock.AddTerm(new OperatorTermGuid(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, Guid? value)
    {
        termBlock.AddTerm(new OperatorTermNullableGuid(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, Guid? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableGuid(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, Guid? value)
    {
        termBlock.AddTerm(new OperatorTermNullableGuid(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, Guid? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableGuid(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, Guid? value)
    {
        termBlock.AddTerm(new OperatorTermNullableGuid(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, DateTime value)
    {
        termBlock.AddTerm(new OperatorTermDateTime(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, DateTime value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermDateTime(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, DateTime value)
    {
        termBlock.AddTerm(new OperatorTermDateTime(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, DateTime value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermDateTime(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, DateTime value)
    {
        termBlock.AddTerm(new OperatorTermDateTime(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, DateTime? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDateTime(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, DateTime? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableDateTime(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, DateTime? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDateTime(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, DateTime? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableDateTime(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, DateTime? value)
    {
        termBlock.AddTerm(new OperatorTermNullableDateTime(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, TimeSpan value)
    {
        termBlock.AddTerm(new OperatorTermTimeSpan(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, TimeSpan value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermTimeSpan(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, TimeSpan value)
    {
        termBlock.AddTerm(new OperatorTermTimeSpan(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, TimeSpan value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermTimeSpan(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, TimeSpan value)
    {
        termBlock.AddTerm(new OperatorTermTimeSpan(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя Колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string column, Op termOperator, TimeSpan? value)
    {
        termBlock.AddTerm(new OperatorTermNullableTimeSpan(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum column, Op termOperator, TimeSpan? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableTimeSpan(
            termBlock, termBlock.Connection.Naming.GetName(column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string alias, string column, Op termOperator, TimeSpan? value)
    {
        termBlock.AddTerm(new OperatorTermNullableTimeSpan(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, string alias, TEnum column, Op termOperator, TimeSpan? value)
        where TEnum : Enum
    {
        termBlock.AddTerm(new OperatorTermNullableTimeSpan(
            termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), termOperator, value));

        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="value">Значение</param>
    public static TermBlock WithValueRawColumnTerm(this TermBlock termBlock, string rawColumn, Op termOperator, TimeSpan? value)
    {
        termBlock.AddTerm(new OperatorTermNullableTimeSpan(
            termBlock, rawColumn, termOperator, value));

        return termBlock;
    }

}