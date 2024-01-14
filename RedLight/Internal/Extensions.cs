using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class Extensions
{
    [MethodImpl(Flags.HotPath)]
    public static bool IsNullOrEmpty<T>(this T[] source) => source is null || source.Length == 0;

    [MethodImpl(Flags.HotPath)]
    public static bool IsNullOrEmpty<T>(this List<T> source) => source is null || source.Count == 0;

    public static bool IsCollection(this Type source) => source.GetInterfaces().Any(t => t.IsGenericType && t == typeof(ICollection<>));

    public static bool IsSystem(this Type source) => source.Namespace is not null && source.Namespace.StartsWith("System");

    public static bool IsNullable(this Type source) => source.IsGenericType && source.GetGenericTypeDefinition() == typeof(Nullable<>);

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
}