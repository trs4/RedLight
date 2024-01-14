using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace RedLight.SqlServer;

internal static class SqlServerHints
{
    private static readonly ConcurrentDictionary<Hints, string> _cache = new();

    private static readonly Hints[] _availableValues =
    [
        Hints.NoLock,
        Hints.HoldLock,
    ];

    static SqlServerHints()
        => _cache.TryAdd(0, null);

    public static string Get(Hints hints) => _cache.GetOrAdd(hints, GetSql);
    
    private static string GetSql(Hints hints)
    {
        var items = new List<Hints>();

        foreach (var value in Enum.GetValues<Hints>())
        {
            if (hints.HasFlag(value) && _availableValues.Contains(value))
                items.Add(value);
        }

        return items.Count == 0
            ? null
            : String.Concat(" WITH(", String.Join(", ", items.Select(i => i.ToString().ToUpper())), ")");
    }

}
