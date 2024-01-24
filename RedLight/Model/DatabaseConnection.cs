using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;
using RedLight.Internal;
using DataSet = IcyRain.Tables.DataSet;
using DataTable = IcyRain.Tables.DataTable;

namespace RedLight;

/// <summary>Соединение с базой данных</summary>
public abstract class DatabaseConnection : IDisposable
{
    private DatabaseSchemaQueries _schema;
    private DatabaseSelectQueries _select;
    private DatabaseInsertQueries _insert;
    private DatabaseUpdateQueries _update;
    private DatabaseDeleteQueries _delete;

    protected DatabaseConnection(DatabaseConnectionParameters parameters)
    {
        Executor = CreateExecutor(parameters);
        Functions = CreateFunctions();
        Details = CreateDetails();
        Escaping = CreateEscaping();
    }

    /// <summary>Тип</summary>
    public abstract DatabaseProvider Provider { get; }

    /// <summary>Параметры подключения</summary>
    public DatabaseConnectionParameters Parameters => Executor.Parameters;

    /// <summary>Системные функции</summary>
    public DatabaseFunctions Functions { get; }

    /// <summary>Характеристики и возможности</summary>
    public DatabaseDetails Details { get; }

    /// <summary>Именование таблиц и полей</summary>
    public abstract Naming Naming { get; }

    /// <summary>Именование параметров</summary>
    internal abstract ParameterNaming ParameterNaming { get; }

    /// <summary>Экранирование значений для составления запроса</summary>
    public ValueEscape Escaping { get; }

    /// <summary>Преобразование типов данных</summary>
    internal abstract ColumnTypes ColumnTypes { get; }

    /// <summary>Запросы изменения схемы данных</summary>
    public DatabaseSchemaQueries Schema => _schema ??= CreateSchema();

    /// <summary>Запросы чтения данных</summary>
    public DatabaseSelectQueries Select => _select ??= CreateSelect();

    /// <summary>Запросы добавления данных</summary>
    public DatabaseInsertQueries Insert => _insert ??= CreateInsert();

    /// <summary>Запросы изменения данных</summary>
    public DatabaseUpdateQueries Update => _update ??= CreateUpdate();

    /// <summary>Запросы удаления данных</summary>
    public DatabaseDeleteQueries Delete => _delete ??= CreateDelete();

    /// <summary>Выполнение запросов</summary>
    internal Executor Executor { get; }

    /// <summary>Создаёт подключение для работы с базой данных через строку подключения</summary>
    /// <param name="connectionString">Строка подключения</param>
    public static DatabaseConnection Create(string connectionString)
        => DatabaseConnectionCreator.From(connectionString);

    /// <summary>Создаёт подключение для работы с базой данных через параметры подключения</summary>
    /// <param name="parameters">Параметры подключения</param>
    public static DatabaseConnection Create(DatabaseConnectionParameters parameters)
        => DatabaseConnectionCreator.From(parameters);

    /// <summary>Создаёт построитель списка запросов</summary>
    public BatchQuery CreateBatch() => new BatchQuery(this);

    internal abstract ExplainQuery CreateExplainQuery(Query owner);

    internal abstract JoinQuery CreateJoin(Query owner, string tableName, string alias);

    internal virtual DatabaseTransaction CreateTransaction(string transactionName)
        => new DatabaseTransaction(this, transactionName);

    internal abstract Executor CreateExecutor(DatabaseConnectionParameters parameters);

    protected abstract DatabaseFunctions CreateFunctions();

    protected abstract DatabaseDetails CreateDetails();

    protected abstract ValueEscape CreateEscaping();

    protected abstract DatabaseSchemaQueries CreateSchema();

    protected abstract DatabaseSelectQueries CreateSelect();

    protected abstract DatabaseInsertQueries CreateInsert();

    protected abstract DatabaseUpdateQueries CreateUpdate();

    protected abstract DatabaseDeleteQueries CreateDelete();

    public override string ToString() => Parameters.ToString();

    public void Dispose()
    {
        Executor.Dispose();
        GC.SuppressFinalize(this);
    }

    #region Run

    /// <summary>Выполняет запрос без получения результата</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения запроса</param>
    /// <returns>Количество обработанных строк</returns>
    public int Run(string sql, QueryOptions options = null, int timeout = 0)
        => Executor.RunNonQuery(sql, Prepare(options), GetTimeout(timeout));

