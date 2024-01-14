namespace RedLight;

/// <summary>Режим выборки данных</summary>
public enum SelectQueryMode
{
    /// <summary>Выборка данных</summary>
    Default,

    /// <summary>Вычисления количества</summary>
    Count,

    /// <summary>Наличие результата</summary>
    Existence,
}