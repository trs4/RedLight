using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight;

/// <summary>Изменение базы данных</summary>
public abstract class DatabaseQuery : Query, IRunQuery
{
    protected DatabaseQuery(DatabaseConnection connection, string databaseName)
        : base(connection)
        => DatabaseName = string.IsNullOrEmpty(databaseName) ? throw new ArgumentNullException(nameof(databaseName)) : databaseName;

    /// <summary>Имя базы данных</summary>
    public string DatabaseName { get; }

    /// <summary>Максимальное время ожидания выполнения запроса</summary>
    public int Timeout { get; set; }

    /// <summary>Выполняет запрос</summary>
    public void Run()
    {
        var (sql, options) = BuildSql();

        if (sql.Length > 0)
            Connection.Run(sql, options, Timeout);
    }

    /// <summary>Выполняет запрос</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    public async Task RunAsync(CancellationToken token = default)
    {
        var (sql, options) = BuildSql();

        if (sql.Length > 0)
            await Connection.RunAsync(sql, options, Timeout, token).ConfigureAwait(false);
    }

}
