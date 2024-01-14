namespace RedLight.Internal;

/// <summary>Режим выполнения команды запроса</summary>
internal enum RunMode
{
    /// <summary>Без результата</summary>
    NonQuery,

    /// <summary>Возвращает набор данных</summary>
    Reader,

    /// <summary>Возвращает скалярное значение</summary>
    Scalar,
}