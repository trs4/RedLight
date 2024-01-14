using System;

namespace RedLight;

public static class SelectQueryJoinFluent
{
    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery>(this TQuery query, string tableName, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName));

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery, TEnum>(this TQuery query, TEnum tableName, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName));

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="type">Тип пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery>(this TQuery query, string tableName, JoinQueryMode type, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName),
            null,
            type);

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="type">Тип пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery, TEnum>(this TQuery query, TEnum tableName, JoinQueryMode type, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName),
            null,
            type);

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="alias">Имя псевдонима пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery>(this TQuery query, string tableName, string alias, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(alias));

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="alias">Имя псевдонима пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery, TEnum>(this TQuery query, TEnum tableName, string alias, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(alias));

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="alias">Имя псевдонима пересечения</param>
    /// <param name="type">Тип пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery>(this TQuery query, string tableName, string alias, JoinQueryMode type, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(alias),
            type);

        join?.Invoke(joinBlock);
        return query;
    }

    /// <summary>Добавляет пересечение с другой таблицей</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    /// <param name="alias">Имя псевдонима пересечения</param>
    /// <param name="type">Тип пересечения</param>
    /// <param name="join">Построитель условий пересечения</param>
    public static TQuery Join<TQuery, TEnum>(this TQuery query, TEnum tableName, string alias, JoinQueryMode type, Action<JoinQuery> join = null)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        var joinBlock = query.AddJoinCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(alias),
            type);

        join?.Invoke(joinBlock);
        return query;
    }

}
