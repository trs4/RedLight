using System;
using System.Collections.Generic;
using System.Linq;

namespace RedLight;

public static class CreateTableQueryFluent
{
    /// <summary>Добавляет поле идентификатора таблицы</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="sequenceName">Имя последовательности</param>
    /// <param name="type">Тип поля</param>
    /// <param name="increment">Интервал между значениями</param>
    /// <param name="minValue">Минимальное значение</param>
    public static TQuery AddIdentityColumn<TQuery>(this TQuery query, string name, string sequenceName = null, ColumnType type = ColumnType.Integer,
        long increment = 1, long minValue = 1)
        where TQuery : CreateTableQuery
    {
        query.SetIdentityColumnCore(query.Connection.Naming.GetName(name), sequenceName, type, increment, minValue);
        return query;
    }

    /// <summary>Добавляет поле идентификатора таблицы</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="sequenceName">Имя последовательности</param>
    /// <param name="type">Тип поля</param>
    /// <param name="increment">Интервал между значениями</param>
    /// <param name="minValue">Минимальное значение</param>
    public static TQuery AddIdentityColumn<TQuery, TEnum>(this TQuery query, TEnum name, string sequenceName = null, ColumnType type = ColumnType.Integer,
        long increment = 1, long minValue = 1)
        where TQuery : CreateTableQuery
        where TEnum : Enum
    {
        query.SetIdentityColumnCore(query.Connection.Naming.GetName(name), sequenceName, type, increment, minValue);
        return query;
    }

    /// <summary>Добавляет поле таблицы</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="type">Тип поля</param>
    /// <param name="nullable">Поддержка пустых значений</param>
    /// <param name="size">Максимальный размер поля</param>
    /// <param name="precision">Точность поля</param>
    /// <param name="defaultValue">Значение по умолчанию</param>
    /// <param name="defaultConstraint">Ограничение</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, string name, ColumnType type, bool nullable = false,
        int size = -1, int precision = -1, string defaultValue = null, string defaultConstraint = null)
        where TQuery : CreateTableQuery
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(name),
            type, nullable, size, precision, defaultValue, defaultConstraint);

        return query;
    }

    /// <summary>Добавляет поле таблицы</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="type">Тип поля</param>
    /// <param name="nullable">Поддержка пустых значений</param>
    /// <param name="size">Максимальный размер поля</param>
    /// <param name="precision">Точность поля</param>
    /// <param name="defaultValue">Значение по умолчанию</param>
    /// <param name="defaultConstraint">Ограничение</param>
    public static TQuery AddColumn<TQuery, TEnum>(this TQuery query, TEnum name, ColumnType type, bool nullable = false,
        int size = -1, int precision = -1, string defaultValue = null, string defaultConstraint = null)
        where TQuery : CreateTableQuery
        where TEnum : Enum
    {
        query.AddColumnCore(
            query.Connection.Naming.GetName(name),
            type, nullable, size, precision, defaultValue, defaultConstraint);

        return query;
    }

    /// <summary>Добавляет поле таблицы</summary>
    /// <param name="column">Описание поля</param>
    public static TQuery AddColumn<TQuery>(this TQuery query, Column column)
        where TQuery : CreateTableQuery
    {
        ArgumentNullException.ThrowIfNull(column);

        query.AddColumnCore(
            query.Connection.Naming.GetName(column.Name),
            column.Type, column.Nullable, column.Size, column.Precision, column.DefaultValue, column.DefaultConstraint);

        return query;
    }

    /// <summary>Добавляет поле таблицы</summary>
    /// <param name="columns">Список описаний полей</param>
    public static TQuery AddColumns<TQuery>(this TQuery query, IEnumerable<Column> columns)
        where TQuery : CreateTableQuery
    {
        ArgumentNullException.ThrowIfNull(columns);

        foreach (var column in columns)
            query.AddColumn(column);

        return query;
    }

    /// <summary>Добавляет поля первичного ключа</summary>
    /// <param name="pkName">Имя первичного ключа</param>
    /// <param name="columns">Поля первичного ключа</param>
    public static TQuery SetPrimaryKey<TQuery>(this TQuery query, string pkName, params string[] columns)
        where TQuery : CreateTableQuery
    {
        var naming = query.Connection.Naming;

        query.SetPrimaryColumnCore(
            pkName is null ? null : naming.GetName(pkName),
            columns.Select(naming.GetName).ToArray());

        return query;
    }

    /// <summary>Добавляет поля первичного ключа</summary>
    /// <param name="pkName">Имя первичного ключа</param>
    /// <param name="columns">Поля первичного ключа</param>
    public static TQuery SetPrimaryKey<TQuery, TEnum>(this TQuery query, TEnum pkName, params TEnum[] columns)
        where TQuery : CreateTableQuery
        where TEnum : Enum
    {
        var naming = query.Connection.Naming;

        query.SetPrimaryColumnCore(
            pkName is null ? null : naming.GetName(pkName),
            columns.Select(f => naming.GetName(f)).ToArray());

        return query;
    }

}
