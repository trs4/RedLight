using System;
using System.Collections.Generic;

namespace RedLight.Internal;

internal sealed class InTermActionBool : InTermAction<bool>
{
    public override InTerm<bool> Create(Query owner, string column, IReadOnlyList<bool> values) => new InTermBool(owner, column, values);
}

internal sealed class InTermActionByte : InTermAction<byte>
{
    public override InTerm<byte> Create(Query owner, string column, IReadOnlyList<byte> values) => new InTermByte(owner, column, values);
}

internal sealed class InTermActionShort : InTermAction<short>
{
    public override InTerm<short> Create(Query owner, string column, IReadOnlyList<short> values) => new InTermShort(owner, column, values);
}

internal sealed class InTermActionInt : InTermAction<int>
{
    public override InTerm<int> Create(Query owner, string column, IReadOnlyList<int> values) => new InTermInt(owner, column, values);
}

internal sealed class InTermActionLong : InTermAction<long>
{
    public override InTerm<long> Create(Query owner, string column, IReadOnlyList<long> values) => new InTermLong(owner, column, values);
}

internal sealed class InTermActionFloat : InTermAction<float>
{
    public override InTerm<float> Create(Query owner, string column, IReadOnlyList<float> values) => new InTermFloat(owner, column, values);
}

internal sealed class InTermActionDouble : InTermAction<double>
{
    public override InTerm<double> Create(Query owner, string column, IReadOnlyList<double> values) => new InTermDouble(owner, column, values);
}

internal sealed class InTermActionDecimal : InTermAction<decimal>
{
    public override InTerm<decimal> Create(Query owner, string column, IReadOnlyList<decimal> values) => new InTermDecimal(owner, column, values);
}

internal sealed class InTermActionString : InTermAction<string>
{
    public override InTerm<string> Create(Query owner, string column, IReadOnlyList<string> values) => new InTermString(owner, column, values);
}

internal sealed class InTermActionDateTime : InTermAction<DateTime>
{
    public override InTerm<DateTime> Create(Query owner, string column, IReadOnlyList<DateTime> values) => new InTermDateTime(owner, column, values);
}

internal sealed class InTermActionTimeSpan : InTermAction<TimeSpan>
{
    public override InTerm<TimeSpan> Create(Query owner, string column, IReadOnlyList<TimeSpan> values) => new InTermTimeSpan(owner, column, values);
}

internal sealed class InTermActionGuid : InTermAction<Guid>
{
    public override InTerm<Guid> Create(Query owner, string column, IReadOnlyList<Guid> values) => new InTermGuid(owner, column, values);
}

