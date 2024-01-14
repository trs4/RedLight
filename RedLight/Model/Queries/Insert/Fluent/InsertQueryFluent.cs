using System;

namespace RedLight;

public static class InsertQueryFluent
{
    /// <summary>Добавляет поле запрашиваемых данных</summary>
    /// <param name="name">Имя поля</param>
    public static TQuery AddReturningColumn<TQuery>(this TQuery query, string name)
        where TQuery : InsertQuery
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных</summary>
    /// <param name="name">Имя поля</param>
    public static TQuery AddReturningColumn<TQuery, TEnum>(this TQuery query, TEnum name)
        where TQuery : InsertQuery
        where TEnum : Enum
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        return query;
    }

    /// <summary>Добавляет поля запрашиваемых данных</summary>
    /// <param name="names">Имена полей</param>
    public static TQuery AddReturningColumns<TQuery>(this TQuery query, params string[] names)
        where TQuery : InsertQuery
    {
        foreach (string name in names)
            query.AddReturningColumnCore(query.Connection.Naming.GetName(name));

        return query;
    }

    /// <summary>Добавляет поля запрашиваемых данных</summary>
    /// <param name="names">Имена полей</param>
    public static TQuery AddReturningColumns<TQuery, TEnum>(this TQuery query, params TEnum[] names)
        where TQuery : InsertQuery
        where TEnum : Enum
    {
        foreach (var name in names)
            query.AddReturningColumnCore(query.Connection.Naming.GetName(name));

        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readAction">Действие чтения поля</param>
    public static InsertQuery<TResult> AddReturningColumn<TResult, T>(
        this InsertQuery<TResult> query, string name, Action<TResult, T> readAction)
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        query.AddReadAction(readAction);
        return query;
    }

    /// <summary>Добавляет поле запрашиваемых данных с действием чтения данного поля</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readAction">Действие чтения поля</param>
    public static InsertQuery<TResult> AddReturningColumn<TResult, T, TEnum>(
        this InsertQuery<TResult> query, TEnum name, Action<TResult, T> readAction)
        where TEnum : Enum
    {
        query.AddReturningColumnCore(query.Connection.Naming.GetName(name));
        query.AddReadAction(readAction);
        return query;
    }

    /// <summary>Задаёт имя таблицы, в которую будет записан результат</summary>
    public static TQuery SetOutputTableName<TQuery>(this TQuery query, string outputTableName)
        where TQuery : InsertQuery
    {
        query.OutputTableName = outputTableName is null ? null : query.Connection.Naming.GetName(outputTableName);
        return query;
    }

    /// <summary>Задаёт имя таблицы, в которую будет записан результат</summary>
    public static TQuery SetOutputTableName<TQuery, TEnum>(this TQuery query, TEnum outputTableName)
        where TQuery : InsertQuery
        where TEnum : Enum
    {
        query.OutputTableName = outputTableName is null ? null : query.Connection.Naming.GetName(outputTableName);
        return query;
    }

}
