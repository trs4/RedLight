using System;

namespace RedLight;

public static class SelectQueryColumnsFluent
{
    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="columnName">Имя поля</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string columnName)
        where TQuery : SelectQuery
    {
        query.AddColumnCore(null, query.Connection.Naming.GetName(columnName), null);
        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string columnName, string alias)
        where TQuery : SelectQuery
    {
        query.AddColumnCore(
            null,
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="columnName">Имя поля</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum columnName)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddColumnCore(null, query.Connection.Naming.GetName(columnName), null);
        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum columnName, string alias)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddColumnCore(
            null,
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    public static TQuery AddTableColumn<TQuery>(this TQuery query, string tableName, string columnName)
        where TQuery : SelectQuery
    {
        query.AddColumnCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName), null);
        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    public static TQuery AddTableColumn<TQuery>(this TQuery query, string tableName, string columnName, string alias)
        where TQuery : SelectQuery
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    public static TQuery AddTableColumn<TQuery, TEnum>(this TQuery query, string tableName, TEnum columnName)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddColumnCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName), null);
        return query;
    }

    /// <summary>Добавляет поле выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    public static TQuery AddTableColumn<TQuery, TEnum>(this TQuery query, string tableName, TEnum columnName, string alias)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        return query;
    }

    /// <summary>Добавляет поля выборки данных</summary>
    /// <param name="columnNames">Имена полей</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, params string[] columnNames)
        where TQuery : SelectQuery
    {
        foreach (string columnName in columnNames)
            query.AddColumnCore(null, query.Connection.Naming.GetName(columnName));

        return query;
    }

    /// <summary>Добавляет поля выборки данных</summary>
    /// <param name="columnNames">Имена полей</param>
    public static TQuery AddColumns<TQuery, TEnum>(this TQuery query, params TEnum[] columnNames)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        foreach (var columnName in columnNames)
            query.AddColumnCore(null, query.Connection.Naming.GetName(columnName));

        return query;
    }

    /// <summary>Добавляет поля выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnNames">Имена полей</param>
    public static TQuery AddTableColumns<TQuery>(this TQuery query, string tableName, params string[] columnNames)
        where TQuery : SelectQuery
    {
        tableName = query.Connection.Naming.GetName(tableName);

        foreach (string columnName in columnNames)
            query.AddColumnCore(tableName, query.Connection.Naming.GetName(columnName));

        return query;
    }

    /// <summary>Добавляет поля выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnNames">Имена полей</param>
    public static TQuery AddTableColumns<TQuery, TEnum>(this TQuery query, string tableName, params TEnum[] columnNames)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        tableName = query.Connection.Naming.GetName(tableName);

        foreach (var columnName in columnNames)
            query.AddColumnCore(tableName, query.Connection.Naming.GetName(columnName));

        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddColumn<TResult, T>(this SelectQuery<TResult> query, string columnName,
        Action<TResult, T> readColumn)
    {
        query.AddColumnCore(null, query.Connection.Naming.GetName(columnName));
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddColumn<TResult, T, TEnum>(this SelectQuery<TResult> query, TEnum columnName,
        Action<TResult, T> readColumn)
        where TEnum : Enum
    {
        query.AddColumnCore(null, query.Connection.Naming.GetName(columnName));
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddTableColumn<TResult, T>(this SelectQuery<TResult> query, string tableName,
        string columnName, Action<TResult, T> readColumn)
    {
        query.AddColumnCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName));
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddTableColumn<TResult, T, TEnum>(this SelectQuery<TResult> query, string tableName,
        TEnum columnName, Action<TResult, T> readColumn)
        where TEnum : Enum
    {
        query.AddColumnCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName));
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddColumn<TResult, T>(this SelectQuery<TResult> query, string columnName, string alias,
        Action<TResult, T> readColumn)
    {
        query.AddColumnCore(
            null,
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddColumn<TResult, T, TEnum>(this SelectQuery<TResult> query, TEnum columnName, string alias,
        Action<TResult, T> readColumn)
        where TEnum : Enum
    {
        query.AddColumnCore(
            null,
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddTableColumn<TResult, T>(this SelectQuery<TResult> query, string tableName,
        string columnName, string alias, Action<TResult, T> readColumn)
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static SelectQuery<TResult> AddTableColumn<TResult, T, TEnum>(this SelectQuery<TResult> query, string tableName,
        TEnum columnName, string alias, Action<TResult, T> readColumn)
        where TEnum : Enum
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(tableName),
            query.Connection.Naming.GetName(columnName),
            alias is null ? null : query.Connection.Naming.GetName(alias));

        query.AddReadAction(readColumn);
        return query;
    }

}
