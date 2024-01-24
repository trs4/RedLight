using System;

namespace RedLight;

internal sealed class BoolQueryParameter : QueryParameter
{
    public BoolQueryParameter(string name, bool value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Boolean;

    public override bool Nullable => false;
}

internal sealed class ByteQueryParameter : QueryParameter
{
    public ByteQueryParameter(string name, byte value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Byte;

    public override bool Nullable => false;
}

internal sealed class ShortQueryParameter : QueryParameter
{
    public ShortQueryParameter(string name, short value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Short;

    public override bool Nullable => false;
}

internal sealed class IntQueryParameter : QueryParameter
{
    public IntQueryParameter(string name, int value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Integer;

    public override bool Nullable => false;
}

internal sealed class LongQueryParameter : QueryParameter
{
    public LongQueryParameter(string name, long value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Long;

    public override bool Nullable => false;
}

internal sealed class FloatQueryParameter : QueryParameter
{
    public FloatQueryParameter(string name, float value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Float;

    public override bool Nullable => false;
}

internal sealed class DoubleQueryParameter : QueryParameter
{
    public DoubleQueryParameter(string name, double value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Double;

    public override bool Nullable => false;
}

internal sealed class DecimalQueryParameter : QueryParameter
{
    public DecimalQueryParameter(string name, decimal value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Decimal;

    public override bool Nullable => false;
}

internal sealed class StringQueryParameter : QueryParameter
{
    public StringQueryParameter(string name, string value) : base(name, value) { }

    public override ColumnType Type => ColumnType.String;

    public override bool Nullable => false;
}

internal sealed class GuidQueryParameter : QueryParameter
{
    public GuidQueryParameter(string name, Guid value) : base(name, value) { }

    public override ColumnType Type => ColumnType.Guid;

    public override bool Nullable => false;
}

internal sealed class ByteArrayQueryParameter : QueryParameter
{
    public ByteArrayQueryParameter(string name, byte[] value) : base(name, value) { }

    public override ColumnType Type => ColumnType.ByteArray;

    public override bool Nullable => false;
}

internal sealed class NullableBoolQueryParameter : QueryParameter
{
    public NullableBoolQueryParameter(string name, bool? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Boolean;

    public override bool Nullable => true;
}

internal sealed class NullableByteQueryParameter : QueryParameter
{
    public NullableByteQueryParameter(string name, byte? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Byte;

    public override bool Nullable => true;
}

internal sealed class NullableShortQueryParameter : QueryParameter
{
    public NullableShortQueryParameter(string name, short? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Short;

    public override bool Nullable => true;
}

internal sealed class NullableIntQueryParameter : QueryParameter
{
    public NullableIntQueryParameter(string name, int? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Integer;

    public override bool Nullable => true;
}

internal sealed class NullableLongQueryParameter : QueryParameter
{
    public NullableLongQueryParameter(string name, long? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Long;

    public override bool Nullable => true;
}

internal sealed class NullableFloatQueryParameter : QueryParameter
{
    public NullableFloatQueryParameter(string name, float? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Float;

    public override bool Nullable => true;
}

internal sealed class NullableDoubleQueryParameter : QueryParameter
{
    public NullableDoubleQueryParameter(string name, double? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Double;

    public override bool Nullable => true;
}

internal sealed class NullableDecimalQueryParameter : QueryParameter
{
    public NullableDecimalQueryParameter(string name, decimal? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Decimal;

    public override bool Nullable => true;
}

internal sealed class NullableGuidQueryParameter : QueryParameter
{
    public NullableGuidQueryParameter(string name, Guid? value) : base(name, value.HasValue ? value.Value : DBNull.Value) { }

    public override ColumnType Type => ColumnType.Guid;

    public override bool Nullable => true;
}

