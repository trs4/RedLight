using System;

namespace RedLight;

/// <summary>Запросы изменения схемы данных</summary>
public abstract class DatabaseSchemaQueries
{
    protected DatabaseSchemaQueries(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Создание базы данных</summary>
    /// <param name="databaseName">Имя базы данных</param>
    public abstract CreateDatabaseQuery CreateDatabaseQuery(string databaseName);

    /// <summary>Удаление базы данных</summary>
    /// <param name="databaseName">Имя базы данных</param>
    public abstract DeleteDatabaseQuery DeleteDatabaseQuery(string databaseName);


    /// <summary>Добавление таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public CreateTableQuery CreateTableQuery(string tableName)
        => CreateCreateTable(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Добавление таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public CreateTableQuery CreateTableQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateCreateTable(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Добавление таблицы</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public CreateTableQuery CreateTableQuery<TEnum>()
        where TEnum : Enum
        => CreateCreateTable(Connection.Naming.GetNameWithSchema<TEnum>());

    /// <summary>Создаёт таблицу</summary>
    /// <param name="table">Описание таблицы</param>
    public CreateTableQuery CreateTableQuery(Table table)
    {
        ArgumentNullException.ThrowIfNull(table);
        return CreateTableQuery(table.Name).AddColumns(table.Columns);
    }

    /// <summary>Добавление таблицы</summary>
    /// <typeparam name="TEnum">Перечисление таблицы с полями</typeparam>
    public CreateTableQuery CreateTableWithParseQuery<TEnum>()
        where TEnum : Enum
    {
        var table = TableGenerator.From<TEnum>();
        var identityColumn = table.Identity;
        var primaryKey = table.PrimaryKey;
        var query = CreateTableQuery(table.Name).AddColumns(table.Columns);

        if (identityColumn is not null)
            query.AddIdentityColumn(identityColumn.Name, identityColumn.SequenceName, identityColumn.Type, identityColumn.Increment, identityColumn.MinValue);

        if (primaryKey is not null)
            query.SetPrimaryKey(primaryKey.Name, primaryKey.Columns);

        return query;
    }


    /// <summary>Удаление таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteTableQuery DeleteTableQuery(string tableName)
        => CreateDeleteTable(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Удаление таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteTableQuery DeleteTableQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateDeleteTable(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Удаление таблицы</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public DeleteTableQuery DeleteTableQuery<TEnum>()
        where TEnum : Enum
        => CreateDeleteTable(Connection.Naming.GetNameWithSchema<TEnum>());

    /// <summary>Удаляет таблицу</summary>
    /// <param name="table">Описание таблицы</param>
    public DeleteTableQuery DeleteTableQuery(Table table)
    {
        ArgumentNullException.ThrowIfNull(table);
        return DeleteTableQuery(table.Name);
    }


    /// <summary>Добавление колонки в таблицу</summary>
    /// <param name="tableName">Имя таблицы</param>
    public CreateColumnQuery CreateColumnQuery(string tableName)
        => CreateCreateColumn(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Добавление колонки в таблицу</summary>
    /// <param name="tableName">Имя таблицы</param>
    public CreateColumnQuery CreateColumnQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateCreateColumn(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Добавление колонки в таблицу</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public CreateColumnQuery CreateColumnQuery<TEnum>()
        where TEnum : Enum
        => CreateCreateColumn(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Изменение колонки таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public ModifyColumnQuery ModifyColumnQuery(string tableName)
        => CreateModifyColumn(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Изменение колонки таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public ModifyColumnQuery ModifyColumnQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateModifyColumn(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Изменение колонки таблицы</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public ModifyColumnQuery ModifyColumnQuery<TEnum>()
        where TEnum : Enum
        => CreateModifyColumn(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Удаление колонки из таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteColumnQuery DeleteColumnQuery(string tableName)
        => CreateDeleteColumn(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Удаление колонки из таблицы</summary>
    /// <param name="tableName">Имя таблицы</param>
    public DeleteColumnQuery DeleteColumnQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateDeleteColumn(Connection.Naming.GetNameWithSchema(tableName));

    /// <summary>Удаление колонки из таблицы</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public DeleteColumnQuery DeleteColumnQuery<TEnum>()
        where TEnum : Enum
        => CreateDeleteColumn(Connection.Naming.GetNameWithSchema<TEnum>());


    /// <summary>Получает описание схемы базы данных</summary>
    /// <returns>Описание схемы базы данных</returns>
    public virtual SchemaInfoQuery InfoQuery() => new SchemaInfoQuery(Connection);

    protected abstract CreateTableQuery CreateCreateTable(string tableName);

    protected abstract DeleteTableQuery CreateDeleteTable(string tableName);

    protected abstract CreateColumnQuery CreateCreateColumn(string tableName);

    protected abstract ModifyColumnQuery CreateModifyColumn(string tableName);

    protected abstract DeleteColumnQuery CreateDeleteColumn(string tableName);
}
