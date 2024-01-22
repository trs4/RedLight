using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;
using IcyRain.Tables;

namespace RedLight.Internal;

internal static class ScalarReadBuilder
{
    private static readonly FrozenDictionary<int, IScalarReadAction> _actionsByType = new Dictionary<int, IScalarReadAction>()
    {
        { Extensions.GetHash(DataType.Boolean), new ScalarReadActionBool() },
        { Extensions.GetHash(DataType.Boolean, isNullable: true), new ScalarReadActionNullableBool() },
        { Extensions.GetHash(DataType.Byte), new ScalarReadActionByte() },
        { Extensions.GetHash(DataType.Byte, isNullable: true), new ScalarReadActionNullableByte() },
        { Extensions.GetHash(DataType.Byte, isArray: true), new ScalarReadActionByteArray() },
        { Extensions.GetHash(DataType.Int16), new ScalarReadActionShort() },
        { Extensions.GetHash(DataType.Int16, isNullable: true), new ScalarReadActionNullableShort() },
        { Extensions.GetHash(DataType.Int32), new ScalarReadActionInt() },
        { Extensions.GetHash(DataType.Int32, isNullable: true), new ScalarReadActionNullableInt() },
        { Extensions.GetHash(DataType.Int64), new ScalarReadActionLong() },
        { Extensions.GetHash(DataType.Int64, isNullable: true), new ScalarReadActionNullableLong() },
        { Extensions.GetHash(DataType.Single), new ScalarReadActionFloat() },
        { Extensions.GetHash(DataType.Single, isNullable: true), new ScalarReadActionNullableFloat() },
        { Extensions.GetHash(DataType.Double), new ScalarReadActionDouble() },
        { Extensions.GetHash(DataType.Double, isNullable: true), new ScalarReadActionNullableDouble() },
        { Extensions.GetHash(DataType.Decimal), new ScalarReadActionDecimal() },
        { Extensions.GetHash(DataType.Decimal, isNullable: true), new ScalarReadActionNullableDecimal() },
        { Extensions.GetHash(DataType.String), new ScalarReadActionString() },
        { Extensions.GetHash(DataType.String, isNullable: true), new ScalarReadActionNullableString() },
        { Extensions.GetHash(DataType.DateTime), new ScalarReadActionDateTime() },
        { Extensions.GetHash(DataType.DateTime, isNullable: true), new ScalarReadActionNullableDateTime() },
        { Extensions.GetHash(DataType.TimeSpan), new ScalarReadActionTimeSpan() },
        { Extensions.GetHash(DataType.TimeSpan, isNullable: true), new ScalarReadActionNullableTimeSpan() },
        { Extensions.GetHash(DataType.Guid), new ScalarReadActionGuid() },
        { Extensions.GetHash(DataType.Guid, isNullable: true), new ScalarReadActionNullableGuid() },
    }.ToFrozenDictionary();

    private static readonly ConcurrentDictionary<Type, IScalarReadAction> _readActionsByType = [];

    [MethodImpl(Flags.HotPath)]
    public static void Add<TResult, T>(ref List<Action<TResult, DbDataReader>> readActions, Action<TResult, T> readAction)
    {
        readActions ??= [];
        int index = readActions.Count;
        var action = ScalarReadAction<T>.Instance;
        readActions.Add((obj, reader) => readAction(obj, action.Read(reader, index)));
    }

    [MethodImpl(Flags.HotPath)]
    public static void Add<TResult>(ref List<Action<TResult, DbDataReader>> readActions, Column column, Action<TResult, object> readAction)
    {
        readActions ??= [];
        int index = readActions.Count;

        if (!_actionsByType.TryGetValue(Extensions.GetHash(column), out var action))
            throw new NotSupportedException(column.GetType().FullName);

        readActions.Add((obj, reader) => readAction(obj, action.Read(reader, index)));
    }

    [MethodImpl(Flags.HotPath)]
    public static void Add<TResult>(ref List<Action<TResult, DbDataReader>> readActions, Type type, Action<TResult, object> readAction)
    {
        readActions ??= [];
        int index = readActions.Count;
        var action = Get(type);
        readActions.Add((obj, reader) => readAction(obj, action.Read(reader, index)));
    }

    public static object Read(Type type, DbDataReader reader, int index) => Get(type).Read(reader, index);

    public static IList Fill<TResult>(PropertyInfo propertyInfo, IReadOnlyCollection<TResult> rows) => Get(propertyInfo.PropertyType).Fill(propertyInfo, rows);

    [MethodImpl(Flags.HotPath)]
    private static IScalarReadAction Get(Type type) => _readActionsByType.GetOrAdd(type, CreateReadActionByType);

    private static IScalarReadAction CreateReadActionByType(Type type)
        => typeof(ScalarReadAction<>).MakeGenericType(type)
            .GetProperty(nameof(ScalarReadAction<object>.Instance)).GetValue(null) as IScalarReadAction;
}
