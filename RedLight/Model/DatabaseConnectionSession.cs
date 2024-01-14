using System;

namespace RedLight;

/// <summary>Сессия для открытия и закрытия соединения с базой данных</summary>
public sealed class DatabaseConnectionSession : IDisposable
{
    private readonly DatabaseConnection _connection;
    private DatabaseTransaction _transaction;

    private DatabaseConnectionSession(DatabaseConnection connection, string transactionName)
    {
        if (transactionName is not null && (transactionName[0] == ' ' || transactionName[^1] == ' '))
            throw new InvalidOperationException(transactionName);

        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        TransactionName = transactionName;
    }

    /// <summary>Открывает соединение с базой данных при необходимости</summary>
    /// <param name="connection">Соединение с базой данных</param>
    /// <param name="transactionName">Имя транзакции</param>
    public static DatabaseConnectionSession Open(DatabaseConnection connection, string transactionName = null)
    {
        var session = new DatabaseConnectionSession(connection, transactionName);
        connection.Executor.PrepareBeginSession(session);
        return session;
    }

    /// <summary>Открывает соединение с базой данных при необходимости</summary>
    /// <param name="connection">Соединение с базой данных</param>
    /// <param name="condition">Условие открытия соединения</param>
    /// <param name="transactionName">Имя транзакции</param>
    public static DatabaseConnectionSession Open(DatabaseConnection connection, Func<bool> condition, string transactionName = null)
        => condition?.Invoke() ?? false ? Open(connection, transactionName) : null;

    /// <summary>Имя транзакции</summary>
    public string TransactionName { get; }

    /// <summary>Подтвердить транзакцию</summary>
    public void Commit()
    {
        if (_transaction?.State == DatabaseTransactionState.Opened)
            _transaction.Commit();
    }

    /// <summary>Откатить транзакцию</summary>
    public void Rollback()
    {
        if (_transaction?.State == DatabaseTransactionState.Opened)
            _transaction.Rollback();
    }

    internal DatabaseTransaction GetTransaction()
        => _transaction ??= _connection.CreateTransaction(TransactionName);

    /// <summary>Закрывает соединение с базой данных при закрытии всех сессий</summary>
    public void Dispose()
    {
        if (_transaction?.State == DatabaseTransactionState.Opened)
            _transaction.Rollback();

        _transaction = null;
        _connection.Executor.EndSession();
        GC.SuppressFinalize(this);
    }

}
