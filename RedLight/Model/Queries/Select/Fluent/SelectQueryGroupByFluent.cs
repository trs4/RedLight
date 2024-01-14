using System;

namespace RedLight;

public static class SelectQueryGroupByFluent
{
    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="fieldName">Имя поля</param>
    public static TQuery GroupBy<TQuery>(this TQuery query, string fieldName)
        where TQuery : SelectQuery
    {
        query.AddGroupByCore(null, query.Connection.Naming.GetName(fieldName));
        return query;
    }

    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="fieldName">Имя поля</param>
    public static TQuery GroupBy<TQuery, TEnum>(this TQuery query, TEnum fieldName)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddGroupByCore(null, query.Connection.Naming.GetName(fieldName));
        return query;
    }

    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="fieldName">Имя поля</param>
    public static TQuery GroupBy<TQuery>(this TQuery query, string tableName, string fieldName)
        where TQuery : SelectQuery
    {
        query.AddGroupByCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(fieldName));
        return query;
    }

    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="fieldName">Имя поля</param>
    public static TQuery GroupBy<TQuery, TEnum>(this TQuery query, string tableName, TEnum fieldName)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddGroupByCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(fieldName));
        return query;
    }

}
