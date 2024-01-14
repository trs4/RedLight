using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight;

/// <summary>Запрос изменения схемы таблицы</summary>
public abstract class SchemaQuery : Query, IRunQuery
{
    protected SchemaQuery(DatabaseConnection connection, string tableName)
        : base(connection)
    {
        if (String.IsNullOrWhiteSpace(tableName))
            throw new ArgumentNullException(nameof(tableName));

        TableName = tableName;
        IsTempTable = tableName[0] == '@';
    }

    /// <summary>Имя таблицы</summary>
    public string TableName { get; }

    /// <summary>Таблица является временной или переменной</summary>
    public bool IsTempTable { get; }

    /// <summary>Максимальное время ожидания выполнения запроса</summary>
    public int Timeout { get; set; }

    /// <summary>Выполняет запрос</summary>
    public void Run()
    {
        var (sql, options) = BuildSql();
        Connection.Run(sql, options, Timeout);
    }

    /// <summary>Выполняет запрос</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    public async Task RunAsync(CancellationToken token = default)
    {
        var (sql, options) = BuildSql();
        await Connection.RunAsync(sql, options, Timeout, token).ConfigureAwait(false);
    }

}
