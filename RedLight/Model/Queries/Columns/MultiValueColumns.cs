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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
        => connection.Escaping.Escape(Values[rowIndex]);
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
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

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex)
    {
        var value = Values[rowIndex];
        return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;
    }

}

