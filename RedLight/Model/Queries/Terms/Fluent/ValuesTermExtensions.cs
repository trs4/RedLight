using System;
using System.Collections.Generic;
using IcyRain.Tables;
using RedLight.Internal;

namespace RedLight;

public static class ValuesTermExtensions
{
    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithValuesColumnTerm(this TermBlock termBlock, string columnName, DataColumn dataColumn, int rowCount)
    {
        columnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            columnName = Naming.GetRawNameWithAlias(q.Alias, columnName);

        termBlock.AddTerm(CreateColumn(termBlock.Owner, columnName, dataColumn, rowCount));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithValuesColumnTerm<TEnum>(this TermBlock termBlock, TEnum columnName, DataColumn dataColumn, int rowCount)
        where TEnum : Enum
    {
        string column = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            column = Naming.GetRawNameWithAlias(q.Alias, column);

        termBlock.AddTerm(CreateColumn(termBlock.Owner, column, dataColumn, rowCount));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithValuesColumnTerm(
        this TermBlock termBlock, string tableAlias, string columnName, DataColumn dataColumn, int rowCount)
    {
        termBlock.AddTerm(CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), dataColumn, rowCount));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithValuesColumnTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 tableAlias, TEnum2 columnName, DataColumn dataColumn, int rowCount)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), dataColumn, rowCount));
        return termBlock;
    }


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TermBlock WithValuesTerm<TValue>(this TermBlock termBlock, string columnName, IReadOnlyCollection<TValue> values)
    {
        columnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            columnName = Naming.GetRawNameWithAlias(q.Alias, columnName);

        termBlock.AddTerm(InTermAction<TValue>.Instance.Create(termBlock.Owner, columnName, values));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TermBlock WithValuesTerm<TValue, TEnum>(this TermBlock termBlock, TEnum columnName, IReadOnlyCollection<TValue> values)
        where TEnum : Enum
    {
        string escapedColumnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            escapedColumnName = Naming.GetRawNameWithAlias(q.Alias, escapedColumnName);

        termBlock.AddTerm(InTermAction<TValue>.Instance.Create(termBlock.Owner, escapedColumnName, values));
        return termBlock;
    }


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithNotValuesColumnTerm(this TermBlock termBlock, string columnName, DataColumn dataColumn, int rowCount)
    {
        columnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            columnName = Naming.GetRawNameWithAlias(q.Alias, columnName);

        var term = CreateColumn(termBlock.Owner, columnName, dataColumn, rowCount);
        term.Not = true;
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithNotValuesColumnTerm<TEnum>(this TermBlock termBlock, TEnum columnName, DataColumn dataColumn, int rowCount)
        where TEnum : Enum
    {
        string column = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            column = Naming.GetRawNameWithAlias(q.Alias, column);

        var term = CreateColumn(termBlock.Owner, column, dataColumn, rowCount);
        term.Not = true;
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithNotValuesColumnTerm(
        this TermBlock termBlock, string tableAlias, string columnName, DataColumn dataColumn, int rowCount)
    {
        var term = CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), dataColumn, rowCount);
        term.Not = true;
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithNotValuesColumnTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 tableAlias, TEnum2 columnName, DataColumn dataColumn, int rowCount)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        var term = CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), dataColumn, rowCount);
        term.Not = true;
        return termBlock;
    }


    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TermBlock WithNotValuesTerm<TValue>(this TermBlock termBlock, string columnName, IReadOnlyCollection<TValue> values)
    {
        columnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            columnName = Naming.GetRawNameWithAlias(q.Alias, columnName);

        var term = InTermAction<TValue>.Instance.Create(termBlock.Owner, columnName, values);
        term.Not = true;
        termBlock.AddTerm(term);
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значениями</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="values">Значения</param>
    public static TermBlock WithNotValuesTerm<TValue, TEnum>(this TermBlock termBlock, TEnum columnName, IReadOnlyCollection<TValue> values)
        where TEnum : Enum
    {
        string escapedColumnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            escapedColumnName = Naming.GetRawNameWithAlias(q.Alias, escapedColumnName);

        var term = InTermAction<TValue>.Instance.Create(termBlock.Owner, escapedColumnName, values);
        term.Not = true;
        termBlock.AddTerm(term);
        return termBlock;
    }

    private static InTerm CreateColumn(Query owner, string name, DataColumn dataColumn, int rowCount)
        => dataColumn.IsNullable ? CreateNullableColumnCore(owner, name, dataColumn, rowCount) : CreateColumnCore(owner, name, dataColumn, rowCount);

    private static InTerm CreateColumnCore(Query owner, string name, DataColumn dataColumn, int rowCount) => dataColumn.Type switch
    {
        DataType.Boolean => new InTermBool(owner, name, ((BooleanDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Char => new InTermChar(owner, name, ((CharDataColumn)dataColumn).GetValues(rowCount)),
        DataType.SByte => new InTermSByte(owner, name, ((SByteDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Byte => new InTermByte(owner, name, ((ByteDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int16 => new InTermShort(owner, name, ((Int16DataColumn)dataColumn).GetValues(rowCount)),
        DataType.UInt16 => new InTermUShort(owner, name, ((UInt16DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int32 => new InTermInt(owner, name, ((Int32DataColumn)dataColumn).GetValues(rowCount)),
        DataType.UInt32 => new InTermUInt(owner, name, ((UInt32DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int64 => new InTermLong(owner, name, ((Int64DataColumn)dataColumn).GetValues(rowCount)),
        DataType.UInt64 => new InTermULong(owner, name, ((UInt64DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Single => new InTermFloat(owner, name, ((SingleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Double => new InTermDouble(owner, name, ((DoubleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Decimal => new InTermDecimal(owner, name, ((DecimalDataColumn)dataColumn).GetValues(rowCount)),
        DataType.String => new InTermString(owner, name, ((StringDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Guid => new InTermGuid(owner, name, ((GuidDataColumn)dataColumn).GetValues(rowCount)),
        DataType.DateTime => new InTermDateTime(owner, name, ((DateTimeDataColumn)dataColumn).GetValues(rowCount)),
        DataType.TimeSpan => new InTermTimeSpan(owner, name, ((TimeSpanDataColumn)dataColumn).GetValues(rowCount)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

    private static InTerm CreateNullableColumnCore(Query owner, string name, DataColumn dataColumn, int rowCount) => dataColumn.Type switch
    {
        DataType.Boolean => new InTermBool(owner, name, ((NullableBooleanDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Char => new InTermChar(owner, name, ((NullableCharDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.SByte => new InTermSByte(owner, name, ((NullableSByteDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Byte => new InTermByte(owner, name, ((NullableByteDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Int16 => new InTermShort(owner, name, ((NullableInt16DataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.UInt16 => new InTermUShort(owner, name, ((NullableUInt16DataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Int32 => new InTermInt(owner, name, ((NullableInt32DataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.UInt32 => new InTermUInt(owner, name, ((NullableUInt32DataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Int64 => new InTermLong(owner, name, ((NullableInt64DataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.UInt64 => new InTermULong(owner, name, ((NullableUInt64DataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Single => new InTermFloat(owner, name, ((NullableSingleDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Double => new InTermDouble(owner, name, ((NullableDoubleDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.Decimal => new InTermDecimal(owner, name, ((NullableDecimalDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.String => new InTermString(owner, name, ((NullableStringDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Guid => new InTermGuid(owner, name, ((NullableGuidDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.DateTime => new InTermDateTime(owner, name, ((NullableDateTimeDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        DataType.TimeSpan => new InTermTimeSpan(owner, name, ((NullableTimeSpanDataColumn)dataColumn).GetNonNullableValues(rowCount)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };
}
