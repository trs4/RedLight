using System;

namespace RedLight;

/// <summary>Подсказки для запросов</summary>
[Flags]
public enum Hints
{
    None = 0,
    NoLock = 1,
    HoldLock = 2,
}
