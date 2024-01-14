using System;

namespace RedLight;

public static class DeleteColumnQueryFluent
{
    /// <summary>Удаляет поле таблицы</summary>
    /// <param name="name">Имя поля</param>
    public static TQuery WithColumn<TQuery>(this TQuery query, string name)
        where TQuery : DeleteColumnQuery
    {
        query.Column = query.Connection.Naming.GetName(name);
        return query;
    }

    /// <summary>Удаляет поле таблицы</summary>
    /// <param name="name">Имя поля</param>
    public static TQuery WithColumn<TQuery, TEnum>(this TQuery query, TEnum name)
        where TQuery : DeleteColumnQuery
        where TEnum : Enum
    {
        query.Column = query.Connection.Naming.GetName(name);
        return query;
    }

    /// <summary>Удаляет поле таблицы</summary>
    /// <param name="column">Описание поля</param>
    public static TQuery WithColumn<TQuery>(this TQuery query, Column column)
        where TQuery : DeleteColumnQuery
    {
        ArgumentNullException.ThrowIfNull(column);
        query.Column = query.Connection.Naming.GetName(column.Name);
        return query;
    }

}
