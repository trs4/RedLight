using System;

namespace RedLight;

public static class ModifyColumnQueryFluent
{
    /// <summary>Изменяет поле таблицы</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="type">Тип поля</param>
    /// <param name="nullable">Поддержка пустых значений</param>
    /// <param name="size">Максимальный размер поля</param>
    /// <param name="precision">Точность поля</param>
    /// <param name="defaultValue">Значение по умолчанию</param>
    /// <param name="defaultConstraint">Ограничение</param>
    public static TQuery WithColumn<TQuery>(this TQuery query, string name, ColumnType type, bool nullable = false,
        int size = -1, int precision = -1, string defaultValue = null, string defaultConstraint = null)
        where TQuery : ModifyColumnQuery
    {
        query.SetColumn(
            query.Connection.Naming.GetName(name),
            type, nullable, size, precision, defaultValue, defaultConstraint);

        return query;
    }

    /// <summary>Изменяет поле таблицы</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="type">Тип поля</param>
    /// <param name="nullable">Поддержка пустых значений</param>
    /// <param name="size">Максимальный размер поля</param>
    /// <param name="precision">Точность поля</param>
    /// <param name="defaultValue">Значение по умолчанию</param>
    /// <param name="defaultConstraint">Ограничение</param>
    public static TQuery WithColumn<TQuery, TEnum>(this TQuery query, TEnum name, ColumnType type, bool nullable = false,
        int size = -1, int precision = -1, string defaultValue = null, string defaultConstraint = null)
        where TQuery : ModifyColumnQuery
        where TEnum : Enum
    {
        query.SetColumn(
            query.Connection.Naming.GetName(name),
            type, nullable, size, precision, defaultValue, defaultConstraint);

        return query;
    }

    /// <summary>Изменяет поле таблицы</summary>
    /// <param name="column">Описание поля</param>
    public static TQuery WithColumn<TQuery>(this TQuery query, Column column)
        where TQuery : ModifyColumnQuery
    {
        ArgumentNullException.ThrowIfNull(column);

        query.SetColumn(
            query.Connection.Naming.GetName(column.Name),
            column.Type, column.Nullable, column.Size, column.Precision, column.DefaultValue, column.DefaultConstraint);

        return query;
    }

}
