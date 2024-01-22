using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using RedLight.Internal;

namespace RedLight.SqlServer;

internal sealed class SqlServerColumnTypes : ColumnTypes<SqlDbType>
{
    public static SqlServerColumnTypes Instance { get; } = new();

    private SqlServerColumnTypes()
    {
        _typeNames = Enum.GetValues<SqlDbType>().ToDictionary(v => v, v => Enum.GetName(v).ToLower()).ToFrozenDictionary();
        _nameTypes = _typeNames.ToDictionary(p => p.Value, p => p.Key, StringComparer.OrdinalIgnoreCase).ToFrozenDictionary();

        _types = new Dictionary<ColumnType, SqlDbType>()
        {
            { ColumnType.Boolean, SqlDbType.Bit }, // Can be 0, 1, or nullNothingnullptra null reference
            { ColumnType.Byte, SqlDbType.TinyInt }, // 8-bit unsigned integer
            { ColumnType.Short, SqlDbType.SmallInt }, // 16-bit signed integer
            { ColumnType.Integer, SqlDbType.Int }, // 32-bit signed integer 
            { ColumnType.Long, SqlDbType.BigInt }, // 64-bit signed integer
            { ColumnType.Float, SqlDbType.Real }, // Range of -1.79E +308 through 1.79E +3
            { ColumnType.Double, SqlDbType.Float }, // Floating point number within the range of -3.40E +38 through 3.40E +38
            { ColumnType.Decimal, SqlDbType.Decimal }, // Fixed precision and scale numeric value between (-10^38) -1 and (10^38) -1
            { ColumnType.String, SqlDbType.NVarChar }, // Variable-length stream of Unicode characters ranging between 1 and 4,000 characters
            { ColumnType.DateTime, SqlDbType.DateTime }, // From January 1, 1753 to December 31, 9999
            { ColumnType.Guid, SqlDbType.UniqueIdentifier },
            { ColumnType.TimeSpan, SqlDbType.BigInt },
            { ColumnType.ByteArray, SqlDbType.VarBinary }, // Variable-length stream of binary data ranging between 1 and 8,000 bytes
        }.ToFrozenDictionary();

        _dataTypes = new Dictionary<SqlDbType, ColumnType>()
        {
            { SqlDbType.Bit, ColumnType.Boolean },
            { SqlDbType.TinyInt, ColumnType.Byte },
            { SqlDbType.SmallInt, ColumnType.Short },
            { SqlDbType.Int, ColumnType.Integer },
            { SqlDbType.BigInt, ColumnType.Long },
            { SqlDbType.Real, ColumnType.Float },
            { SqlDbType.SmallMoney, ColumnType.Float },
            { SqlDbType.Float, ColumnType.Double },
            { SqlDbType.Decimal, ColumnType.Decimal },
            { SqlDbType.Money, ColumnType.Decimal },
            { SqlDbType.Text, ColumnType.String },
            { SqlDbType.VarChar, ColumnType.String },
            { SqlDbType.NText, ColumnType.String },
            { SqlDbType.NVarChar, ColumnType.String },
            { SqlDbType.Char, ColumnType.String },
            { SqlDbType.NChar, ColumnType.String },
            { SqlDbType.SmallDateTime, ColumnType.DateTime },
            { SqlDbType.DateTime, ColumnType.DateTime },
            { SqlDbType.DateTime2, ColumnType.DateTime },
            { SqlDbType.Date, ColumnType.DateTime },
            { SqlDbType.Time, ColumnType.DateTime },
            { SqlDbType.DateTimeOffset, ColumnType.DateTime },
            { SqlDbType.UniqueIdentifier, ColumnType.Guid },
            { SqlDbType.Binary, ColumnType.ByteArray },
            { SqlDbType.VarBinary, ColumnType.ByteArray },
            { SqlDbType.Image, ColumnType.ByteArray },
        }.ToFrozenDictionary();

        _maxSizes = new Dictionary<SqlDbType, int>()
        {
            { SqlDbType.Text, 2147483647 }, // String
            { SqlDbType.VarChar, 2147483647 }, // String
            { SqlDbType.VarBinary, 2147483647 }, // ByteArray
            { SqlDbType.Structured, 2147483647 },
            { SqlDbType.NText, 1073741823 }, // String
            { SqlDbType.NVarChar, 1073741823 }, // String
            { SqlDbType.Char, 8000 }, // String
            { SqlDbType.Binary, 8000 }, // ByteArray
            { SqlDbType.NChar, 4000 }, // String
            { SqlDbType.Money, 38 }, // Допускается создать колонки DECIMAL(38,37) и в данном случае 38 не размер в байтах, а максимальное значение точности,
            { SqlDbType.Decimal, 38 }, // проверено на MS SQL Server 2008 R2 и MS SQL Server 2017 Enterprise
            { SqlDbType.UniqueIdentifier, 32 },
            { SqlDbType.SmallMoney, 8 },
            { SqlDbType.Date, 8 },
            { SqlDbType.DateTime, 8 },
            { SqlDbType.Time, 8 },
            { SqlDbType.Real, 8 },
            { SqlDbType.BigInt, 8 },
            { SqlDbType.Int, 4 },
            { SqlDbType.Float, 4 },
            { SqlDbType.SmallInt, 2 },
            { SqlDbType.Bit, 1 },
            { SqlDbType.TinyInt, 1 },
        }.ToFrozenDictionary();

        _appendTypeOptions = new Dictionary<SqlDbType, Action<StringBuilder, SqlDbType, int, int>>()
        {
            { SqlDbType.Decimal, AppendTypeOptions_Decimal },
            { SqlDbType.VarBinary, AppendTypeOptions_Text },
            { SqlDbType.NText, AppendTypeOptions_Text },
            { SqlDbType.NVarChar, AppendTypeOptions_Text },
        }.ToFrozenDictionary();

        _defaultValues = new Dictionary<ColumnType, string>().ToFrozenDictionary();
    }

    private void AppendTypeOptions_Decimal(StringBuilder builder, SqlDbType type, int size, int precision)
    {
        int maxSize = GetMaxSize(type);

        if (size < 0 || size > maxSize)
            size = maxSize;

        if (precision < 0)
            precision = Consts.DecimalScale;

        if (precision >= size)
            precision = size - 1;

        if (size > 0)
            builder.Append(" (").Append(size).Append(',').Append(precision).Append(')');
    }

    private void AppendTypeOptions_Text(StringBuilder builder, SqlDbType type, int size, int precision)
    {
        int maxSize = GetMaxSize(type);

        if (size > 0 && size < maxSize)
            builder.Append(" (").Append(size).Append(')');
        else
            builder.Append(" (MAX)");
    }

}
