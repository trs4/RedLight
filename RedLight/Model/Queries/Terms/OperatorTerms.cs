﻿using System;

namespace RedLight;

/// <summary>Условие с оператором bool</summary>
internal sealed class OperatorTermBool : OperatorTerm
{
    public OperatorTermBool(Query owner, string firstOperand, Op termOperator, bool secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public bool SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructBool(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором bool?</summary>
internal sealed class OperatorTermNullableBool : OperatorTerm
{
    public OperatorTermNullableBool(Query owner, string firstOperand, Op termOperator, bool? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public bool? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableBool(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором byte</summary>
internal sealed class OperatorTermByte : OperatorTerm
{
    public OperatorTermByte(Query owner, string firstOperand, Op termOperator, byte secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public byte SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructByte(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором byte?</summary>
internal sealed class OperatorTermNullableByte : OperatorTerm
{
    public OperatorTermNullableByte(Query owner, string firstOperand, Op termOperator, byte? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public byte? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableByte(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором short</summary>
internal sealed class OperatorTermShort : OperatorTerm
{
    public OperatorTermShort(Query owner, string firstOperand, Op termOperator, short secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public short SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructShort(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором short?</summary>
internal sealed class OperatorTermNullableShort : OperatorTerm
{
    public OperatorTermNullableShort(Query owner, string firstOperand, Op termOperator, short? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public short? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableShort(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором int</summary>
internal sealed class OperatorTermInt : OperatorTerm
{
    public OperatorTermInt(Query owner, string firstOperand, Op termOperator, int secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public int SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructInt(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором int?</summary>
internal sealed class OperatorTermNullableInt : OperatorTerm
{
    public OperatorTermNullableInt(Query owner, string firstOperand, Op termOperator, int? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public int? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableInt(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором long</summary>
internal sealed class OperatorTermLong : OperatorTerm
{
    public OperatorTermLong(Query owner, string firstOperand, Op termOperator, long secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public long SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructLong(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором long?</summary>
internal sealed class OperatorTermNullableLong : OperatorTerm
{
    public OperatorTermNullableLong(Query owner, string firstOperand, Op termOperator, long? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public long? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableLong(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором float</summary>
internal sealed class OperatorTermFloat : OperatorTerm
{
    public OperatorTermFloat(Query owner, string firstOperand, Op termOperator, float secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public float SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructFloat(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором float?</summary>
internal sealed class OperatorTermNullableFloat : OperatorTerm
{
    public OperatorTermNullableFloat(Query owner, string firstOperand, Op termOperator, float? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public float? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableFloat(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором double</summary>
internal sealed class OperatorTermDouble : OperatorTerm
{
    public OperatorTermDouble(Query owner, string firstOperand, Op termOperator, double secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public double SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructDouble(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором double?</summary>
internal sealed class OperatorTermNullableDouble : OperatorTerm
{
    public OperatorTermNullableDouble(Query owner, string firstOperand, Op termOperator, double? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public double? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableDouble(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором decimal</summary>
internal sealed class OperatorTermDecimal : OperatorTerm
{
    public OperatorTermDecimal(Query owner, string firstOperand, Op termOperator, decimal secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public decimal SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructDecimal(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором decimal?</summary>
internal sealed class OperatorTermNullableDecimal : OperatorTerm
{
    public OperatorTermNullableDecimal(Query owner, string firstOperand, Op termOperator, decimal? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public decimal? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableDecimal(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором string</summary>
internal sealed class OperatorTermString : OperatorTerm
{
    public OperatorTermString(Query owner, string firstOperand, Op termOperator, string secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public string SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructString(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором DateTime</summary>
internal sealed class OperatorTermDateTime : OperatorTerm
{
    public OperatorTermDateTime(Query owner, string firstOperand, Op termOperator, DateTime secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public DateTime SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructDateTime(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором DateTime?</summary>
internal sealed class OperatorTermNullableDateTime : OperatorTerm
{
    public OperatorTermNullableDateTime(Query owner, string firstOperand, Op termOperator, DateTime? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public DateTime? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableDateTime(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором Guid</summary>
internal sealed class OperatorTermGuid : OperatorTerm
{
    public OperatorTermGuid(Query owner, string firstOperand, Op termOperator, Guid secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public Guid SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructGuid(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором Guid?</summary>
internal sealed class OperatorTermNullableGuid : OperatorTerm
{
    public OperatorTermNullableGuid(Query owner, string firstOperand, Op termOperator, Guid? secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public Guid? SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructNullableGuid(Connection, options, SecondOperand);
}

/// <summary>Условие с оператором byte[]</summary>
internal sealed class OperatorTermByteArray : OperatorTerm
{
    public OperatorTermByteArray(Query owner, string firstOperand, Op termOperator, byte[] secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя колонки или значение)</summary>
    public byte[] SecondOperand { get; }

    protected sealed override string GetSecondOperand(QueryOptions options)
        => ParameterProcessing.ConstructByteArray(Connection, options, SecondOperand);
}

