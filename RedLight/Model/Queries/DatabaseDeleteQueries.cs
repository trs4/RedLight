using System;
using System.Collections.Generic;
using RedLight.Internal;

namespace RedLight;

/// <summary>Запросы удаления данных</summary>
public abstract class DatabaseDeleteQueries
{
    protected DatabaseDeleteQueries(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Создаёт запрос удаления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteQuery CreateQuery(string tableName)
        => Create(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteQuery CreateQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => Create(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public DeleteQuery CreateQuery<TEnum>()
        where TEnum : Enum
        => Create(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Создаёт запрос удаления данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="row">Удаляемый объект</param>
    public DeleteQuery CreateWithParseQuery<TResult, TEnum>(TResult row)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var query = CreateQuery<TEnum>();
        TypeAction<TResult>.Instance.BuildWithParseQuery(query, table, row, primaryKeyNames);
        return query;
    }

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Удаляемые объекты</param>
    public DeleteQuery CreateWithParseQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        string primaryKeyName = primaryKeyNames.Length == 1 ? primaryKeyNames[0] : throw new InvalidOperationException("Use CreateWithParseMultiQuery");
        var query = CreateQuery<TEnum>();
        TypeAction<TResult>.Instance.BuildWithParseQuery(query, table, rows, primaryKeyName);
        return query;
    }


    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiDeleteQuery CreateMultiQuery(string tableName)
        => CreateMulti(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public MultiDeleteQuery CreateMultiQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateMulti(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public MultiDeleteQuery CreateMultiQuery<TEnum>()
        where TEnum : Enum
        => CreateMulti(Connection.Naming.GetNameWithSchema<TEnum>());

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="rows">Удаляемые объекты</param>
    public MultiDeleteQuery CreateWithParseMultiQuery<TResult, TEnum>(IReadOnlyCollection<TResult> rows)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(rows);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var query = CreateMultiQuery<TEnum>();
        TypeAction<TResult>.Instance.BuildWithParseMultiQuery(query, table, rows, primaryKeyNames);
        return query;
    }

    /// <summary>Создаёт запрос удаления множественных данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="row">Удаляемый объект</param>
    public MultiDeleteQuery CreateWithParseMultiQuery<TResult, TEnum>(TResult row)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(row);
        var table = TableGenerator.From<TEnum>();
        string[] primaryKeyNames = table.GetPrimaryKeyNames();
        var query = CreateMultiQuery<TEnum>();
        TypeAction<TResult>.Instance.BuildWithParseMultiQuery(query, table, row, primaryKeyNames);
        return query;
    }

    protected abstract DeleteQuery Create(string tableName);

    protected abstract MultiDeleteQuery CreateMulti(string tableName);
}
