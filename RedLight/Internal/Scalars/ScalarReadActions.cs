using System;
using System.Data.Common;

namespace RedLight.Internal;

internal sealed class ScalarReadActionBool : ScalarReadAction<bool>
{
    public override bool Read(DbDataReader reader, int index) => reader.GetBoolean(index);
}

internal sealed class ScalarReadActionByte : ScalarReadAction<byte>
{
    public override byte Read(DbDataReader reader, int index) => reader.GetByte(index);
}

internal sealed class ScalarReadActionShort : ScalarReadAction<short>
{
    public override short Read(DbDataReader reader, int index) => reader.GetInt16(index);
}

internal sealed class ScalarReadActionInt : ScalarReadAction<int>
{
    public override int Read(DbDataReader reader, int index) => reader.GetInt32(index);
}

internal sealed class ScalarReadActionLong : ScalarReadAction<long>
{
    public override long Read(DbDataReader reader, int index) => reader.GetInt64(index);
}

internal sealed class ScalarReadActionFloat : ScalarReadAction<float>
{
    public override float Read(DbDataReader reader, int index) => reader.GetFloat(index);
}

internal sealed class ScalarReadActionDouble : ScalarReadAction<double>
{
    public override double Read(DbDataReader reader, int index) => reader.GetDouble(index);
}

internal sealed class ScalarReadActionDecimal : ScalarReadAction<decimal>
{
    public override decimal Read(DbDataReader reader, int index) => reader.GetDecimal(index);
}

internal sealed class ScalarReadActionString : ScalarReadAction<string>
{
    public override string Read(DbDataReader reader, int index) => reader.GetString(index);
}

internal sealed class ScalarReadActionDateTime : ScalarReadAction<DateTime>
{
    public override DateTime Read(DbDataReader reader, int index) => reader.GetDateTime(index);
}

internal sealed class ScalarReadActionTimeSpan : ScalarReadAction<TimeSpan>
{
    public override TimeSpan Read(DbDataReader reader, int index) => new TimeSpan(reader.GetInt64(index));
}

internal sealed class ScalarReadActionGuid : ScalarReadAction<Guid>
{
    public override Guid Read(DbDataReader reader, int index) => reader.GetGuid(index);
}

internal sealed class ScalarReadActionByteArray : ScalarReadAction<byte[]>
{
    public override byte[] Read(DbDataReader reader, int index) => reader.GetValue(index) as byte[];
}

internal sealed class ScalarReadActionNullableBool : ScalarReadAction<bool?>
{
    public override bool? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetBoolean(index);
}

internal sealed class ScalarReadActionNullableByte : ScalarReadAction<byte?>
{
    public override byte? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetByte(index);
}

internal sealed class ScalarReadActionNullableShort : ScalarReadAction<short?>
{
    public override short? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetInt16(index);
}

internal sealed class ScalarReadActionNullableInt : ScalarReadAction<int?>
{
    public override int? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetInt32(index);
}

internal sealed class ScalarReadActionNullableLong : ScalarReadAction<long?>
{
    public override long? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetInt64(index);
}

internal sealed class ScalarReadActionNullableFloat : ScalarReadAction<float?>
{
    public override float? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetFloat(index);
}

internal sealed class ScalarReadActionNullableDouble : ScalarReadAction<double?>
{
    public override double? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetDouble(index);
}

internal sealed class ScalarReadActionNullableDecimal : ScalarReadAction<decimal?>
{
    public override decimal? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetDecimal(index);
}

internal sealed class ScalarReadActionNullableString : ScalarReadAction<string>
{
    public override string Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetString(index);
}

internal sealed class ScalarReadActionNullableDateTime : ScalarReadAction<DateTime?>
{
    public override DateTime? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetDateTime(index);
}

internal sealed class ScalarReadActionNullableTimeSpan : ScalarReadAction<TimeSpan?>
{
    public override TimeSpan? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : new TimeSpan(reader.GetInt64(index));
}

internal sealed class ScalarReadActionNullableGuid : ScalarReadAction<Guid?>
{
    public override Guid? Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetGuid(index);
}

internal sealed class ScalarReadActionNullableByteArray : ScalarReadAction<byte[]>
{
    public override byte[] Read(DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetValue(index) as byte[];
}

