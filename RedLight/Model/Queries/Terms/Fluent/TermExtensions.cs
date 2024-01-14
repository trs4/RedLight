using System;
using IcyRain.Tables;

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

    /// <summary>Добавляет условие по полю с значениеми</summary>
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

    /// <summary>Добавляет условие по полю с значениеми</summary>
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

    /// <summary>Добавляет условие по полю с значениеми</summary>
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

    /// <summary>Добавляет условие по полю с значениеми</summary>
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

    /// <summary>Добавляет условие по полю с значениеми</summary>
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

    /// <summary>Добавляет условие по полю с значениеми</summary>
    /// <param name="tableAlias">Псевдоним таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="dataColumn">Столбец данных</param>
    /// <param name="rowCount">Количество строк</param>
    public static TermBlock WithNotValuesColumnTerm<TQuery, TEnum1, TEnum2>(
        this TermBlock termBlock, TEnum1 tableAlias, TEnum2 columnName, DataColumn dataColumn, int rowCount)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        var term = CreateColumn(termBlock.Owner, termBlock.Connection.Naming.GetNameWithAlias(tableAlias, columnName), dataColumn, rowCount);
        term.Not = true;
        return termBlock;
    }

    internal static InTerm CreateColumn(Query owner, string name, DataColumn dataColumn, int rowCount)
        => dataColumn.IsNullable ? CreateNullableColumnCore(owner, name, dataColumn, rowCount) : CreateColumnCore(owner, name, dataColumn, rowCount);

    private static InTerm CreateColumnCore(Query owner, string name, DataColumn dataColumn, int rowCount) => dataColumn.Type switch
    {
        DataType.Boolean => new InTermBool(owner, name, ((BooleanDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Byte => new InTermByte(owner, name, ((ByteDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int16 => new InTermShort(owner, name, ((Int16DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int32 => new InTermInt(owner, name, ((Int32DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Int64 => new InTermLong(owner, name, ((Int64DataColumn)dataColumn).GetValues(rowCount)),
        DataType.Single => new InTermFloat(owner, name, ((SingleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Double => new InTermDouble(owner, name, ((DoubleDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Decimal => new InTermDecimal(owner, name, ((DecimalDataColumn)dataColumn).GetValues(rowCount)),
        DataType.String => new InTermString(owner, name, ((StringDataColumn)dataColumn).GetValues(rowCount)),
        DataType.DateTime => new InTermDateTime(owner, name, ((DateTimeDataColumn)dataColumn).GetValues(rowCount)),
        DataType.Guid => new InTermGuid(owner, name, ((GuidDataColumn)dataColumn).GetValues(rowCount)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };

#pragma warning disable CA1859 // Use concrete types when possible for improved performance
    private static InTerm CreateNullableColumnCore(Query owner, string name, DataColumn dataColumn, int rowCount) => dataColumn.Type switch
    {
        DataType.String => new InTermString(owner, name, ((NullableStringDataColumn)dataColumn).GetValues(rowCount)),
        _ => throw new NotSupportedException(dataColumn.GetType().FullName),
    };
#pragma warning restore CA1859 // Use concrete types when possible for improved performance
}
