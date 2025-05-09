using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteColumnTypes : ColumnTypes<SqliteType>
{
    public static SQLiteColumnTypes Instance { get; } = new();

    private SQLiteColumnTypes()
    {
        _typeNames = new Dictionary<SqliteType, string>()
        {
            { SqliteType.Text, "TEXT" },
            { SqliteType.Blob, "BLOB" },
            { SqliteType.Integer, "INTEGER" },
            { SqliteType.Real, "DOUBLE" },
        }.ToFrozenDictionary();

        _nameTypes = new Dictionary<string, SqliteType>(StringComparer.OrdinalIgnoreCase)
        {
            { "BOOLEAN", SqliteType.Integer },
            { "INTEGER", SqliteType.Integer },
            { "FLOAT", SqliteType.Real },
            { "DOUBLE", SqliteType.Real },
            { "TEXT", SqliteType.Text },
            { "DATETIME", SqliteType.Text },
            { "DATE", SqliteType.Text },
        }.ToFrozenDictionary();

        _types = new Dictionary<ColumnType, SqliteType>()
        {
            { ColumnType.Boolean, SqliteType.Integer },
            { ColumnType.Byte, SqliteType.Integer },
            { ColumnType.Short, SqliteType.Integer },
            { ColumnType.Integer, SqliteType.Integer },
            { ColumnType.Long, SqliteType.Integer },
            { ColumnType.Float, SqliteType.Real },
            { ColumnType.Double, SqliteType.Real },
            { ColumnType.Decimal, SqliteType.Real },
            { ColumnType.String, SqliteType.Text },
            { ColumnType.DateTime, SqliteType.Text },
            { ColumnType.Guid, SqliteType.Text },
            { ColumnType.TimeSpan, SqliteType.Text },
            { ColumnType.ByteArray, SqliteType.Blob },
        }.ToFrozenDictionary();

        _dataTypes = new Dictionary<SqliteType, ColumnType>()
        {
            { SqliteType.Text, ColumnType.String },
            { SqliteType.Blob, ColumnType.ByteArray },
            { SqliteType.Real, ColumnType.Double },
            { SqliteType.Integer, ColumnType.Integer },
        }.ToFrozenDictionary();

        _maxSizes = new Dictionary<SqliteType, int>()
        {
            { SqliteType.Text, 8000 },
            { SqliteType.Blob, 8000 },
            { SqliteType.Real, 8 },
            { SqliteType.Integer, 4 },
        }.ToFrozenDictionary();

        _appendTypeOptions = new Dictionary<SqliteType, Action<StringBuilder, SqliteType, int, int>>().ToFrozenDictionary();

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
