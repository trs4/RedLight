using System;

namespace RedLight;

public static class MultiUpdateQueryFluent
{
    /// <summary>Задаёт соответствие между имем поля основного запроса с именем поля в таблице данных для обновления данных</summary>
    /// <summary>Поле для составления условия пересечения</summary>
    /// <param name="columnName">Имя поля</param>
    public static TQuery OnColumn<TQuery>(this TQuery query, string columnName)
        where TQuery : MultiUpdateQuery
    {
        query.AddOnColumnCore(query.Connection.Naming.GetName(columnName));
        return query;
    }

    /// <summary>Добавляет поле для составления условия пересечения</summary>
    /// <param name="columnName">Имя поля</param>
    public static TQuery OnColumn<TQuery, TEnum>(this TQuery query, TEnum columnName) where TEnum : Enum
        where TQuery : MultiUpdateQuery
    {
        query.AddOnColumnCore(query.Connection.Naming.GetName(columnName));
        return query;
    }

    /// <summary>Задаёт соответствие между имем поля основного запроса с именем поля в таблице данных для обновления данных</summary>
    /// <param name="columnName">Имя поля в основном запросе</param>
    /// <param name="dataColumnName">Имя поля в таблице данных</param>
    public static TQuery ReplaceDataColumn<TQuery>(this TQuery query, string columnName, string dataColumnName)
        where TQuery : MultiUpdateQuery
    {
        query.AddReplaceColumnCore(
            query.Connection.Naming.GetName(columnName),
            query.Connection.Naming.GetName(dataColumnName));

        return query;
    }

    /// <summary>Задаёт соответствие между имем поля основного запроса с именем поля в таблице данных для обновления данных</summary>
    /// <param name="columnName">Имя поля в основном запросе</param>
    /// <param name="dataColumnName">Имя поля в таблице данных</param>
    public static TQuery ReplaceDataColumn<TQuery, TEnum>(this TQuery query, TEnum columnName, string dataColumnName)
        where TQuery : MultiUpdateQuery
        where TEnum : Enum
    {
        query.AddReplaceColumnCore(
            query.Connection.Naming.GetName(columnName),
            query.Connection.Naming.GetName(dataColumnName));

        return query;
    }

    /// <summary>Задаёт соответствие между имем поля основного запроса с именем поля в таблице данных для обновления данных</summary>
    /// <param name="columnName">Имя поля в основном запросе</param>
    /// <param name="dataColumnName">Имя поля в таблице данных</param>
    public static TQuery ReplaceDataColumn<TQuery, TEnum>(this TQuery query, string columnName, TEnum dataColumnName)
        where TQuery : MultiUpdateQuery
        where TEnum : Enum
    {
        query.AddReplaceColumnCore(
            query.Connection.Naming.GetName(columnName),
            query.Connection.Naming.GetName(dataColumnName));

        return query;
    }

    /// <summary>Задаёт соответствие между имем поля основного запроса с именем поля в таблице данных для обновления данных</summary>
    /// <param name="columnName">Имя поля в основном запросе</param>
    /// <param name="dataColumnName">Имя поля в таблице данных</param>
    public static TQuery ReplaceDataColumn<TQuery, TEnum1, TEnum2>(this TQuery query, TEnum1 columnName, TEnum2 dataColumnName)
        where TQuery : MultiUpdateQuery
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        query.AddReplaceColumnCore(
            query.Connection.Naming.GetName(columnName),
            query.Connection.Naming.GetName(dataColumnName));

        return query;
    }

}
