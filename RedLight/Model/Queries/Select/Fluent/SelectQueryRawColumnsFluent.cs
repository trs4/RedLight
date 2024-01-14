using System;

namespace RedLight;

public static class SelectQueryRawColumnsFluent
{
    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    public static TQuery AddRawColumn<TQuery>(this TQuery query, string rawColumn, string alias = null)
        where TQuery : SelectQuery
    {
        query.AddRawColumnCore(
            rawColumn,
            alias is null ? null : query.Connection.Naming.GetName(alias));

        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    public static TQuery AddTableRawColumn<TQuery>(this TQuery query, string tableName, string rawColumn,
        string alias = null)
        where TQuery : SelectQuery
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(tableName),
            rawColumn,
            alias is null ? null : query.Connection.Naming.GetName(alias));

        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddRawColumn<TResult, T>(this SelectQuery<TResult> query, string rawColumn,
        Action<TResult, T> readColumn)
    {
        query.AddRawColumnCore(rawColumn);
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="rawColumn">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddTableRawColumn<TResult, T>(this SelectQuery<TResult> query, string tableName,
        string rawColumn, Action<TResult, T> readColumn)
    {
        query.AddColumnCore(query.Connection.Naming.GetName(tableName), rawColumn);
        query.AddReadAction(readColumn);
        return query;
    }

}
