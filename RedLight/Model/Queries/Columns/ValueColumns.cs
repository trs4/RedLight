using System;

namespace RedLight;

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class BoolValueColumn : ValueColumn
{
    public BoolValueColumn(string name, bool value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public bool Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructBool(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableBoolValueColumn : ValueColumn
{
    public NullableBoolValueColumn(string name, bool? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public bool? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableBool(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ByteValueColumn : ValueColumn
{
    public ByteValueColumn(string name, byte value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public byte Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructByte(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableByteValueColumn : ValueColumn
{
    public NullableByteValueColumn(string name, byte? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public byte? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableByte(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ShortValueColumn : ValueColumn
{
    public ShortValueColumn(string name, short value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public short Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructShort(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableShortValueColumn : ValueColumn
{
    public NullableShortValueColumn(string name, short? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public short? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableShort(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class IntValueColumn : ValueColumn
{
    public IntValueColumn(string name, int value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public int Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructInt(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableIntValueColumn : ValueColumn
{
    public NullableIntValueColumn(string name, int? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public int? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableInt(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class LongValueColumn : ValueColumn
{
    public LongValueColumn(string name, long value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public long Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructLong(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableLongValueColumn : ValueColumn
{
    public NullableLongValueColumn(string name, long? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public long? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableLong(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class FloatValueColumn : ValueColumn
{
    public FloatValueColumn(string name, float value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public float Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructFloat(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableFloatValueColumn : ValueColumn
{
    public NullableFloatValueColumn(string name, float? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public float? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableFloat(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class DoubleValueColumn : ValueColumn
{
    public DoubleValueColumn(string name, double value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public double Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructDouble(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableDoubleValueColumn : ValueColumn
{
    public NullableDoubleValueColumn(string name, double? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public double? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableDouble(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class DecimalValueColumn : ValueColumn
{
    public DecimalValueColumn(string name, decimal value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public decimal Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructDecimal(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableDecimalValueColumn : ValueColumn
{
    public NullableDecimalValueColumn(string name, decimal? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public decimal? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableDecimal(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class StringValueColumn : ValueColumn
{
    public StringValueColumn(string name, string value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public string Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructString(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class DateTimeValueColumn : ValueColumn
{
    public DateTimeValueColumn(string name, DateTime value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public DateTime Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructDateTime(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableDateTimeValueColumn : ValueColumn
{
    public NullableDateTimeValueColumn(string name, DateTime? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public DateTime? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableDateTime(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class TimeSpanValueColumn : ValueColumn
{
    public TimeSpanValueColumn(string name, TimeSpan value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public TimeSpan Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructTimeSpan(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableTimeSpanValueColumn : ValueColumn
{
    public NullableTimeSpanValueColumn(string name, TimeSpan? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public TimeSpan? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableTimeSpan(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class GuidValueColumn : ValueColumn
{
    public GuidValueColumn(string name, Guid value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public Guid Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructGuid(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class NullableGuidValueColumn : ValueColumn
{
    public NullableGuidValueColumn(string name, Guid? value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public Guid? Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructNullableGuid(connection, options, Value);
}

/// <summary>Конструктор поля для изменения данных</summary>
internal sealed class ByteArrayValueColumn : ValueColumn
{
    public ByteArrayValueColumn(string name, byte[] value)
        : base(name)
        => Value = value;

    /// <summary>Значение поля</summary>
    public byte[] Value { get; }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options)
        => ParameterProcessing.ConstructByteArray(connection, options, Value);
}

