using System;
using System.Data.Common;

namespace RedLight.Internal;

internal sealed class ScalarReadActionBool : ScalarReadAction<bool>
{
    public override bool Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetBoolean(index);
}

internal sealed class ScalarReadActionChar : ScalarReadAction<char>
{
    public override char Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetChar(index);
}

internal sealed class ScalarReadActionSByte : ScalarReadAction<sbyte>
{
    public override sbyte Read(DatabaseConnection connection, DbDataReader reader, int index) => (sbyte)reader.GetByte(index);
}

internal sealed class ScalarReadActionByte : ScalarReadAction<byte>
{
    public override byte Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetByte(index);
}

internal sealed class ScalarReadActionByteArray : ScalarReadAction<byte[]>
{
    public override byte[] Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetValue(index) as byte[];
}

internal sealed class ScalarReadActionShort : ScalarReadAction<short>
{
    public override short Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetInt16(index);
}

internal sealed class ScalarReadActionUShort : ScalarReadAction<ushort>
{
    public override ushort Read(DatabaseConnection connection, DbDataReader reader, int index) => (ushort)reader.GetInt16(index);
}

internal sealed class ScalarReadActionInt : ScalarReadAction<int>
{
    public override int Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetInt32(index);
}

internal sealed class ScalarReadActionUInt : ScalarReadAction<uint>
{
    public override uint Read(DatabaseConnection connection, DbDataReader reader, int index) => (uint)reader.GetInt32(index);
}

internal sealed class ScalarReadActionLong : ScalarReadAction<long>
{
    public override long Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetInt64(index);
}

internal sealed class ScalarReadActionULong : ScalarReadAction<ulong>
{
    public override ulong Read(DatabaseConnection connection, DbDataReader reader, int index) => (ulong)reader.GetInt64(index);
}

internal sealed class ScalarReadActionFloat : ScalarReadAction<float>
{
    public override float Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetFloat(index);
}

internal sealed class ScalarReadActionDouble : ScalarReadAction<double>
{
    public override double Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetDouble(index);
}

internal sealed class ScalarReadActionDecimal : ScalarReadAction<decimal>
{
    public override decimal Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetDecimal(index);
}

internal sealed class ScalarReadActionString : ScalarReadAction<string>
{
    public override string Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetString(index);
}

internal sealed class ScalarReadActionGuid : ScalarReadAction<Guid>
{
    public override Guid Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.GetGuid(index);
}

internal sealed class ScalarReadActionDateTime : ScalarReadAction<DateTime>
{
    public override DateTime Read(DatabaseConnection connection, DbDataReader reader, int index) => connection.ConvertToLocal(reader.GetDateTime(index));
}

internal sealed class ScalarReadActionTimeSpan : ScalarReadAction<TimeSpan>
{
    public override TimeSpan Read(DatabaseConnection connection, DbDataReader reader, int index) => new TimeSpan(reader.GetInt64(index));
}

internal sealed class ScalarReadActionNullableBool : ScalarReadAction<bool?>
{
    public override bool? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetBoolean(index);
}

internal sealed class ScalarReadActionNullableChar : ScalarReadAction<char?>
{
    public override char? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetChar(index);
}

internal sealed class ScalarReadActionNullableSByte : ScalarReadAction<sbyte?>
{
    public override sbyte? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : (sbyte)reader.GetByte(index);
}

internal sealed class ScalarReadActionNullableByte : ScalarReadAction<byte?>
{
    public override byte? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetByte(index);
}

internal sealed class ScalarReadActionNullableShort : ScalarReadAction<short?>
{
    public override short? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetInt16(index);
}

internal sealed class ScalarReadActionNullableUShort : ScalarReadAction<ushort?>
{
    public override ushort? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : (ushort)reader.GetInt16(index);
}

internal sealed class ScalarReadActionNullableInt : ScalarReadAction<int?>
{
    public override int? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetInt32(index);
}

internal sealed class ScalarReadActionNullableUInt : ScalarReadAction<uint?>
{
    public override uint? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : (uint)reader.GetInt32(index);
}

internal sealed class ScalarReadActionNullableLong : ScalarReadAction<long?>
{
    public override long? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetInt64(index);
}

internal sealed class ScalarReadActionNullableULong : ScalarReadAction<ulong?>
{
    public override ulong? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : (ulong)reader.GetInt64(index);
}

internal sealed class ScalarReadActionNullableFloat : ScalarReadAction<float?>
{
    public override float? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetFloat(index);
}

internal sealed class ScalarReadActionNullableDouble : ScalarReadAction<double?>
{
    public override double? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetDouble(index);
}

internal sealed class ScalarReadActionNullableDecimal : ScalarReadAction<decimal?>
{
    public override decimal? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetDecimal(index);
}

internal sealed class ScalarReadActionNullableString : ScalarReadAction<string>
{
    public override string Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetString(index);
}

internal sealed class ScalarReadActionNullableGuid : ScalarReadAction<Guid?>
{
    public override Guid? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : reader.GetGuid(index);
}

internal sealed class ScalarReadActionNullableDateTime : ScalarReadAction<DateTime?>
{
    public override DateTime? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : connection.ConvertToLocal(reader.GetDateTime(index));
}

internal sealed class ScalarReadActionNullableTimeSpan : ScalarReadAction<TimeSpan?>
{
    public override TimeSpan? Read(DatabaseConnection connection, DbDataReader reader, int index) => reader.IsDBNull(index) ? null : new TimeSpan(reader.GetInt64(index));
}

