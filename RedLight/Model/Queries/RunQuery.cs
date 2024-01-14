using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight;

/// <summary>Построитель запроса управления данными</summary>
public abstract class RunQuery : Query, IRunQuery
{
    protected RunQuery(DatabaseConnection connection) : base(connection) { }

    /// <summary>Максимальное время ожидания выполнения запроса</summary>
    public int Timeout { get; set; }

    #region Execute

    /// <summary>Выполняет запрос без получения результата</summary>
    /// <returns>Количество обработанных строк</returns>
    public int Run()
    {
        var (sql, options) = BuildSql();
        return Connection.Run(sql, options, Timeout);
    }

    /// <summary>Выполняет запрос без получения результата</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Количество обработанных строк</returns>
    public Task<int> RunAsync(CancellationToken token = default)
    {
        var (sql, options) = BuildSql();
        return Connection.RunAsync(sql, options, Timeout, token);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <returns>Результат заданного типа</returns>
    public T Get<T>()
    {
        var (sql, options) = BuildSql();
        return Connection.Get<T>(sql, options, Timeout);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public Task<T> GetAsync<T>(CancellationToken token = default)
    {
        var (sql, options) = BuildSql();
        return Connection.GetAsync<T>(sql, options, Timeout, token);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="readAction">Действие чтения данных</param>
    /// <returns>Результат заданного типа</returns>
    public T Get<T>(Func<DbDataReader, T> readAction)
    {
        var (sql, options) = BuildSql();
        return Connection.Get(sql, readAction, options, Timeout);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="readAction">Действие чтения данных</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public Task<T> GetAsync<T>(Func<DbDataReader, T> readAction, CancellationToken token = default)
    {
        var (sql, options) = BuildSql();
        return Connection.GetAsync(sql, readAction, options, Timeout, token);
    }

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="behavior">Режим перессылки данных с базы данных</param>
    /// <returns>Интерфейс чтения строк таблицы</returns>
    /// <remarks>Открыть и закрыть сессию (соединение с базой данных) нужно самим</remarks>
    public DbDataReader GetReader(CommandBehavior behavior = CommandBehavior.Default)
    {
        var (sql, options) = BuildSql();
        return Connection.GetReader(sql, options, Timeout, behavior);
    }

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="behavior">Режим перессылки данных с базы данных</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Интерфейс чтения строк таблицы</returns>
    /// <remarks>Открыть и закрыть сессию (соединение с базой данных) нужно самим</remarks>
    public Task<DbDataReader> GetReaderAsync(CommandBehavior behavior = CommandBehavior.Default,
        CancellationToken token = default)
    {
        var (sql, options) = BuildSql();
        return Connection.GetReaderAsync(sql, options, Timeout, behavior, token);
    }

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="source">Список, в который будет добавлен результат</param>
    public void Append<T>(ICollection<T> source)
    {
        var (sql, options) = BuildSql();
        Connection.Run(source, sql, options, Timeout);
    }

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="source">Список, в который будет добавлен результат</param>
    /// <param name="token">Оповещение отмены задачи</param>
    public Task AppendAsync<T>(ICollection<T> source, CancellationToken token = default)
    {
        var (sql, options) = BuildSql();
        return Connection.RunAsync(source, sql, options, Timeout, token);
    }

    #endregion
}
