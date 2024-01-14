using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using RedLight.Internal;

namespace RedLight;

/// <summary>Транзакция</summary>
public class DatabaseTransaction : IDisposable
{
    private static readonly ConnectionState[] _openedStates = [ConnectionState.Open, ConnectionState.Executing];

    private readonly DatabaseConnection _connection;
    private readonly string _transactionName;
    protected DbTransaction _transaction;

    internal DatabaseTransaction(DatabaseConnection connection, string transactionName)
    {
        _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _transactionName = transactionName;
    }

    /// <summary>Состояние транзакции</summary>
    public DatabaseTransactionState State { get; private set; }

    /// <summary>Имя точки сохранения</summary>
    public string Name { get; private set; }

    internal void Open()
    {
        if (State != DatabaseTransactionState.None)
            throw new InvalidOperationException(State.ToString());

        string name = _transactionName;

        if (_connection.Executor.HasTransactions())
        {
            if (String.IsNullOrEmpty(name) || name.Length > MaxSavepointNameLength || _connection.Executor.ContainsTransaction(name))
                name = "Savepoint" + _connection.Executor.GetTransactionCount();

            _transaction = _connection.Executor.GetCurrentTransaction()._transaction;
            CreateSavepoint(name);
        }
        else
            _transaction = _connection.Executor.BeginTransaction();

        Name = name;
        State = DatabaseTransactionState.Opened;
        _connection.Executor.OnTransactionStarted(this);
    }

    [MethodImpl(Flags.HotPath)]
    private void CheckOpenedState()
    {
        if (State != DatabaseTransactionState.Opened || !ReferenceEquals(_connection.Executor.GetCurrentTransaction(), this))
            throw new InvalidOperationException();
    }

    internal void Commit()
    {
        CheckOpenedState();

        if (_transaction?.Connection is not null && _connection.Executor.GetTransactionCount() == 1
            && _openedStates.Contains(_transaction.Connection.State))
        {
            _transaction.Commit();
        }

        State = DatabaseTransactionState.Commited;
        _connection.Executor.OnTransactionEnded(this);
    }

    internal void Rollback()
    {
        CheckOpenedState();

        if (_connection.Executor.GetTransactionCount() == 1)
        {
            var connection = _transaction?.Connection;

            if (connection is not null && _openedStates.Contains(connection.State))
                _transaction.Rollback();

            _transaction?.Dispose();
            _transaction = null;
        }
        else
        {
            RollbackSavepoint();
        }

        State = DatabaseTransactionState.Rollbacked;
        _connection.Executor.OnTransactionEnded(this);
    }

    internal void OnCreateCommand(DbCommand command)
        => command.Transaction = _transaction;

    protected virtual void CreateSavepoint(string name) => throw new NotSupportedException();

    protected virtual void RollbackSavepoint() => _transaction.Rollback();

    protected virtual int MaxSavepointNameLength => 32;

    public void Dispose()
    {
        if (State == DatabaseTransactionState.Opened)
            Rollback();

        GC.SuppressFinalize(this);
    }

}