    /// <summary>Выполняет запрос без получения результата</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения запроса</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Количество обработанных строк</returns>
    public Task<int> RunAsync(string sql, QueryOptions options = null, int timeout = 0, CancellationToken token = default)
        => Executor.RunNonQueryAsync(sql, Prepare(options), GetTimeout(timeout), token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <returns>Результат заданного типа</returns>
    public T Get<T>(string sql, QueryOptions options = null, int timeout = 0)
    {
        var type = typeof(T);

        if (type.IsCollection())
        {
            var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
            DbDataReader reader = null;

            try
            {
                Executor.BeginSession();
                reader = Executor.RunReader(sql, Prepare(options), GetTimeout(timeout), behavior);
                return TableReader.Create<T>(reader, options);
            }
            finally
            {
                (reader as IDisposable)?.Dispose();
                Executor.EndSession();
            }
        }
        else if (type == typeof(DataSet))
        {
            var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
            DbDataReader reader = null;

            try
            {
                Executor.BeginSession();
                reader = Executor.RunReader(sql, Prepare(options), GetTimeout(timeout), behavior);
                return (T)(object)TableReader.CreateDataSet(this, reader, options);
            }
            finally
            {
                (reader as IDisposable)?.Dispose();
                Executor.EndSession();
            }
        }
        else if (type == typeof(DataTable))
        {
            var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
            DbDataReader reader = null;

            try
            {
                Executor.BeginSession();
                reader = Executor.RunReader(sql, Prepare(options), GetTimeout(timeout), behavior);
                return (T)(object)TableReader.CreateDataTable(this, reader, options);
            }
            finally
            {
                (reader as IDisposable)?.Dispose();
                Executor.EndSession();
            }
        }

        if (!type.IsSystem())
            throw new NotImplementedException();

        {
            object result = Executor.RunScalar(sql, Prepare(options), GetTimeout(timeout));
            return Extensions.Convert<T>(result);
        }
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public async Task<T> GetAsync<T>(string sql, QueryOptions options = null, int timeout = 0, CancellationToken token = default)
    {
        var type = typeof(T);

        if (type.IsCollection())
        {
            var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
            DbDataReader reader = null;

            try
            {
                await Executor.BeginSessionAsync().ConfigureAwait(false);
                reader = await Executor.RunReaderAsync(sql, Prepare(options), GetTimeout(timeout), token, behavior).ConfigureAwait(false);
                return TableReader.Create<T>(reader, options);
            }
            finally
            {
                (reader as IDisposable)?.Dispose();
                Executor.EndSession();
            }
        }
        else if (type == typeof(DataSet))
        {
            var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
            DbDataReader reader = null;

            try
            {
                await Executor.BeginSessionAsync().ConfigureAwait(false);
                reader = await Executor.RunReaderAsync(sql, Prepare(options), GetTimeout(timeout), token, behavior).ConfigureAwait(false);
                return (T)(object)TableReader.CreateDataSet(this, reader, options);
            }
            finally
            {
                (reader as IDisposable)?.Dispose();
                Executor.EndSession();
            }
        }
        else if (type == typeof(DataTable))
        {
            var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
            DbDataReader reader = null;

            try
            {
                await Executor.BeginSessionAsync().ConfigureAwait(false);
                reader = await Executor.RunReaderAsync(sql, Prepare(options), GetTimeout(timeout), token, behavior).ConfigureAwait(false);
                return (T)(object)TableReader.CreateDataTable(this, reader, options);
            }
            finally
            {
                (reader as IDisposable)?.Dispose();
                Executor.EndSession();
            }
        }

        if (!type.IsSystem())
            throw new NotImplementedException();

        {
            object result = await Executor.RunScalarAsync(sql, Prepare(options), GetTimeout(timeout), token).ConfigureAwait(false);
            return Extensions.Convert<T>(result);
        }
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="readAction">Действие чтения данных</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    public void Get(string sql, Action<DbDataReader> readAction, QueryOptions options = null, int timeout = 0)
    {
        ArgumentNullException.ThrowIfNull(readAction);
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            Executor.BeginSession();
            reader = Executor.RunReader(sql, Prepare(options), GetTimeout(timeout), behavior);
            readAction(reader);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            Executor.EndSession();
        }
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="readAction">Действие чтения данных</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <param name="token">Оповещение отмены задачи</param>
    public async Task GetAsync(string sql, Action<DbDataReader> readAction, QueryOptions options = null, int timeout = 0, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(readAction);
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            await Executor.BeginSessionAsync().ConfigureAwait(false);
            reader = await Executor.RunReaderAsync(sql, Prepare(options), GetTimeout(timeout), token, behavior).ConfigureAwait(false);
            readAction(reader);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            Executor.EndSession();
        }
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="readAction">Действие чтения данных</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <returns>Результат заданного типа</returns>
    public T Get<T>(string sql, Func<DbDataReader, T> readAction, QueryOptions options = null, int timeout = 0)
    {
        ArgumentNullException.ThrowIfNull(readAction);
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            Executor.BeginSession();
            reader = Executor.RunReader(sql, Prepare(options), GetTimeout(timeout), behavior);
            return readAction(reader);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            Executor.EndSession();
        }
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="readAction">Действие чтения данных</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public async Task<T> GetAsync<T>(string sql, Func<DbDataReader, T> readAction, QueryOptions options = null, int timeout = 0, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(readAction);
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            await Executor.BeginSessionAsync().ConfigureAwait(false);
            reader = await Executor.RunReaderAsync(sql, Prepare(options), GetTimeout(timeout), token, behavior).ConfigureAwait(false);
            return readAction(reader);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            Executor.EndSession();
        }
    }

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <param name="behavior">Режим перессылки данных с базы данных</param>
    /// <returns>Интерфейс чтения строк таблицы</returns>
    /// <remarks>Открыть и закрыть сессию (соединение с базой данных) нужно самим</remarks>
    public DbDataReader GetReader(string sql, QueryOptions options = null, int timeout = 0, CommandBehavior behavior = CommandBehavior.Default)
        => Executor.RunReader(sql, options, timeout, behavior);

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <param name="behavior">Режим перессылки данных с базы данных</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Интерфейс чтения строк таблицы</returns>
    /// <remarks>Открыть и закрыть сессию (соединение с базой данных) нужно самим</remarks>
    public Task<DbDataReader> GetReaderAsync(string sql, QueryOptions options = null, int timeout = 0, CommandBehavior behavior = CommandBehavior.Default,
        CancellationToken token = default)
        => Executor.RunReaderAsync(sql, options, timeout, token, behavior);

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="source">Список, в который будет добавлен результат</param>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    public void Run<T>(ICollection<T> source, string sql, QueryOptions options = null, int timeout = 0)
    {
        ArgumentNullException.ThrowIfNull(source);
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            Executor.BeginSession();
            reader = Executor.RunReader(sql, Prepare(options), GetTimeout(timeout), behavior);
            ListReader.Append(this, source, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            Executor.EndSession();
        }
    }

    /// <summary>Выполняет запрос с добавлением результата в данный список</summary>
    /// <param name="source">Список, в который будет добавлен результат</param>
    /// <param name="sql">Текст запроса</param>
    /// <param name="options">Опции запроса</param>
    /// <param name="timeout">Максимальное время ожидания выполнения команды</param>
    /// <param name="token">Оповещение отмены задачи</param>
    public async Task RunAsync<T>(ICollection<T> source, string sql, QueryOptions options = null, int timeout = 0, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(source);
        var behavior = (options?.MultipleResult ?? false) ? CommandBehavior.Default : CommandBehavior.SingleResult;
        DbDataReader reader = null;

        try
        {
            await Executor.BeginSessionAsync().ConfigureAwait(false);
            reader = await Executor.RunReaderAsync(sql, Prepare(options), GetTimeout(timeout), token, behavior).ConfigureAwait(false);
            ListReader.Append(this, source, reader, options);
        }
        finally
        {
            (reader as IDisposable)?.Dispose();
            Executor.EndSession();
        }
    }

    #endregion
    #region Options

    private QueryOptions Prepare(QueryOptions options)
    {
        if (options is null)
            return options;

        int parametersCount = options.Parameters?.Count ?? 0;

        if (parametersCount > 10) // Has padding
            AddPaddingParameters(options, parametersCount);

        return options;
    }

    private void AddPaddingParameters(QueryOptions options, int parametersCount)
    {
        int paddingCount = GetPaddingCount(parametersCount);

        if (paddingCount == 0)
            return;

        var lastParameter = options.Parameters[^1];
        var type = lastParameter.Type;
        bool nullable = lastParameter.Nullable;

        for (int i = 0; i < paddingCount; i++)
        {
            string name = ParameterNaming.GetName(options.Parameters.Count + 1);
            var parameter = new RawQueryParameter(name, null, type, nullable);
            options.Parameters.Add(parameter);
        }
    }

    private static int GetPaddingCount(int parametersCount)
    {
        if (parametersCount <= 10) // No padding
            return 0;

        int paddingFactor;

        if (parametersCount <= 150)
            paddingFactor = 10;
        else if (parametersCount <= 750)
            paddingFactor = 50;
        else if (parametersCount <= 2000)
            paddingFactor = 100; // Max param count
        else
            return 0; // No padding

        // If we have 17, factor = 10; 17 % 10 = 7, we need 3 more
        int intoBlock = parametersCount % paddingFactor;
        return intoBlock == 0 ? 0 : (paddingFactor - intoBlock);
    }

    #endregion
    #region Timeouts

    private const int DefaultQueryTimeout = 3 * 60; // 3 минуты

    private static int GetTimeout(int timeout) => timeout == 0 ? DefaultQueryTimeout : timeout;

    #endregion
}
