using System;
using IcyRain.Tables;

namespace RedLight;

public static class ValueTermExtensions
{
    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string columnName, DataColumn dataColumn, int row)
    {
        columnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            columnName = Naming.GetRawNameWithAlias(q.Alias, columnName);

        termBlock.AddTerm(CreateColumn(termBlock.Owner, columnName, Op.Equal, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm(this TermBlock termBlock, string columnName, Op termOperator, DataColumn dataColumn, int row)
    {
        columnName = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            columnName = Naming.GetRawNameWithAlias(q.Alias, columnName);

        termBlock.AddTerm(CreateColumn(termBlock.Owner, columnName, termOperator, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum columnName, DataColumn dataColumn, int row)
        where TEnum : Enum
    {
        string column = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            column = Naming.GetRawNameWithAlias(q.Alias, column);

        termBlock.AddTerm(CreateColumn(termBlock.Owner, column, Op.Equal, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm<TEnum>(this TermBlock termBlock, TEnum columnName, Op termOperator, DataColumn dataColumn, int row)
        where TEnum : Enum
    {
        string column = termBlock.Connection.Naming.GetName(columnName);

        if (termBlock.Owner is WhereQuery q && q.Alias is not null)
            column = Naming.GetRawNameWithAlias(q.Alias, column);

        termBlock.AddTerm(CreateColumn(termBlock.Owner, column, termOperator, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm(
        this TermBlock termBlock, string tableAlias, string columnName, DataColumn dataColumn, int row)
    {
        termBlock.AddTerm(CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), Op.Equal, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm(
        this TermBlock termBlock, string tableAlias, string columnName, Op termOperator, DataColumn dataColumn, int row)
    {
        termBlock.AddTerm(CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), termOperator, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 tableAlias, TEnum2 columnName, DataColumn dataColumn, int row)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), Op.Equal, dataColumn, row));
        return termBlock;
    }

    /// <summary>Добавляет условие по полю с значением</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="row">Индекс строки</param>
    public static TermBlock WithValueColumnTerm<TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 tableAlias, TEnum2 columnName, Op termOperator, DataColumn dataColumn, int row)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        termBlock.AddTerm(CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), termOperator, dataColumn, row));
        return termBlock;
    }

    private static OperatorTerm CreateColumn(Query owner, string name, Op termOperator, DataColumn dataColumn, int row)
        => dataColumn.IsNullable ? CreateNullableColumnCore(owner, name, termOperator, dataColumn, row) : CreateColumnCore(owner, name, termOperator, dataColumn, row);

    private static OperatorTerm CreateColumnCore(Query owner, string name, Op termOperator, DataColumn dataColumn, int row) => dataColumn.Type switch
    {
        DataType.Boolean => new OperatorTermBool(owner, name, termOperator, ((BooleanDataColumn)dataColumn).Get(row)),
        DataType.Char => new OperatorTermChar(owner, name, termOperator, ((CharDataColumn)dataColumn).Get(row)),
        DataType.SByte => new OperatorTermSByte(owner, name, termOperator, ((SByteDataColumn)dataColumn).Get(row)),
        DataType.Byte => new OperatorTermByte(owner, name, termOperator, ((ByteDataColumn)dataColumn).Get(row)),
        DataType.Int16 => new OperatorTermShort(owner, name, termOperator, ((Int16DataColumn)dataColumn).Get(row)),
        DataType.UInt16 => new OperatorTermUShort(owner, name, termOperator, ((UInt16DataColumn)dataColumn).Get(row)),
        DataType.Int32 => new OperatorTermInt(owner, name, termOperator, ((Int32DataColumn)dataColumn).Get(row)),
        DataType.UInt32 => new OperatorTermUInt(owner, name, termOperator, ((UInt32DataColumn)dataColumn).Get(row)),
        DataType.Int64 => new OperatorTermLong(owner, name, termOperator, ((Int64DataColumn)dataColumn).Get(row)),
        DataType.UInt64 => new OperatorTermULong(owner, name, termOperator, ((UInt64DataColumn)dataColumn).Get(row)),
        DataType.Single => new OperatorTermFloat(owner, name, termOperator, ((SingleDataColumn)dataColumn).Get(row)),
        DataType.Double => new OperatorTermDouble(owner, name, termOperator, ((DoubleDataColumn)dataColumn).Get(row)),
        DataType.Decimal => new OperatorTermDecimal(owner, name, termOperator, ((DecimalDataColumn)dataColumn).Get(row)),
        DataType.String => new OperatorTermString(owner, name, termOperator, ((StringDataColumn)dataColumn).Get(row)),
        DataType.Guid => new OperatorTermGuid(owner, name, termOperator, ((GuidDataColumn)dataColumn).Get(row)),
        DataType.DateTime => new OperatorTermDateTime(owner, name, termOperator, ((DateTimeDataColumn)dataColumn).Get(row)),
        DataType.TimeSpan => new OperatorTermTimeSpan(owner, name, termOperator, ((TimeSpanDataColumn)dataColumn).Get(row)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

    private static OperatorTerm CreateNullableColumnCore(Query owner, string name, Op termOperator, DataColumn dataColumn, int row) => dataColumn.Type switch
    {
        DataType.Boolean => new OperatorTermBool(owner, name, termOperator, ((NullableBooleanDataColumn)dataColumn).Get(row).Value),
        DataType.Char => new OperatorTermChar(owner, name, termOperator, ((NullableCharDataColumn)dataColumn).Get(row).Value),
        DataType.SByte => new OperatorTermSByte(owner, name, termOperator, ((NullableSByteDataColumn)dataColumn).Get(row).Value),
        DataType.Byte => new OperatorTermByte(owner, name, termOperator, ((NullableByteDataColumn)dataColumn).Get(row).Value),
        DataType.Int16 => new OperatorTermShort(owner, name, termOperator, ((NullableInt16DataColumn)dataColumn).Get(row).Value),
        DataType.UInt16 => new OperatorTermUShort(owner, name, termOperator, ((NullableUInt16DataColumn)dataColumn).Get(row).Value),
        DataType.Int32 => new OperatorTermInt(owner, name, termOperator, ((NullableInt32DataColumn)dataColumn).Get(row).Value),
        DataType.UInt32 => new OperatorTermUInt(owner, name, termOperator, ((NullableUInt32DataColumn)dataColumn).Get(row).Value),
        DataType.Int64 => new OperatorTermLong(owner, name, termOperator, ((NullableInt64DataColumn)dataColumn).Get(row).Value),
        DataType.UInt64 => new OperatorTermULong(owner, name, termOperator, ((NullableUInt64DataColumn)dataColumn).Get(row).Value),
        DataType.Single => new OperatorTermFloat(owner, name, termOperator, ((NullableSingleDataColumn)dataColumn).Get(row).Value),
        DataType.Double => new OperatorTermDouble(owner, name, termOperator, ((NullableDoubleDataColumn)dataColumn).Get(row).Value),
        DataType.Decimal => new OperatorTermDecimal(owner, name, termOperator, ((NullableDecimalDataColumn)dataColumn).Get(row).Value),
        DataType.String => new OperatorTermString(owner, name, termOperator, ((NullableStringDataColumn)dataColumn).Get(row)),
        DataType.Guid => new OperatorTermGuid(owner, name, termOperator, ((NullableGuidDataColumn)dataColumn).Get(row).Value),
        DataType.DateTime => new OperatorTermDateTime(owner, name, termOperator, ((NullableDateTimeDataColumn)dataColumn).Get(row).Value),
        DataType.TimeSpan => new OperatorTermTimeSpan(owner, name, termOperator, ((NullableTimeSpanDataColumn)dataColumn).Get(row).Value),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };
}
