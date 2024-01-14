using System;
using RedLight.Internal;

namespace RedLight;

/// <summary>Добавление параметров в запрос</summary>
internal static class ParameterProcessing
{
    public static string ConstructBool(DatabaseConnection connection, QueryOptions options, bool value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Boolean, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructByte(DatabaseConnection connection, QueryOptions options, byte value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Byte, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructShort(DatabaseConnection connection, QueryOptions options, short value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Short, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructInt(DatabaseConnection connection, QueryOptions options, int value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Integer, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructLong(DatabaseConnection connection, QueryOptions options, long value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Long, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructFloat(DatabaseConnection connection, QueryOptions options, float value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Float, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructDouble(DatabaseConnection connection, QueryOptions options, double value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Double, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructDecimal(DatabaseConnection connection, QueryOptions options, decimal value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Decimal, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructString(DatabaseConnection connection, QueryOptions options, string value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.String, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructDateTime(DatabaseConnection connection, QueryOptions options, DateTime value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.DateTime, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructGuid(DatabaseConnection connection, QueryOptions options, Guid value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Guid, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructByteArray(DatabaseConnection connection, QueryOptions options, byte[] value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.ByteArray, false);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableBool(DatabaseConnection connection, QueryOptions options, bool? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Boolean, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableByte(DatabaseConnection connection, QueryOptions options, byte? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Byte, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableShort(DatabaseConnection connection, QueryOptions options, short? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Short, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableInt(DatabaseConnection connection, QueryOptions options, int? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Integer, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableLong(DatabaseConnection connection, QueryOptions options, long? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Long, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableFloat(DatabaseConnection connection, QueryOptions options, float? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Float, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableDouble(DatabaseConnection connection, QueryOptions options, double? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Double, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableDecimal(DatabaseConnection connection, QueryOptions options, decimal? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Decimal, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableDateTime(DatabaseConnection connection, QueryOptions options, DateTime? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.DateTime, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableGuid(DatabaseConnection connection, QueryOptions options, Guid? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new QueryParameter(name, value, ColumnType.Guid, true);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

}