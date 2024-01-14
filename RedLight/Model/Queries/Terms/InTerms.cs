using System;
using System.Collections.Generic;

namespace RedLight;

/// <summary>Условие по списку значений bool</summary>
internal sealed class InTermBool : InTerm<bool>
{
    public InTermBool(Query owner, string column, IReadOnlyList<bool> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(bool value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений byte</summary>
internal sealed class InTermByte : InTerm<byte>
{
    public InTermByte(Query owner, string column, IReadOnlyList<byte> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(byte value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений short</summary>
internal sealed class InTermShort : InTerm<short>
{
    public InTermShort(Query owner, string column, IReadOnlyList<short> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(short value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений int</summary>
internal sealed class InTermInt : InTerm<int>
{
    public InTermInt(Query owner, string column, IReadOnlyList<int> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(int value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений long</summary>
internal sealed class InTermLong : InTerm<long>
{
    public InTermLong(Query owner, string column, IReadOnlyList<long> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(long value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений float</summary>
internal sealed class InTermFloat : InTerm<float>
{
    public InTermFloat(Query owner, string column, IReadOnlyList<float> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(float value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений double</summary>
internal sealed class InTermDouble : InTerm<double>
{
    public InTermDouble(Query owner, string column, IReadOnlyList<double> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(double value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений decimal</summary>
internal sealed class InTermDecimal : InTerm<decimal>
{
    public InTermDecimal(Query owner, string column, IReadOnlyList<decimal> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(decimal value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений string</summary>
internal sealed class InTermString : InTerm<string>
{
    public InTermString(Query owner, string column, IReadOnlyList<string> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(string value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений DateTime</summary>
internal sealed class InTermDateTime : InTerm<DateTime>
{
    public InTermDateTime(Query owner, string column, IReadOnlyList<DateTime> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(DateTime value) => Connection.Escaping.Escape(value);
}

/// <summary>Условие по списку значений Guid</summary>
internal sealed class InTermGuid : InTerm<Guid>
{
    public InTermGuid(Query owner, string column, IReadOnlyList<Guid> values) : base(owner, column, values) { }

    protected sealed override string EscapeValue(Guid value) => Connection.Escaping.Escape(value);
}

