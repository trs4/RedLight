using System;

namespace RedLight;

public static class MultiInsertQueryFluent
{
    /// <summary>Добавляет поле запрашиваемых данных</summary>
    /// <param name="name">Имя поля</param>
    public static TQuery AddReturningColumn<TQuery>(this TQuery query, string name)
        where TQuery : MultiInsertQuery
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных</summary>
    /// <param name="name">Имя поля</param>
    public static TQuery AddReturningColumn<TQuery, TEnum>(this TQuery query, TEnum name)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        return query;
    }

    /// <summary>Добавляет поля запрашиваемых данных</summary>
    /// <param name="names">Имена полей</param>
    public static TQuery AddReturningColumns<TQuery>(this TQuery query, params string[] names)
        where TQuery : MultiInsertQuery
    {
        foreach (string name in names)
            query.AddReturningColumnCore(query.Connection.Naming.GetName(name));

        return query;
    }

    /// <summary>Добавляет поля запрашиваемых данных</summary>
    /// <param name="names">Имена полей</param>
    public static TQuery AddReturningColumns<TQuery, TEnum>(this TQuery query, params TEnum[] names)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        foreach (var name in names)
            query.AddReturningColumnCore(query.Connection.Naming.GetName(name));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static MultiInsertQuery<TResult> AddReturningColumn<TResult, T>(
        this MultiInsertQuery<TResult> query, string name, Action<TResult, T> readColumn)
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля</param>
    public static MultiInsertQuery<TResult> AddReturningColumn<TResult, T, TEnum>(
        this MultiInsertQuery<TResult> query, TEnum name, Action<TResult, T> readColumn)
        where TEnum : Enum
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        query.AddReadAction(readColumn);
        return query;
    }

    /// <summary>Задаёт имя таблицы, в которую будет записан результат</summary>
    public static TQuery SetOutputTableName<TQuery>(this TQuery query, string outputTableName)
        where TQuery : MultiInsertQuery
    {
        query.OutputTableName = outputTableName is null ? null : query.Connection.Naming.GetName(outputTableName);
        return query;
    }

    /// <summary>Задаёт имя таблицы, в которую будет записан результат</summary>
    public static TQuery SetOutputTableName<TQuery, TEnum>(this TQuery query, TEnum outputTableName)
        where TQuery : MultiInsertQuery
        where TEnum : Enum
    {
        query.OutputTableName = outputTableName is null ? null : query.Connection.Naming.GetName(outputTableName);
        return query;
    }

}
