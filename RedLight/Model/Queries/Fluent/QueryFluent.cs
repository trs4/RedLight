using System;

namespace RedLight;

public static class QueryFluent
{
    /// <summary>Добавляет части запроса по условию</summary>
    /// <param name="condition">Условие добавления частей запроса</param>
    /// <param name="action">Действие добавления частей запроса</param>
    public static TQuery If<TQuery>(this TQuery query, Func<bool> condition, Func<TQuery, TQuery> action)
        where TQuery : Query
    {
        if (condition())
            action(query);

        return query;
    }

}
