namespace RedLight;

public static class WhereQueryHintFluent
{
    /// <summary>Добавляет подсказку к запросу</summary>
    /// <param name="hint">Подсказка запроса</param>
    public static TQuery AddHint<TQuery>(this TQuery query, Hints hint)
        where TQuery : WhereQuery
    {
        query.Hints |= hint;
        return query;
    }

    /// <summary>Удаляет подсказку запроса</summary>
    /// <param name="hint">Подсказка запроса</param>
    public static TQuery RemoveHint<TQuery>(this TQuery query, Hints hint)
        where TQuery : WhereQuery
    {
        query.Hints &= ~hint;
        return query;
    }

    /// <summary>Очищает все подсказки запроса</summary>
    public static TQuery ClearHints<TQuery>(this TQuery query)
        where TQuery : WhereQuery
    {
        query.Hints = Hints.None;
        return query;
    }

}
