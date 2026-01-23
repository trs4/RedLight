using System;

namespace RedLight;

public static class SelectQueryOrderByFluent
{
    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderBy<TQuery>(this TQuery query, string columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
    {
        query.AddOrderByCore(null, query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderBy<TQuery, TEnum>(this TQuery query, TEnum columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddOrderByCore(null, query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderBy<TQuery>(this TQuery query, string tableName, string columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
    {
        query.AddOrderByCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderBy<TQuery, TEnum>(this TQuery query, string tableName, TEnum columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.AddOrderByCore(query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="index">Индекс для вставки поля</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderByAtIndex<TQuery>(this TQuery query, int index, string columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
    {
        query.InsertOrderByCore(index, null, query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="index">Индекс для вставки поля</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderByAtIndex<TQuery, TEnum>(this TQuery query, int index, TEnum columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.InsertOrderByCore(index, null, query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="index">Индекс для вставки поля</param>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderByAtIndex<TQuery>(this TQuery query, int index, string tableName, string columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
    {
        query.InsertOrderByCore(index, query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

    /// <summary>Добавляет поле для сортировки данных</summary>
    /// <param name="index">Индекс для вставки поля</param>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="columnName">Имя поля</param>
    /// <param name="sortOrder">Порядок сортировки</param>
    public static TQuery OrderByAtIndex<TQuery, TEnum>(this TQuery query, int index, string tableName, TEnum columnName, SelectQueryOrder sortOrder = SelectQueryOrder.Ascending)
        where TQuery : SelectQuery
        where TEnum : Enum
    {
        query.InsertOrderByCore(index, query.Connection.Naming.GetName(tableName), query.Connection.Naming.GetName(columnName), sortOrder);
        return query;
    }

}
