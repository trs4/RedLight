using System.Data.Common;
using IcyRain.Tables;

namespace RedLight.Internal;

internal sealed class ColumnReadActionBool : ColumnReadAction
{
    private readonly BooleanDataColumn _column;

    public ColumnReadActionBool(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddBooleanColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetBoolean(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionByte : ColumnReadAction
{
    private readonly ByteDataColumn _column;

    public ColumnReadActionByte(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddByteColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetByte(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionShort : ColumnReadAction
{
    private readonly Int16DataColumn _column;

    public ColumnReadActionShort(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddInt16Column(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetInt16(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionInt : ColumnReadAction
{
    private readonly Int32DataColumn _column;

    public ColumnReadActionInt(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddInt32Column(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetInt32(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionLong : ColumnReadAction
{
    private readonly Int64DataColumn _column;

    public ColumnReadActionLong(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddInt64Column(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetInt64(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionFloat : ColumnReadAction
{
    private readonly SingleDataColumn _column;

    public ColumnReadActionFloat(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddSingleColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetFloat(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionDouble : ColumnReadAction
{
    private readonly DoubleDataColumn _column;

    public ColumnReadActionDouble(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddDoubleColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetDouble(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionDecimal : ColumnReadAction
{
    private readonly DecimalDataColumn _column;

    public ColumnReadActionDecimal(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddDecimalColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetDecimal(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionString : ColumnReadAction
{
    private readonly StringDataColumn _column;

    public ColumnReadActionString(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddStringColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetString(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionDateTime : ColumnReadAction
{
    private readonly DateTimeDataColumn _column;

    public ColumnReadActionDateTime(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddDateTimeColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetDateTime(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionGuid : ColumnReadAction
{
    private readonly GuidDataColumn _column;

    public ColumnReadActionGuid(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddGuidColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetGuid(_index));

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionByteArray : ColumnReadAction
{
    private readonly ByteArrayDataColumn _column;

    public ColumnReadActionByteArray(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddByteArrayColumn(name);

    public override void Read(DbDataReader reader, int row) => _column.Set(row, reader.GetValue(_index) as byte[]);

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableBool : ColumnReadAction
{
    private readonly NullableBooleanDataColumn _column;

    public ColumnReadActionNullableBool(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableBooleanColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetBoolean(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableByte : ColumnReadAction
{
    private readonly NullableByteDataColumn _column;

    public ColumnReadActionNullableByte(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableByteColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetByte(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableShort : ColumnReadAction
{
    private readonly NullableInt16DataColumn _column;

    public ColumnReadActionNullableShort(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableInt16Column(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetInt16(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableInt : ColumnReadAction
{
    private readonly NullableInt32DataColumn _column;

    public ColumnReadActionNullableInt(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableInt32Column(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetInt32(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableLong : ColumnReadAction
{
    private readonly NullableInt64DataColumn _column;

    public ColumnReadActionNullableLong(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableInt64Column(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetInt64(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableFloat : ColumnReadAction
{
    private readonly NullableSingleDataColumn _column;

    public ColumnReadActionNullableFloat(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableSingleColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetFloat(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableDouble : ColumnReadAction
{
    private readonly NullableDoubleDataColumn _column;

    public ColumnReadActionNullableDouble(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableDoubleColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetDouble(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableDecimal : ColumnReadAction
{
    private readonly NullableDecimalDataColumn _column;

    public ColumnReadActionNullableDecimal(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableDecimalColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetDecimal(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableString : ColumnReadAction
{
    private readonly NullableStringDataColumn _column;

    public ColumnReadActionNullableString(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableStringColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetString(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableDateTime : ColumnReadAction
{
    private readonly NullableDateTimeDataColumn _column;

    public ColumnReadActionNullableDateTime(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableDateTimeColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetDateTime(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

internal sealed class ColumnReadActionNullableGuid : ColumnReadAction
{
    private readonly NullableGuidDataColumn _column;

    public ColumnReadActionNullableGuid(DataTable dataTable, int index, string name)
        : base(index)
        => _column = dataTable.AddNullableGuidColumn(name);

    public override void Read(DbDataReader reader, int row)
    {
        if (reader.IsDBNull(_index))
            _column.Set(row, null);
        else
            _column.Set(row, reader.GetGuid(_index));
    }

    public override string ToString() => $"{_index} {_column.Type}";
}

