using System;
using System.Collections.Frozen;
using System.Collections.Generic;

namespace RedLight;

/// <summary>Расширения по работе с оператором блока с условием</summary>
public static class OperatorExtensions
{
    private static readonly FrozenDictionary<string, Op> _map = new Dictionary<string, Op>(StringComparer.OrdinalIgnoreCase)
    {
        { "=", Op.Equal },
        { "<>", Op.NotEqual },
        { ">", Op.GreaterThan },
        { ">=", Op.GreaterThanOrEqual },
        { "<", Op.LessThan },
        { "<=", Op.LessThanOrEqual },
        { "IS", Op.Is },
        { "IS NOT", Op.IsNot },
        { "LIKE", Op.Like },
    }.ToFrozenDictionary();

    /// <summary>Преобразует строку с оператором к перечислению</summary>
    public static Op Parse(string value) => _map.TryGetValue(value, out var op) ? op : throw new InvalidOperationException(value);
}