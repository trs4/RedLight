namespace RedLight;

public static class SelectQueryFluent
{
    /// <summary>Выставляет оператор удаления дубликатов строк</summary>
    /// <param name="isDistinct">Значение оператора удаления дубликатов строк</param>
    public static TQuery WithDistinct<TQuery>(this TQuery query, bool isDistinct = true)
        where TQuery : SelectQuery
    {
        query.Distinct = isDistinct;
        return query;
    }

    /// <summary>Выставляет опцию чтения только первой записи</summary>
    public static TQuery TakeFirst<TQuery>(this TQuery query)
        where TQuery : SelectQuery
    {
        query.Top = 1;
        return query;
    }

    /// <summary>Выставляет количество записей, которые требуется прочитать</summary>
    /// <param name="fetchRows">Количество записей, которые требуется прочитать</param>
    public static TQuery Take<TQuery>(this TQuery query, int fetchRows)
        where TQuery : SelectQuery
    {
        query.Top = fetchRows;
        return query;
    }

    /// <summary>Выставляет количество записей, которые требуется пропустить</summary>
    /// <param name="skipRows">Количество записей, которые требуется пропустить</param>
    public static TQuery Skip<TQuery>(this TQuery query, long skipRows)
        where TQuery : SelectQuery
    {
        query.Offset = skipRows;
        return query;
    }

    /// <summary>Выставляет режим чтения только количества записей</summary>
    public static TQuery WithCountMode<TQuery>(this TQuery query)
        where TQuery : SelectQuery
    {
        query.Mode = SelectQueryMode.Count;
        return query;
    }

    /// <summary>Выставляет режим чтения только наличия строк результата</summary>
    public static TQuery WithExistenceMode<TQuery>(this TQuery query)
        where TQuery : SelectQuery
    {
        query.Mode = SelectQueryMode.Existence;
        return query;
    }

    /// <summary>Выставляет вложенный запрос выборки данных</summary>
    public static TQuery WithFromSelect<TQuery, TFromQuery>(this TQuery query, TFromQuery fromSelect)
        where TQuery : SelectQuery
        where TFromQuery : SelectQuery
    {
        query.FromSelect = fromSelect;
        return query;
    }

}
