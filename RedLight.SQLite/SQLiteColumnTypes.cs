using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteColumnTypes : ColumnTypes<DbType>
{
    public static SQLiteColumnTypes Instance { get; } = new();

    private SQLiteColumnTypes()
    {
        _typeNames = new Dictionary<DbType, string>()
        {
            { DbType.AnsiString, "TEXT" },
            { DbType.Binary, "BLOB" },
            { DbType.Byte, "INTEGER" },
            { DbType.Boolean, "BOOLEAN" },
            { DbType.Currency, "DOUBLE" },
            { DbType.Date, "DATE" },
            { DbType.DateTime, "DATETIME" },
            { DbType.Decimal, "DOUBLE" },
            { DbType.Double, "DOUBLE" },
            { DbType.Guid, "TEXT" },
            { DbType.Int16, "INTEGER" },
            { DbType.Int32, "INTEGER" },
            { DbType.Int64, "INTEGER" },
            { DbType.SByte, "INTEGER" },
            { DbType.Single, "FLOAT" },
            { DbType.String, "TEXT" },
            { DbType.Time, "INTEGER" },
            { DbType.UInt16, "INTEGER" },
            { DbType.UInt32, "INTEGER" },
            { DbType.UInt64, "INTEGER" },
            { DbType.VarNumeric, "DOUBLE" },
            { DbType.AnsiStringFixedLength, "TEXT" },
            { DbType.StringFixedLength, "TEXT" },
            { DbType.Xml, "TEXT" },
            { DbType.DateTime2, "DATETIME" },
            { DbType.DateTimeOffset, "DATETIME" },
        }.ToFrozenDictionary();

        _nameTypes = new Dictionary<string, DbType>(StringComparer.OrdinalIgnoreCase)
        {
            { "BOOLEAN", DbType.Boolean },
            { "INTEGER", DbType.Int32 },
            { "FLOAT", DbType.Single },
            { "DOUBLE", DbType.Double },
            { "TEXT", DbType.String },
            { "DATETIME", DbType.DateTime },
            { "DATE", DbType.Date },
        }.ToFrozenDictionary();

        _types = new Dictionary<ColumnType, DbType>()
        {
            { ColumnType.Boolean, DbType.Boolean },
            { ColumnType.Byte, DbType.Byte },
            { ColumnType.Short, DbType.Int16 },
            { ColumnType.Integer, DbType.Int32 },
            { ColumnType.Long, DbType.Int64 },
            { ColumnType.Float, DbType.Single },
            { ColumnType.Double, DbType.Double },
            { ColumnType.Decimal, DbType.Decimal },
            { ColumnType.String, DbType.String },
            { ColumnType.DateTime, DbType.DateTime },
            { ColumnType.Guid, DbType.String },
            { ColumnType.TimeSpan, DbType.Int64 },
            { ColumnType.ByteArray, DbType.Binary },
        }.ToFrozenDictionary();

        _dataTypes = new Dictionary<DbType, ColumnType>()
        {
            { DbType.AnsiString, ColumnType.String },
            { DbType.Binary, ColumnType.ByteArray },
            { DbType.Byte, ColumnType.Byte },
            { DbType.Boolean, ColumnType.Boolean },
            { DbType.Currency, ColumnType.Decimal },
            { DbType.Date, ColumnType.DateTime },
            { DbType.DateTime, ColumnType.DateTime },
            { DbType.Decimal, ColumnType.Decimal },
            { DbType.Double, ColumnType.Double },
            { DbType.Guid, ColumnType.Guid },
            { DbType.Int16, ColumnType.Short },
            { DbType.Int32, ColumnType.Integer },
            { DbType.Int64, ColumnType.Long },
            { DbType.SByte, ColumnType.Byte },
            { DbType.Single, ColumnType.Float },
            { DbType.String, ColumnType.String },
            { DbType.Time, ColumnType.DateTime },
            { DbType.UInt16, ColumnType.Short },
            { DbType.UInt32, ColumnType.Integer },
            { DbType.UInt64, ColumnType.Long },
            { DbType.VarNumeric, ColumnType.Decimal },
            { DbType.AnsiStringFixedLength, ColumnType.String },
            { DbType.StringFixedLength, ColumnType.String },
            { DbType.Xml, ColumnType.String },
            { DbType.DateTime2, ColumnType.DateTime },
            { DbType.DateTimeOffset, ColumnType.DateTime },
        }.ToFrozenDictionary();

        _maxSizes = new Dictionary<DbType, int>()
        {
            { DbType.AnsiString, 8000 },
            { DbType.Binary, 8000 },
            { DbType.Byte, 1 },
            { DbType.Boolean, 1 },
            { DbType.Currency, 38 },
            { DbType.Decimal, 38 },
            { DbType.Double, 8 },
            { DbType.Guid, 32 },
            { DbType.Int16, 2 },
            { DbType.Int32, 4 },
            { DbType.Int64, 8 },
            { DbType.SByte, 1 },
            { DbType.Single, 4 },
            { DbType.Time, 8 },
            { DbType.UInt16, 2 },
            { DbType.UInt32, 4 },
            { DbType.UInt64, 8 },
        }.ToFrozenDictionary();

        _appendTypeOptions = new Dictionary<DbType, Action<StringBuilder, DbType, int, int>>().ToFrozenDictionary();

        _defaultValues = new Dictionary<ColumnType, string>()
        {
            { ColumnType.Boolean, "'0'" },
            { ColumnType.Byte, "0" },
            { ColumnType.Short, "0" },
            { ColumnType.Integer, "0" },
            { ColumnType.Long, "0" },
            { ColumnType.Float, "0" },
            { ColumnType.Double, "0" },
            { ColumnType.Decimal, "0" },
            { ColumnType.String, "''" },
            { ColumnType.Guid, $"'{Guid.Empty}'" },
            { ColumnType.DateTime, "(datetime(current_timestamp))" },
            { ColumnType.TimeSpan, "0" },
        }.ToFrozenDictionary();
    }

}
