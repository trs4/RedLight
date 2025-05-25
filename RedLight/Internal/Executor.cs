using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight.Internal;

/// <summary>Внутренний интерфейс выполнения запросов к базе данных</summary>
internal abstract class Executor : IDisposable
{
    private string _connectionString;
    private DbConnection _connection;
    private volatile int _sessionCount;

    private List<DatabaseConnectionSession> _prepareSessions;
    private readonly Stack<DatabaseTransaction> _transactions = new();

    protected Executor(DatabaseConnectionParameters parameters)
        => Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));

    /// <summary>Параметры подключения к базе данных</summary>
    public DatabaseConnectionParameters Parameters { get; }

    public string ConnectionString => _connectionString ??= BuildConnectionString();

    public DbConnection Connection => _connection ?? throw new ObjectDisposedException(GetType().Name);

    protected abstract string BuildConnectionString();

    protected abstract DbConnection CreateConnection();

    protected abstract DbParameter CreateParameter(QueryParameter parameter);

    #region Session

    public void PrepareBeginSession(DatabaseConnectionSession transactionSession)
        => (_prepareSessions ??= []).Add(transactionSession);

    public void BeginSession()
    {
        if (_sessionCount == 0)
        {
            var connection = _connection ??= CreateConnection();
            connection.Open();
        }

        _sessionCount++;

        if (_prepareSessions != null)
            OpenTransactions();
    }

    public async Task BeginSessionAsync()
    {
        if (_sessionCount == 0)
        {
            var connection = _connection ??= CreateConnection();
            await connection.OpenAsync().ConfigureAwait(false);
        }

        _sessionCount++;

        if (_prepareSessions != null)
            OpenTransactions();
    }

    public void EndSession()
    {
        if (_sessionCount > 0)
            _sessionCount--;

        if (_sessionCount == 0)
            Connection.Close();
    }

    #endregion
    #region Transaction

    private void OpenTransactions()
    {
        _sessionCount += _prepareSessions.Count;

        foreach (var prepareSession in _prepareSessions)
        {
            if (prepareSession.TransactionName != null)
                prepareSession.GetTransaction().Open();
        }

        _prepareSessions = null;
    }

    public DbTransaction BeginTransaction()
    {
        if (GetCurrentTransaction() != null)
            throw new InvalidOperationException("There's already an open transaction");

        return Connection.BeginTransaction();
    }

    public void OnTransactionStarted(DatabaseTransaction transaction)
        => _transactions.Push(transaction);

    public void OnTransactionEnded(DatabaseTransaction transaction)
    {
        if (_transactions.Peek() != transaction)
            throw new InvalidOperationException();

        _transactions.Pop();
    }

    public bool HasTransactions() => _transactions.Count > 0;

    public int GetTransactionCount() => _transactions.Count;

    public DatabaseTransaction GetCurrentTransaction()
        => _transactions.Count == 0 ? null : _transactions.Peek();

    public bool ContainsTransaction(string name)
        => _transactions.Any(t => String.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase));

    #endregion
    #region Command

    public DbCommand CreateCommand(string sql, ref QueryOptions options, int timeout)
    {
        if (sql.Length > Consts.MaxQuerySize)
            throw new ArgumentException("Query length is greater than limit", nameof(sql));

        options ??= new QueryOptions(false);
        var command = Connection.CreateCommand();
#pragma warning disable CA2100 // Review SQL queries for security vulnerabilities
        command.CommandText = sql;
#pragma warning restore CA2100 // Review SQL queries for security vulnerabilities

        if (timeout > 0)
            command.CommandTimeout = timeout;

        if (!options.Parameters.IsNullOrEmpty())
        {
            if (options.Parameters.Count > Consts.MaxQueryParameters)
                throw new InvalidOperationException("Query parameter count is greater than limit");

            foreach (var parameter in options.Parameters)
                command.Parameters.Add(CreateParameter(parameter));
        }

        GetCurrentTransaction()?.OnCreateCommand(command);
        return command;
    }

    #endregion
    #region Run

    public object Run(string sql, QueryOptions options, int timeout,
        RunMode mode, CommandBehavior behavior = CommandBehavior.Default)
        => mode switch
        {
            RunMode.NonQuery => RunNonQuery(sql, options, timeout),
            RunMode.Reader => RunReader(sql, options, timeout, behavior),
            RunMode.Scalar => RunScalar(sql, options, timeout),
            _ => throw new NotSupportedException(mode.ToString()),
        };

    public async Task<object> RunAsync(string sql, QueryOptions options, int timeout,
        RunMode mode, CancellationToken token, CommandBehavior behavior = CommandBehavior.Default)
        => mode switch
        {
            RunMode.NonQuery => await RunNonQueryAsync(sql, options, timeout, token).ConfigureAwait(false),
            RunMode.Reader => await RunReaderAsync(sql, options, timeout, token, behavior).ConfigureAwait(false),
            RunMode.Scalar => await RunScalarAsync(sql, options, timeout, token).ConfigureAwait(false),
            _ => throw new NotSupportedException(mode.ToString()),
        };

    #endregion
    #region Run non query

    public int RunNonQuery(string sql, QueryOptions options, int timeout)
    {
        if (String.IsNullOrEmpty(sql))
            return 0;

        DbCommand command = null;

        try
        {
            BeginSession();
            command = CreateCommand(sql, ref options, timeout);
            return command.ExecuteNonQuery();
        }
        finally
        {
            EndSession();
            command?.Dispose();
        }
    }

    public async Task<int> RunNonQueryAsync(string sql, QueryOptions options, int timeout, CancellationToken token)
    {
        if (String.IsNullOrEmpty(sql))
            return 0;

        DbCommand command = null;

        try
        {
            await BeginSessionAsync().ConfigureAwait(false);
            command = CreateCommand(sql, ref options, timeout);
            return await command.ExecuteNonQueryAsync(token).ConfigureAwait(false);
        }
        finally
        {
            EndSession();
            command?.Dispose();
        }
    }

    #endregion
    #region Run reader

    public DbDataReader RunReader(string sql, QueryOptions options, int timeout,
        CommandBehavior behavior = CommandBehavior.Default)
    {
        if (String.IsNullOrEmpty(sql))
            return EmptyDataReader.Instance;

        var command = CreateCommand(sql, ref options, timeout);
        return command.ExecuteReader(behavior);
    }

    public async Task<DbDataReader> RunReaderAsync(string sql, QueryOptions options, int timeout, CancellationToken token,
        CommandBehavior behavior = CommandBehavior.Default)
    {
        if (String.IsNullOrEmpty(sql))
            return EmptyDataReader.Instance;

        var command = CreateCommand(sql, ref options, timeout);
        return await command.ExecuteReaderAsync(behavior, token).ConfigureAwait(false);
    }

    #endregion
    #region Run scalar

    public object RunScalar(string sql, QueryOptions options, int timeout)
    {
        if (String.IsNullOrEmpty(sql))
            return null;

        DbCommand command = null;

        try
        {
            BeginSession();
            command = CreateCommand(sql, ref options, timeout);
            object result = command.ExecuteScalar();
            return EscapeScalar(result);
        }
        finally
        {
            EndSession();
            command?.Dispose();
        }
    }

    public async Task<object> RunScalarAsync(string sql, QueryOptions options, int timeout, CancellationToken token)
    {
        if (String.IsNullOrEmpty(sql))
            return null;

        DbCommand command = null;

        try
        {
            await BeginSessionAsync().ConfigureAwait(false);
            command = CreateCommand(sql, ref options, timeout);
            object result = await command.ExecuteScalarAsync(token).ConfigureAwait(false);
            return EscapeScalar(result);
        }
        finally
        {
            EndSession();
            command?.Dispose();
        }
    }

    [MethodImpl(Flags.HotPath)]
    private static object EscapeScalar(object result) => result is DBNull ? null : result;

    #endregion

    public DataTable GetSchema(string collectionName)
    {
        try
        {
            BeginSession();
            return _connection.GetSchema(collectionName);
        }
        finally
        {
            EndSession();
        }
    }

    protected void Prepare(DbConnectionStringBuilder builder)
    {
        if (String.IsNullOrEmpty(Parameters.ConnectionString))
            return;

        var dbBuilder = new DbConnectionStringBuilder() { ConnectionString = Parameters.ConnectionString };
        dbBuilder.Remove(nameof(DatabaseConnectionParameters.Provider));
        builder.ConnectionString = dbBuilder.ConnectionString;
    }

    public virtual void Clear()
    {
        _connection?.Dispose();
        _connection = null;
    }

    public void Dispose()
    {
        Clear();
        GC.SuppressFinalize(this);
    }

}
