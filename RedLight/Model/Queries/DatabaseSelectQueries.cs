using System;
using IcyRain.Tables;
using RedLight.Internal;

namespace RedLight;

/// <summary>Запросы чтения данных</summary>
public abstract class DatabaseSelectQueries
{
    protected DatabaseSelectQueries(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery CreateQuery(string tableName, string alias = null)
        => Create<DataResult>(Connection.Naming.GetNameWithSchema(tableName), alias is null ? null : Connection.Naming.GetName(alias));

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery CreateQuery<TEnum>(TEnum tableName, string alias = null)
        where TEnum : Enum
        => Create<DataResult>(Connection.Naming.GetNameWithSchema(tableName), alias is null ? null : Connection.Naming.GetName(alias));

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery CreateQuery<TEnum>(string alias = null)
        where TEnum : Enum
        => Create<DataResult>(Connection.Naming.GetNameWithSchema<TEnum>(), alias is null ? null : Connection.Naming.GetName(alias));

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery CreateWithParseQuery<TEnum>(string alias = null)
        where TEnum : Enum
    {
        var table = TableGenerator.From<TEnum>();
        var query = CreateQuery<DataResult>(table.Name, alias);

        foreach (var column in table.Columns)
            query.AddColumn(column.Name, alias);

        return query;
    }


    /// <summary>Создаёт запрос выборки данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery<TResult> CreateQuery<TResult>(string tableName, string alias = null)
        => Create<TResult>(Connection.Naming.GetNameWithSchema(tableName), alias is null ? null : Connection.Naming.GetName(alias));

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery<TResult> CreateQuery<TResult, TEnum>(TEnum tableName, string alias = null)
        where TEnum : Enum
        => Create<TResult>(Connection.Naming.GetNameWithSchema(tableName), alias is null ? null : Connection.Naming.GetName(alias));

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery<TResult> CreateQuery<TResult, TEnum>(string alias = null)
        where TEnum : Enum
        => Create<TResult>(Connection.Naming.GetNameWithSchema<TEnum>(), alias is null ? null : Connection.Naming.GetName(alias));

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <typeparam name="TResult">Тип результата</typeparam>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery<TResult> CreateWithParseQuery<TResult, TEnum>(string alias = null)
        where TEnum : Enum
    {
        var table = TableGenerator.From<TEnum>();
        var query = CreateQuery<TResult>(table.Name, alias);
        var type = typeof(TResult);

        if (type == typeof(DataSet) || type == typeof(DataTable))
        {
            foreach (var column in table.Columns)
                query.AddColumn(column.Name, alias);
        }
        else if (type.IsClass && !type.IsSystem())
        {
            foreach (var column in table.Columns)
            {
                var propertyInfo = type.GetProperty(column.Name);

                if (propertyInfo is null)
                    continue;

                query.AddColumn(column.Name, alias);
                query.AddReadAction(column, (obj, value) => propertyInfo.SetValue(obj, value));
            }
        }
        else
            throw new NotImplementedException();

        return query;
    }


    /// <summary>Создаёт запрос выборки данных с вложенным запросом</summary>
    /// <param name="fromQuery">Вложенный запрос</param>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery CreateQuery(SelectQuery fromQuery, string alias = null)
    {
        ArgumentNullException.ThrowIfNull(fromQuery);
        var query = Create<DataResult>(fromQuery.TableName, alias is null ? null : Connection.Naming.GetName(alias));
        query.FromSelect = fromQuery;
        return query;
    }

    /// <summary>Создаёт запрос выборки данных</summary>
    /// <param name="fromQuery">Вложенный запрос</param>
    /// <param name="alias">Псевдоним таблицы</param>
    public SelectQuery<TResult> CreateQuery<TResult>(SelectQuery fromQuery, string alias = null)
    {
        ArgumentNullException.ThrowIfNull(fromQuery);
        var query = Create<TResult>(fromQuery.TableName, alias is null ? null : Connection.Naming.GetName(alias));
        query.FromSelect = fromQuery;
        return query;
    }


    /// <summary>Создаёт запрос ввода данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public ConstSelectQuery CreateConstQuery(string tableName)
        => CreateConst(Connection.Naming.GetName(tableName));

    /// <summary>Создаёт запрос ввода данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    public ConstSelectQuery CreateConstQuery<TEnum>(TEnum tableName)
        where TEnum : Enum
        => CreateConst(Connection.Naming.GetName(tableName));

    /// <summary>Создаёт запрос ввода данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    public ConstSelectQuery CreateConstQuery<TEnum>()
        where TEnum : Enum
        => CreateConst(Connection.Naming.GetName<TEnum>());

    /// <summary>Создаёт запрос ввода данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="dataTable">Таблица данных</param>
    public ConstSelectQuery CreateConstQuery(string tableName, DataTable dataTable)
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = CreateConst(Connection.Naming.GetName(tableName));
        query.AddColumns(dataTable);
        return query;
    }

    /// <summary>Создаёт запрос ввода данных</summary>
    /// <param name="tableName">Имя таблицы</param>
    /// <param name="dataTable">Таблица данных</param>
    public ConstSelectQuery CreateConstQuery<TEnum>(TEnum tableName, DataTable dataTable)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = CreateConst(Connection.Naming.GetName(tableName));
        query.AddColumns(dataTable);
        return query;
    }

    /// <summary>Создаёт запрос ввода данных</summary>
    /// <typeparam name="TEnum">Имя таблицы</typeparam>
    /// <param name="dataTable">Таблица данных</param>
    public ConstSelectQuery CreateConstQuery<TEnum>(DataTable dataTable)
        where TEnum : Enum
    {
        ArgumentNullException.ThrowIfNull(dataTable);
        var query = CreateConst(Connection.Naming.GetName<TEnum>());
        query.AddColumns(dataTable);
        return query;
    }

    protected abstract SelectQuery<TResult> Create<TResult>(string tableName, string alias);

    protected abstract ConstSelectQuery CreateConst(string tableName);
}
