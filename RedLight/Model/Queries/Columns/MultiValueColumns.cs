using System;
using System.Collections.Generic;
using RedLight.Internal;

namespace RedLight;

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class BoolMultiValueColumn : MultiValueColumn
{
    public BoolMultiValueColumn(string name, IReadOnlyList<bool> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<bool> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class CharMultiValueColumn : MultiValueColumn
{
    public CharMultiValueColumn(string name, IReadOnlyList<char> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<char> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class SByteMultiValueColumn : MultiValueColumn
{
    public SByteMultiValueColumn(string name, IReadOnlyList<sbyte> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<sbyte> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape((byte)Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ByteMultiValueColumn : MultiValueColumn
{
    public ByteMultiValueColumn(string name, IReadOnlyList<byte> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<byte> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ByteArrayMultiValueColumn : MultiValueColumn
{
    public ByteArrayMultiValueColumn(string name, IReadOnlyList<byte[]> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<byte[]> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ShortMultiValueColumn : MultiValueColumn
{
    public ShortMultiValueColumn(string name, IReadOnlyList<short> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<short> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class UShortMultiValueColumn : MultiValueColumn
{
    public UShortMultiValueColumn(string name, IReadOnlyList<ushort> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<ushort> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape((short)Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class IntMultiValueColumn : MultiValueColumn
{
    public IntMultiValueColumn(string name, IReadOnlyList<int> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<int> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class UIntMultiValueColumn : MultiValueColumn
{
    public UIntMultiValueColumn(string name, IReadOnlyList<uint> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<uint> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape((int)Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class LongMultiValueColumn : MultiValueColumn
{
    public LongMultiValueColumn(string name, IReadOnlyList<long> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<long> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ULongMultiValueColumn : MultiValueColumn
{
    public ULongMultiValueColumn(string name, IReadOnlyList<ulong> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<ulong> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape((long)Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class FloatMultiValueColumn : MultiValueColumn
{
    public FloatMultiValueColumn(string name, IReadOnlyList<float> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<float> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class DoubleMultiValueColumn : MultiValueColumn
{
    public DoubleMultiValueColumn(string name, IReadOnlyList<double> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<double> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class DecimalMultiValueColumn : MultiValueColumn
{
    public DecimalMultiValueColumn(string name, IReadOnlyList<decimal> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<decimal> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class StringMultiValueColumn : MultiValueColumn
{
    public StringMultiValueColumn(string name, IReadOnlyList<string> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<string> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class GuidMultiValueColumn : MultiValueColumn
{
    public GuidMultiValueColumn(string name, IReadOnlyList<Guid> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<Guid> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class DateTimeMultiValueColumn : MultiValueColumn
{
    public DateTimeMultiValueColumn(string name, IReadOnlyList<DateTime> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<DateTime> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class TimeSpanMultiValueColumn : MultiValueColumn
{
    public TimeSpanMultiValueColumn(string name, IReadOnlyList<TimeSpan> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<TimeSpan> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
        => connection.Escaping.Escape(Values[row]);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableBoolMultiValueColumn : MultiValueColumn
{
    public NullableBoolMultiValueColumn(string name, IReadOnlyList<bool?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<bool?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableCharMultiValueColumn : MultiValueColumn
{
    public NullableCharMultiValueColumn(string name, IReadOnlyList<char?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<char?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableSByteMultiValueColumn : MultiValueColumn
{
    public NullableSByteMultiValueColumn(string name, IReadOnlyList<sbyte?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<sbyte?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape((byte)value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableByteMultiValueColumn : MultiValueColumn
{
    public NullableByteMultiValueColumn(string name, IReadOnlyList<byte?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<byte?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableShortMultiValueColumn : MultiValueColumn
{
    public NullableShortMultiValueColumn(string name, IReadOnlyList<short?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<short?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableUShortMultiValueColumn : MultiValueColumn
{
    public NullableUShortMultiValueColumn(string name, IReadOnlyList<ushort?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<ushort?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape((short)value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableIntMultiValueColumn : MultiValueColumn
{
    public NullableIntMultiValueColumn(string name, IReadOnlyList<int?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<int?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableUIntMultiValueColumn : MultiValueColumn
{
    public NullableUIntMultiValueColumn(string name, IReadOnlyList<uint?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<uint?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape((int)value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableLongMultiValueColumn : MultiValueColumn
{
    public NullableLongMultiValueColumn(string name, IReadOnlyList<long?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<long?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableULongMultiValueColumn : MultiValueColumn
{
    public NullableULongMultiValueColumn(string name, IReadOnlyList<ulong?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<ulong?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape((long)value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableFloatMultiValueColumn : MultiValueColumn
{
    public NullableFloatMultiValueColumn(string name, IReadOnlyList<float?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<float?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableDoubleMultiValueColumn : MultiValueColumn
{
    public NullableDoubleMultiValueColumn(string name, IReadOnlyList<double?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<double?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableDecimalMultiValueColumn : MultiValueColumn
{
    public NullableDecimalMultiValueColumn(string name, IReadOnlyList<decimal?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<decimal?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableGuidMultiValueColumn : MultiValueColumn
{
    public NullableGuidMultiValueColumn(string name, IReadOnlyList<Guid?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<Guid?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableDateTimeMultiValueColumn : MultiValueColumn
{
    public NullableDateTimeMultiValueColumn(string name, IReadOnlyList<DateTime?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<DateTime?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableTimeSpanMultiValueColumn : MultiValueColumn
{
    public NullableTimeSpanMultiValueColumn(string name, IReadOnlyList<TimeSpan?> values)
        : base(name)
        => Values = values;

    public override int RowCount => Values.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<TimeSpan?> Values { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int row)
    {
        var value = Values[row];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

