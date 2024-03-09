using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using IcyRain.Tables;

namespace RedLight.Internal;

internal static class Extensions
{
    [MethodImpl(Flags.HotPath)]
    public static bool IsNullOrEmpty<T>(this T[] source) => source is null || source.Length == 0;

    [MethodImpl(Flags.HotPath)]
    public static bool IsNullOrEmpty<T>(this List<T> source) => source is null || source.Count == 0;

    public static bool IsCollection(this Type source) => source.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(ICollection<>));

    public static bool IsSystem(this Type source) => source.Namespace is not null && source.Namespace.StartsWith("System");

    public static bool IsNullable(this Type source) => source.IsGenericType && source.GetGenericTypeDefinition() == typeof(Nullable<>);

    [MethodImpl(Flags.HotPath)]
    public static IReadOnlyList<T> TakeIReadOnlyList<T>(this IEnumerable<T> source) => source as IReadOnlyList<T> ?? new List<T>(source);

    public static List<T> ToList<T>(T source) => ReferenceEquals(source, default) ? new() : new() { source };

    public static DateTime ConvertToLocal(this DatabaseConnection connection, DateTime value) => value.Kind switch
    {
        DateTimeKind.Unspecified => connection.Parameters.AutoConvertDatesInUTC
            ? new DateTime(value.Ticks, DateTimeKind.Utc).ToLocalTime() : new DateTime(value.Ticks, DateTimeKind.Local),
        DateTimeKind.Utc => value.ToLocalTime(),
        _ => value,
    };

    public static DateTime ConvertToParameter(this DatabaseConnection connection, DateTime value)
    {
        if (connection.Parameters.AutoConvertDatesInUTC && value.Kind == DateTimeKind.Local)
            value = value.ToUniversalTime();

        return value.Kind == DateTimeKind.Unspecified ? value : new DateTime(value.Ticks, DateTimeKind.Unspecified);
    }

    public static IReadOnlyList<string> NotNull(IReadOnlyList<string> value)
    {
        if (CanExit(value))
            return value;

        var result = new List<string>(value.Count);

        foreach (string item in value)
            result.Add(item ?? string.Empty);

        return result;
    }

    private static bool CanExit(IReadOnlyList<string> value)
    {
        if (value.Count == 0)
            return true;

        foreach (string item in value)
        {
            if (item is null)
                return false;
        }

        return true;
    }

    public static StringBuilder AppendJoin(this StringBuilder builder, string separator, params string[] value)
    {
        if (value.Length == 0)
            return builder;

        builder.Append(value[0]);

        for (int i = 1; i < value.Length; i++)
            builder.Append(separator).Append(value[i]);

        return builder;
    }

    public static StringBuilder AppendStrictEscapedTrim(this StringBuilder builder, Naming naming, string name)
    {
        naming.StrictEscapedTrim(builder, name);
        return builder;
    }

    [MethodImpl(Flags.HotPath)]
    public static int GetHash(DataColumn dataColumn) => GetHash(dataColumn.Type, dataColumn.IsNullable, dataColumn.IsArray);

    [MethodImpl(Flags.HotPath)]
    public static int GetHash(Column column) => column.Type switch
    {
        ColumnType.Boolean => GetHash(DataType.Boolean, isNullable: column.Nullable),
        ColumnType.Byte => GetHash(DataType.Byte, isNullable: column.Nullable),
        ColumnType.Short => GetHash(DataType.Int16, isNullable: column.Nullable),
        ColumnType.Integer => GetHash(DataType.Int32, isNullable: column.Nullable),
        ColumnType.Long => GetHash(DataType.Int64, isNullable: column.Nullable),
        ColumnType.Float => GetHash(DataType.Single, isNullable: column.Nullable),
        ColumnType.Double => GetHash(DataType.Double, isNullable: column.Nullable),
        ColumnType.Decimal => GetHash(DataType.Decimal, isNullable: column.Nullable),
        ColumnType.String => GetHash(DataType.String, isNullable: column.Nullable),
        ColumnType.Guid => GetHash(DataType.Guid, isNullable: column.Nullable),
        ColumnType.DateTime => GetHash(DataType.DateTime, isNullable: column.Nullable),
        ColumnType.TimeSpan => GetHash(DataType.TimeSpan, isNullable: column.Nullable),
        ColumnType.ByteArray => GetHash(DataType.Byte, isArray: true),
        _ => throw new NotSupportedException(column.Type.ToString()),
    };

    [MethodImpl(Flags.HotPath)]
    public static int GetHash(DataType type, bool isNullable = false, bool isArray = false)
    {
        if (isArray)
            return (int)type ^ (397 * 2);
        else if (isNullable)
            return (int)type ^ 397;

        return (int)type;
    }

    public static T Convert<T>(object value) => value is T tValue ? tValue : (T)Convert(value, typeof(T));

    public static object Convert(object value, Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        if (value is null)
            return type.IsClass || type.IsNullable() ? null : Activator.CreateInstance(type);

        var valueType = value.GetType();

        if (valueType.IsAssignableFrom(type))
            return value;

        if (type.IsNullable())
            return Convert(value, type.GetGenericArguments()[0]);

        if (type == typeof(string))
            return value.ToString();

        if (type == typeof(Guid))
        {
            if (value is string stringValue)
                return Guid.TryParse(stringValue, out var guid) ? guid : default;
        }

        return System.Convert.ChangeType(value, type);
    }

    public static string TrimWhitespaces(this string name) => name[0] == ' ' || name[^1] == ' ' ? name.Trim() : name;

    public static int GetPacketCount(int count, int packetSize) => (int)Math.Ceiling((double)count / packetSize);

    public static HashSet<string> GetExcludedColumnNames(IReadOnlyCollection<string> excludedColumns)
        => excludedColumns is null ? null : (excludedColumns as HashSet<string> ?? new HashSet<string>(excludedColumns, StringComparer.OrdinalIgnoreCase));
}