using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using RedLight.Internal;

namespace RedLight;

/// <summary>Наименование параметров запроса</summary>
internal class ParameterNaming
{
    private readonly FrozenDictionary<int, string> _names;

    public ParameterNaming(string preffix)
    {
        if (String.IsNullOrEmpty(preffix) || preffix.IndexOf(' ') > -1)
            throw new ArgumentNullException(nameof(preffix));

        var names = new Dictionary<int, string>(Consts.MaxQueryParameters);

        for (int i = 1; i <= Consts.MaxQueryParameters; i++)
            names[i] = preffix + i;

        _names = names.ToFrozenDictionary();
    }

    /// <summary>Получить имя параметра по номеру</summary>
    /// <param name="number">Номер параметра</param>
    [MethodImpl(Flags.HotPath)]
    public string GetName(int number) => _names[number];

    /// <summary>Получить имя параметра для запроса</summary>
    /// <param name="name">Имя параметра</param>
    [MethodImpl(Flags.HotPath)]
    public virtual string GetNameForQuery(string name) => name;
}
