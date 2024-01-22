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
        { typeof(byte), () => new ScalarReadActionByte() },
        { typeof(byte?), () => new ScalarReadActionNullableByte() },
        { typeof(byte[]), () => new ScalarReadActionNullableByteArray() },
        { typeof(short), () => new ScalarReadActionShort() },
        { typeof(short?), () => new ScalarReadActionNullableShort() },
        { typeof(int), () => new ScalarReadActionInt() },
        { typeof(int?), () => new ScalarReadActionNullableInt() },
        { typeof(long), () => new ScalarReadActionLong() },
        { typeof(long?), () => new ScalarReadActionNullableLong() },
        { typeof(float), () => new ScalarReadActionFloat() },
        { typeof(float?), () => new ScalarReadActionNullableFloat() },
        { typeof(double), () => new ScalarReadActionDouble() },
        { typeof(double?), () => new ScalarReadActionNullableDouble() },
        { typeof(decimal), () => new ScalarReadActionDecimal() },
        { typeof(decimal?), () => new ScalarReadActionNullableDecimal() },
        { typeof(string), () => new ScalarReadActionNullableString() },
        { typeof(DateTime), () => new ScalarReadActionDateTime() },
        { typeof(DateTime?), () => new ScalarReadActionNullableDateTime() },
        { typeof(TimeSpan), () => new ScalarReadActionTimeSpan() },
        { typeof(TimeSpan?), () => new ScalarReadActionNullableTimeSpan() },
        { typeof(Guid), () => new ScalarReadActionGuid() },
        { typeof(Guid?), () => new ScalarReadActionNullableGuid() },
    }.ToFrozenDictionary();

    static ScalarReadAction()
    {
        var type = typeof(T);

        if (!_types.TryGetValue(type, out var func))
            throw new NotSupportedException(type.FullName);

        Instance = (ScalarReadAction<T>)func();
    }

    public static ScalarReadAction<T> Instance { get; }

    public abstract T Read(DbDataReader reader, int index);

    public void Read(List<T> source, DbDataReader reader)
    {
        while (reader.Read())
            source.Add(Read(reader, 0));
    }

    public void Read(HashSet<T> source, DbDataReader reader)
    {
        while (reader.Read())
            source.Add(Read(reader, 0));
    }

    public void Read(ICollection<T> source, DbDataReader reader)
    {
        while (reader.Read())
            source.Add(Read(reader, 0));
    }

    public IList Fill<TResult>(PropertyInfo propertyInfo, IReadOnlyCollection<TResult> rows)
    {
        var result = new List<T>(rows.Count);

        foreach (var row in rows)
            result.Add((T)propertyInfo.GetValue(row));

        return result;
    }

    object IScalarReadAction.Read(DbDataReader reader, int index) => Read(reader, index);
}
