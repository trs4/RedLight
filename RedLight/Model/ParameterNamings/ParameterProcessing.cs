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
        var parameter = new BoolQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructByte(DatabaseConnection connection, QueryOptions options, byte value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new ByteQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructShort(DatabaseConnection connection, QueryOptions options, short value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new ShortQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructInt(DatabaseConnection connection, QueryOptions options, int value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new IntQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructLong(DatabaseConnection connection, QueryOptions options, long value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new LongQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructFloat(DatabaseConnection connection, QueryOptions options, float value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new FloatQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructDouble(DatabaseConnection connection, QueryOptions options, double value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new DoubleQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructDecimal(DatabaseConnection connection, QueryOptions options, decimal value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new DecimalQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructString(DatabaseConnection connection, QueryOptions options, string value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new StringQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructDateTime(DatabaseConnection connection, QueryOptions options, DateTime value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new DateTimeQueryParameter(connection, name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructTimeSpan(DatabaseConnection connection, QueryOptions options, TimeSpan value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new TimeSpanQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructGuid(DatabaseConnection connection, QueryOptions options, Guid value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new GuidQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructByteArray(DatabaseConnection connection, QueryOptions options, byte[] value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return connection.Escaping.Escape(value);

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new ByteArrayQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableBool(DatabaseConnection connection, QueryOptions options, bool? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableBoolQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableByte(DatabaseConnection connection, QueryOptions options, byte? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableByteQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableShort(DatabaseConnection connection, QueryOptions options, short? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableShortQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableInt(DatabaseConnection connection, QueryOptions options, int? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableIntQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableLong(DatabaseConnection connection, QueryOptions options, long? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableLongQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableFloat(DatabaseConnection connection, QueryOptions options, float? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableFloatQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableDouble(DatabaseConnection connection, QueryOptions options, double? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableDoubleQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableDecimal(DatabaseConnection connection, QueryOptions options, decimal? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableDecimalQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableDateTime(DatabaseConnection connection, QueryOptions options, DateTime? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableDateTimeQueryParameter(connection, name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableTimeSpan(DatabaseConnection connection, QueryOptions options, TimeSpan? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableTimeSpanQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

    public static string ConstructNullableGuid(DatabaseConnection connection, QueryOptions options, Guid? value)
    {
        if (!options.UseParameters || options.Parameters.Count == Consts.MaxQueryParameters)
            return value.HasValue ? connection.Escaping.Escape(value.Value) : Consts.Null;

        string name = connection.ParameterNaming.GetName(options.Parameters.Count + 1);
        var parameter = new NullableGuidQueryParameter(name, value);
        options.Parameters.Add(parameter);
        return connection.ParameterNaming.GetNameForQuery(name);
    }

}