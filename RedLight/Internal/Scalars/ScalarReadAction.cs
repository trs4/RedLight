using System;
using System.Collections;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace RedLight.Internal;

public abstract class ScalarReadAction<T> : IScalarReadAction
{
    private static readonly FrozenDictionary<Type, Func<IScalarReadAction>> _types = new Dictionary<Type, Func<IScalarReadAction>>()
    {
        { typeof(bool), () => new ScalarReadActionBool() },
        { typeof(bool?), () => new ScalarReadActionNullableBool() },
        { typeof(char), () => new ScalarReadActionChar() },
        { typeof(char?), () => new ScalarReadActionNullableChar() },
        { typeof(sbyte), () => new ScalarReadActionSByte() },
        { typeof(sbyte?), () => new ScalarReadActionNullableSByte() },
        { typeof(byte), () => new ScalarReadActionByte() },
        { typeof(byte?), () => new ScalarReadActionNullableByte() },
        { typeof(byte[]), () => new ScalarReadActionByteArray() },
        { typeof(short), () => new ScalarReadActionShort() },
        { typeof(short?), () => new ScalarReadActionNullableShort() },
        { typeof(ushort), () => new ScalarReadActionUShort() },
        { typeof(ushort?), () => new ScalarReadActionNullableUShort() },
        { typeof(int), () => new ScalarReadActionInt() },
        { typeof(int?), () => new ScalarReadActionNullableInt() },
        { typeof(uint), () => new ScalarReadActionUInt() },
        { typeof(uint?), () => new ScalarReadActionNullableUInt() },
        { typeof(long), () => new ScalarReadActionLong() },
        { typeof(long?), () => new ScalarReadActionNullableLong() },
        { typeof(ulong), () => new ScalarReadActionULong() },
        { typeof(ulong?), () => new ScalarReadActionNullableULong() },
        { typeof(float), () => new ScalarReadActionFloat() },
        { typeof(float?), () => new ScalarReadActionNullableFloat() },
        { typeof(double), () => new ScalarReadActionDouble() },
        { typeof(double?), () => new ScalarReadActionNullableDouble() },
        { typeof(decimal), () => new ScalarReadActionDecimal() },
        { typeof(decimal?), () => new ScalarReadActionNullableDecimal() },
        { typeof(string), () => new ScalarReadActionNullableString() },
        { typeof(Guid), () => new ScalarReadActionGuid() },
        { typeof(Guid?), () => new ScalarReadActionNullableGuid() },
        { typeof(DateTime), () => new ScalarReadActionDateTime() },
        { typeof(DateTime?), () => new ScalarReadActionNullableDateTime() },
        { typeof(TimeSpan), () => new ScalarReadActionTimeSpan() },
        { typeof(TimeSpan?), () => new ScalarReadActionNullableTimeSpan() },
    }.ToFrozenDictionary();

    static ScalarReadAction()
    {
        var type = typeof(T);

        if (!_types.TryGetValue(type, out var func))
            throw new NotSupportedException(type.FullName);

        Instance = (ScalarReadAction<T>)func();
    }

    public static ScalarReadAction<T> Instance { get; }

    public abstract T Read(DatabaseConnection connection, DbDataReader reader, int index);

    public void Read(DatabaseConnection connection, List<T> source, DbDataReader reader)
    {
        while (reader.Read())
            source.Add(Read(connection, reader, 0));
    }

    public void Read(DatabaseConnection connection, HashSet<T> source, DbDataReader reader)
    {
        while (reader.Read())
            source.Add(Read(connection, reader, 0));
    }

    public void Read(DatabaseConnection connection, ICollection<T> source, DbDataReader reader)
    {
        while (reader.Read())
            source.Add(Read(connection, reader, 0));
    }

    public IList Fill<TResult>(PropertyInfo propertyInfo, IReadOnlyCollection<TResult> rows)
    {
        var result = new List<T>(rows.Count);

        foreach (var row in rows)
            result.Add((T)propertyInfo.GetValue(row));

        return result;
    }

    object IScalarReadAction.Read(DatabaseConnection connection, DbDataReader reader, int index) => Read(connection, reader, index);
}
