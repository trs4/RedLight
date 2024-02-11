using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal abstract class InTermAction<TValue>
{
    private static readonly FrozenDictionary<Type, object> _types = new Dictionary<Type, object>()
    {
        { typeof(bool), new InTermActionBool() },
        { typeof(byte), new InTermActionByte() },
        { typeof(short), new InTermActionShort() },
        { typeof(int), new InTermActionInt() },
        { typeof(long), new InTermActionLong() },
        { typeof(float), new InTermActionFloat() },
        { typeof(double), new InTermActionDouble() },
        { typeof(decimal), new InTermActionDecimal() },
        { typeof(string), new InTermActionString() },
        { typeof(DateTime), new InTermActionDateTime() },
        { typeof(TimeSpan), new InTermActionTimeSpan() },
        { typeof(Guid), new InTermActionGuid() },
    }.ToFrozenDictionary();

    static InTermAction()
    {
        var type = typeof(TValue);

        if (!_types.TryGetValue(type, out var action))
            throw new NotSupportedException(type.FullName);

        Instance = (InTermAction<TValue>)action;
    }

    public static InTermAction<TValue> Instance { get; }

    [MethodImpl(Flags.HotPath)]
    public InTerm<TValue> Create(Query owner, string column, IReadOnlyCollection<TValue> values)
        => Create(owner, column, values.TakeIReadOnlyList());

    public abstract InTerm<TValue> Create(Query owner, string column, IReadOnlyList<TValue> values);
}
