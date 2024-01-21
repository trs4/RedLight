using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class ScalarReadBuilder
{
    private static readonly ConcurrentDictionary<Type, IScalarReadAction> _readActionsByType = [];

    [MethodImpl(Flags.HotPath)]
    public static void Add<TResult, T>(ref List<Action<TResult, DbDataReader>> readActions, Action<TResult, T> readAction)
    {
        readActions ??= [];
        int index = readActions.Count;
        readActions.Add((obj, reader) => readAction(obj, ScalarReadAction<T>.Instance.Read(reader, index)));
    }

    [MethodImpl(Flags.HotPath)]
    public static void Add<TResult>(ref List<Action<TResult, DbDataReader>> readActions, Type type, Action<TResult, object> readAction)
    {
        readActions ??= [];
        int index = readActions.Count;
        readActions.Add((obj, reader) => readAction(obj, Read(type, reader, index)));
    }

    public static object Read(Type type, DbDataReader reader, int index) => Get(type).Read(reader, index);

    public static IList Fill<TResult>(PropertyInfo propertyInfo, IReadOnlyCollection<TResult> rows) => Get(propertyInfo.PropertyType).Fill(propertyInfo, rows);

    [MethodImpl(Flags.HotPath)]
    private static IScalarReadAction Get(Type type) => _readActionsByType.GetOrAdd(type, CreateReadActionByType);

    private static IScalarReadAction CreateReadActionByType(Type type)
        => typeof(ScalarReadAction<>).MakeGenericType(type)
            .GetProperty(nameof(ScalarReadAction<object>.Instance)).GetValue(null) as IScalarReadAction;
}
