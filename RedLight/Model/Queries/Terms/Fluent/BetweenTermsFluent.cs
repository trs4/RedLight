using System;

namespace RedLight;

public static class BetweenTermsFluent
{
    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, sbyte beginValue, sbyte endValue)
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, sbyte beginValue, sbyte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, sbyte beginValue, sbyte endValue)
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, sbyte beginValue, sbyte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, sbyte beginValue, sbyte endValue)
    {
        var term = new BetweenTermSByte(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, byte beginValue, byte endValue)
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, byte beginValue, byte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, byte beginValue, byte endValue)
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, byte beginValue, byte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, byte beginValue, byte endValue)
    {
        var term = new BetweenTermByte(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, short beginValue, short endValue)
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, short beginValue, short endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, short beginValue, short endValue)
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, short beginValue, short endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, short beginValue, short endValue)
    {
        var term = new BetweenTermShort(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, ushort beginValue, ushort endValue)
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, ushort beginValue, ushort endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, ushort beginValue, ushort endValue)
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, ushort beginValue, ushort endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, ushort beginValue, ushort endValue)
    {
        var term = new BetweenTermUShort(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, int beginValue, int endValue)
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, int beginValue, int endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, int beginValue, int endValue)
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, int beginValue, int endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, int beginValue, int endValue)
    {
        var term = new BetweenTermInt(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, uint beginValue, uint endValue)
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, uint beginValue, uint endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, uint beginValue, uint endValue)
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, uint beginValue, uint endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, uint beginValue, uint endValue)
    {
        var term = new BetweenTermUInt(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, long beginValue, long endValue)
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, long beginValue, long endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, long beginValue, long endValue)
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, long beginValue, long endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, long beginValue, long endValue)
    {
        var term = new BetweenTermLong(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, ulong beginValue, ulong endValue)
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, ulong beginValue, ulong endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, ulong beginValue, ulong endValue)
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, ulong beginValue, ulong endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, ulong beginValue, ulong endValue)
    {
        var term = new BetweenTermULong(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, float beginValue, float endValue)
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, float beginValue, float endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, float beginValue, float endValue)
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, float beginValue, float endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, float beginValue, float endValue)
    {
        var term = new BetweenTermFloat(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, double beginValue, double endValue)
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, double beginValue, double endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, double beginValue, double endValue)
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, double beginValue, double endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, double beginValue, double endValue)
    {
        var term = new BetweenTermDouble(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, decimal beginValue, decimal endValue)
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, decimal beginValue, decimal endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, decimal beginValue, decimal endValue)
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, decimal beginValue, decimal endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, decimal beginValue, decimal endValue)
    {
        var term = new BetweenTermDecimal(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string column, DateTime beginValue, DateTime endValue)
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, TEnum column, DateTime beginValue, DateTime endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween(this TermBlock termBlock, string alias, string column, DateTime beginValue, DateTime endValue)
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, DateTime beginValue, DateTime endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawBetween(this TermBlock termBlock, string rawColumn, DateTime beginValue, DateTime endValue)
    {
        var term = new BetweenTermDateTime(termBlock, rawColumn, beginValue, endValue);
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, sbyte beginValue, sbyte endValue)
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, sbyte beginValue, sbyte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, sbyte beginValue, sbyte endValue)
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, sbyte beginValue, sbyte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermSByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, sbyte beginValue, sbyte endValue)
    {
        var term = new BetweenTermSByte(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, byte beginValue, byte endValue)
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, byte beginValue, byte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, byte beginValue, byte endValue)
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, byte beginValue, byte endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermByte(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, byte beginValue, byte endValue)
    {
        var term = new BetweenTermByte(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, short beginValue, short endValue)
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, short beginValue, short endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, short beginValue, short endValue)
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, short beginValue, short endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, short beginValue, short endValue)
    {
        var term = new BetweenTermShort(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, ushort beginValue, ushort endValue)
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, ushort beginValue, ushort endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, ushort beginValue, ushort endValue)
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, ushort beginValue, ushort endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUShort(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, ushort beginValue, ushort endValue)
    {
        var term = new BetweenTermUShort(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, int beginValue, int endValue)
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, int beginValue, int endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, int beginValue, int endValue)
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, int beginValue, int endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, int beginValue, int endValue)
    {
        var term = new BetweenTermInt(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, uint beginValue, uint endValue)
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, uint beginValue, uint endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, uint beginValue, uint endValue)
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, uint beginValue, uint endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermUInt(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, uint beginValue, uint endValue)
    {
        var term = new BetweenTermUInt(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, long beginValue, long endValue)
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, long beginValue, long endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, long beginValue, long endValue)
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, long beginValue, long endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermLong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, long beginValue, long endValue)
    {
        var term = new BetweenTermLong(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, ulong beginValue, ulong endValue)
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, ulong beginValue, ulong endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, ulong beginValue, ulong endValue)
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, ulong beginValue, ulong endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermULong(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, ulong beginValue, ulong endValue)
    {
        var term = new BetweenTermULong(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, float beginValue, float endValue)
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, float beginValue, float endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, float beginValue, float endValue)
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, float beginValue, float endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermFloat(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, float beginValue, float endValue)
    {
        var term = new BetweenTermFloat(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, double beginValue, double endValue)
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, double beginValue, double endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, double beginValue, double endValue)
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, double beginValue, double endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDouble(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, double beginValue, double endValue)
    {
        var term = new BetweenTermDouble(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, decimal beginValue, decimal endValue)
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, decimal beginValue, decimal endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, decimal beginValue, decimal endValue)
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, decimal beginValue, decimal endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDecimal(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, decimal beginValue, decimal endValue)
    {
        var term = new BetweenTermDecimal(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя поля</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string column, DateTime beginValue, DateTime endValue)
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, TEnum column, DateTime beginValue, DateTime endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetName(column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween(this TermBlock termBlock, string alias, string column, DateTime beginValue, DateTime endValue)
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="alias">Псевдоним таблицы</param>
    /// <param name="column">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithNotBetween<TEnum>(this TermBlock termBlock, string alias, TEnum column, DateTime beginValue, DateTime endValue)
        where TEnum : Enum
    {
        var term = new BetweenTermDateTime(termBlock, termBlock.Connection.Naming.GetNameWithAlias(alias, column), beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с диапазоном</summary>
    /// <param name="rawColumn">Имя колонки</param>
    /// <param name="beginValue">Значение начала диапазона</param>
    /// <param name="endValue">Значение конца диапазона</param>
    public static TermBlock WithRawNotBetween(this TermBlock termBlock, string rawColumn, DateTime beginValue, DateTime endValue)
    {
        var term = new BetweenTermDateTime(termBlock, rawColumn, beginValue, endValue)
        {
            Not = true,
        };
        termBlock.AddTerm(term);
        return termBlock;
    }

}