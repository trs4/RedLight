using System;

namespace RedLight;

public static class SelectQueryGroupByFluent
{
    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="columnName">Имя поля</param>
    public static TQuery GroupBy<TQuery>(this TQuery query, string columnName)
        where TQuery : SelectQuery
    {
        query.AddGroupByCore(null, query.Connection.Naming.GetName(columnName));
        return query;
    }

    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="columnName">Имя поля</param>
    public static TQuery GroupBy<TQuery, TEnum>(this TQuery query, TEnum columnName)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddGroupByCore(null, query.Connection.Naming.GetName(columnName));
        return query;
    }

    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    public static TQuery GroupBy<TQuery>(this TQuery query, string tableName, string columnName)
        where TQuery : SelectQuery
    {
        query.AddGroupByCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName));
        return query;
    }

    /// <summary>Добавляет группировку по полю</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    public static TQuery GroupBy<TQuery, TEnum>(this TQuery query, string tableName, TEnum columnName)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddGroupByCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName));
        return query;
    }

}
