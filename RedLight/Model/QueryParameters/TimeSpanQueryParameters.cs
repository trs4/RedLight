using System;

namespace RedLight;

internal sealed class TimeSpanQueryParameter : QueryParameter
{
    public TimeSpanQueryParameter(string name, TimeSpan value) : base(name, value.Ticks) { }

    public override ColumnType Type => ColumnType.TimeSpan;

    public override bool Nullable => false;
}

internal sealed class NullableTimeSpanQueryParameter : QueryParameter
{
    public NullableTimeSpanQueryParameter(string name, TimeSpan? value) : base(name, value.HasValue ? value.Value.Ticks : DBNull.Value) { }

    public override ColumnType Type => ColumnType.TimeSpan;

    public override bool Nullable => true;
}
