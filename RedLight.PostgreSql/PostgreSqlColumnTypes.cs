using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NpgsqlTypes;
using RedLight.Internal;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlColumnTypes : ColumnTypes<NpgsqlDbType>
{
    public static PostgreSqlColumnTypes Instance { get; } = new();

    private PostgreSqlColumnTypes()
    {
        _typeNames = Enum.GetValues<NpgsqlDbType>().ToDictionary(v => v, v => Enum.GetName(v).ToLower()).ToFrozenDictionary();
        var nameTypes = _typeNames.ToDictionary(p => p.Value, p => p.Key, StringComparer.OrdinalIgnoreCase);
        nameTypes.Add("character", NpgsqlDbType.Varchar);
        _nameTypes = nameTypes.ToFrozenDictionary();

        _types = new Dictionary<ColumnType, NpgsqlDbType>()
        {
            { ColumnType.Boolean, NpgsqlDbType.Boolean },
            { ColumnType.Byte, NpgsqlDbType.Smallint },
            { ColumnType.Short, NpgsqlDbType.Smallint },
            { ColumnType.Integer, NpgsqlDbType.Integer },
            { ColumnType.Long, NpgsqlDbType.Bigint },
            { ColumnType.Float, NpgsqlDbType.Real },
            { ColumnType.Double, NpgsqlDbType.Double },
            { ColumnType.Decimal, NpgsqlDbType.Numeric },
            { ColumnType.String, NpgsqlDbType.Varchar },
            { ColumnType.DateTime, NpgsqlDbType.Timestamp },
            { ColumnType.Guid, NpgsqlDbType.Uuid },
            { ColumnType.TimeSpan, NpgsqlDbType.Bigint },
            { ColumnType.ByteArray, NpgsqlDbType.Bytea },
        }.ToFrozenDictionary();

        _dataTypes = new Dictionary<NpgsqlDbType, ColumnType>()
        {
            { NpgsqlDbType.Bigint, ColumnType.Long },
            { NpgsqlDbType.Double, ColumnType.Double },
            { NpgsqlDbType.Integer, ColumnType.Integer },
            { NpgsqlDbType.Numeric, ColumnType.Decimal },
            { NpgsqlDbType.Real, ColumnType.Float },
            { NpgsqlDbType.Smallint, ColumnType.Byte },
            { NpgsqlDbType.Money, ColumnType.Decimal },
            { NpgsqlDbType.Boolean, ColumnType.Boolean },
            { NpgsqlDbType.Char, ColumnType.String },
            { NpgsqlDbType.Text, ColumnType.String },
            { NpgsqlDbType.Varchar, ColumnType.String },
            { NpgsqlDbType.Name, ColumnType.String },
            { NpgsqlDbType.Citext, ColumnType.String },
            { NpgsqlDbType.Bytea, ColumnType.ByteArray },
            { NpgsqlDbType.Date, ColumnType.DateTime },
            { NpgsqlDbType.Time, ColumnType.DateTime },
            { NpgsqlDbType.Timestamp, ColumnType.DateTime },
            { NpgsqlDbType.TimestampTz, ColumnType.DateTime },
            { NpgsqlDbType.TimeTz, ColumnType.DateTime },
            { NpgsqlDbType.Uuid, ColumnType.Guid },
            { NpgsqlDbType.Xml, ColumnType.String },
            { NpgsqlDbType.Json, ColumnType.String },
        }.ToFrozenDictionary();

        _maxSizes = new Dictionary<NpgsqlDbType, int>()
        {
            { NpgsqlDbType.Array, 2147483647 },
            { NpgsqlDbType.Text, 1073741823 },
            { NpgsqlDbType.Varchar, 1073741823 },
            { NpgsqlDbType.Char, 1073741823 },
            { NpgsqlDbType.Bytea, 1073741823 },
            { NpgsqlDbType.Money, 38 },
            { NpgsqlDbType.Numeric, 38 },
            { NpgsqlDbType.Uuid, 32 },
            { NpgsqlDbType.Date, 8 },
            { NpgsqlDbType.Time, 8 },
            { NpgsqlDbType.Bigint, 8 },
            { NpgsqlDbType.Integer, 4 },
            { NpgsqlDbType.Real, 4 },
            { NpgsqlDbType.Smallint, 2 },
            { NpgsqlDbType.Bit, 1 },
        }.ToFrozenDictionary();

        _appendTypeOptions = new Dictionary<NpgsqlDbType, Action<StringBuilder, NpgsqlDbType, int, int>>()
        {
            { NpgsqlDbType.Numeric, AppendTypeOptions_Decimal },
            { NpgsqlDbType.Money, AppendTypeOptions_Decimal },
            { NpgsqlDbType.Bytea, AppendTypeOptions_Text },
            { NpgsqlDbType.Char, AppendTypeOptions_Text },
            { NpgsqlDbType.Text, AppendTypeOptions_Text },
            { NpgsqlDbType.Varchar, AppendTypeOptions_Text },
            { NpgsqlDbType.Name, AppendTypeOptions_Text },
            { NpgsqlDbType.Real, AppendTypeOptions_Float },
            { NpgsqlDbType.Timestamp, AppendTypeOptions_DateTime },
        }.ToFrozenDictionary();
    }

    private void AppendTypeOptions_DateTime(StringBuilder builder, NpgsqlDbType type, int size, int precision)
        => builder.Append(" WITHOUT TIME ZONE");

    private void AppendTypeOptions_Float(StringBuilder builder, NpgsqlDbType type, int size, int precision)
        => builder.Append(" precision");

    private void AppendTypeOptions_Decimal(StringBuilder builder, NpgsqlDbType type, int size, int precision)
    {
        int maxSize = GetMaxSize(type);
        if (size < 0 || size > maxSize)
            size = maxSize;

        if (precision < 0)
            precision = 10;

        if (precision >= size)
            precision = size - 1;

        if (size > 0)
            builder.Append(" (").Append(size).Append(',').Append(precision).Append(')');
    }

    private void AppendTypeOptions_Text(StringBuilder builder, NpgsqlDbType type, int size, int precision)
    {
        int maxSize = GetMaxSize(type);

        if (size <= 0 || size > maxSize)
            size = maxSize;

        if (size == maxSize)
            return;

        if (type != NpgsqlDbType.Bytea)
            builder.Append(" (").Append(size).Append(')');
    }

    public override ColumnType GetType(string stringDataType)
    {
        int index = stringDataType.IndexOf(' ');

        if (index > 0)
            stringDataType = stringDataType.Substring(0, index);

        return base.GetType(stringDataType);
    }

}
