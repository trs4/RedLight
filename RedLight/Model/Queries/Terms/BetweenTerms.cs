using System;

namespace RedLight;

/// <summary>Условие с диапазоном по byte</summary>
internal sealed class BetweenTermByte : BetweenTerm
{
    public BetweenTermByte(Query owner, string column, byte beginValue, byte endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public byte BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public byte EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructByte(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructByte(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по short</summary>
internal sealed class BetweenTermShort : BetweenTerm
{
    public BetweenTermShort(Query owner, string column, short beginValue, short endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public short BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public short EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructShort(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructShort(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по int</summary>
internal sealed class BetweenTermInt : BetweenTerm
{
    public BetweenTermInt(Query owner, string column, int beginValue, int endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public int BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public int EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructInt(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructInt(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по long</summary>
internal sealed class BetweenTermLong : BetweenTerm
{
    public BetweenTermLong(Query owner, string column, long beginValue, long endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public long BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public long EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructLong(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructLong(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по float</summary>
internal sealed class BetweenTermFloat : BetweenTerm
{
    public BetweenTermFloat(Query owner, string column, float beginValue, float endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public float BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public float EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructFloat(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructFloat(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по double</summary>
internal sealed class BetweenTermDouble : BetweenTerm
{
    public BetweenTermDouble(Query owner, string column, double beginValue, double endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public double BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public double EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructDouble(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructDouble(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по decimal</summary>
internal sealed class BetweenTermDecimal : BetweenTerm
{
    public BetweenTermDecimal(Query owner, string column, decimal beginValue, decimal endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public decimal BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public decimal EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructDecimal(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructDecimal(Connection, options, EndValue);
}

/// <summary>Условие с диапазоном по DateTime</summary>
internal sealed class BetweenTermDateTime : BetweenTerm
{
    public BetweenTermDateTime(Query owner, string column, DateTime beginValue, DateTime endValue)
        : base(owner, column)
    {
        BeginValue = beginValue;
        EndValue = endValue;
    }

    /// <summary>Значение начала диапазона</summary>
    public DateTime BeginValue { get; }

    /// <summary>Значение конца диапазона</summary>
    public DateTime EndValue { get; }

    protected override string GetBeginValue(QueryOptions options)
        => ParameterProcessing.ConstructDateTime(Connection, options, BeginValue);

    protected override string GetEndValue(QueryOptions options)
        => ParameterProcessing.ConstructDateTime(Connection, options, EndValue);
}

