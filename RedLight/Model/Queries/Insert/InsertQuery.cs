using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RedLight.Internal;

namespace RedLight;

/// <summary>Запрос добавления данных</summary>
public abstract class InsertQuery : DataValueQuery
{
    protected readonly List<string> _returningColumns = [];

    protected InsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    /// <summary>Список запрашиваемых полей</summary>
    public ReadOnlyCollection<string> ReturningColumns => _returningColumns.AsReadOnly();

    /// <summary>Имя таблицы, в которую будет записан результат</summary>
    public string OutputTableName { get; internal set; }

    #region Internal

    [MethodImpl(Flags.HotPath)]
    internal void AddReturningColumnCore(string name) => _returningColumns.Add(name);

    [MethodImpl(Flags.HotPath)]
    protected void BuildSqlBegin(StringBuilder builder)
    {
        builder.Append("INSERT INTO ").Append(TableName).Append(" (");
        ColumnBuilder.Build(builder, _columns, f => f.Name);
        builder.Append(")\r\n");
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildSqlEnd(StringBuilder builder, QueryOptions options)
    {
        bool buildSelect = _checkExistenceJoin is not null;

        if (buildSelect)
        {
            builder.Append("SELECT ");
            ColumnBuilder.Build(builder, _columns, f => Naming.BuildRawNameWithAlias(builder, DataAlias, f.Name));
            builder.Append(" FROM (\r\n");
        }

        builder.Append("VALUES (");
        ColumnBuilder.Build(builder, _columns, f => f.GetEscapedString(Connection, options));
        builder.Append(')');

        if (buildSelect)
        {
            builder.Append("\r\n) AS ").Append(DataAlias).Append("\r\n(\r\n  ");
            ColumnBuilder.Build(builder, _columns, f => f.Name);
            builder.Append("\r\n)");

            _checkExistenceJoin.BuildJoinSql(builder, options, _where);
            _checkExistenceTerm.BuildSql(builder, options, Consts.Where);
        }
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildSqlReturning(StringBuilder builder)
    {
        if (_returningColumns.Count == 0)
            return;

        builder.Append("\r\nRETURNING ");
        ColumnBuilder.Build(builder, _returningColumns);
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildSqlOutput(StringBuilder builder)
    {
        if (_returningColumns.Count == 0)
            return;

        builder.Append("OUTPUT ");
        ColumnBuilder.Build(builder, _returningColumns, f => builder.Append("INSERTED.").Append(f));

        if (OutputTableName is not null)
            builder.Append("\r\n  INTO ").Append(OutputTableName);

        builder.AppendLine();
    }

    #endregion
}

/// <summary>Запрос добавления данных</summary>
public abstract class InsertQuery<TResult> : InsertQuery
{
    private List<Action<TResult, DbDataReader>> _readActions;

    protected InsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal TResult Data { get; set; }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <returns>Результат заданного типа</returns>
    public List<TResult> Get()
    {
        var (sql, context) = BuildSql();
        var readAction = new Func<DbDataReader, List<TResult>>(reader => DataReader.Read(reader, context, _readActions, () => _returningColumns));
        return Connection.Get(sql, readAction, context, Timeout);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public Task<List<TResult>> GetAsync(CancellationToken token = default)
    {
        var (sql, context) = BuildSql();
        var readAction = new Func<DbDataReader, List<TResult>>(reader => DataReader.Read(reader, context, _readActions, () => _returningColumns));
        return Connection.GetAsync(sql, readAction, context, Timeout, token);
    }

    /// <summary>Выполняет запрос с заполнением результата</summary>
    public void Fill()
    {
        var (sql, context) = BuildSql();
        var readAction = new Action<DbDataReader>(reader => DataReader.Fill([Data], reader, context, _readActions, () => _returningColumns));
        Connection.Get(sql, readAction, context, Timeout);
    }

    /// <summary>Выполняет запрос с заполнением результата</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    public Task FillAsync(CancellationToken token = default)
    {
        var (sql, context) = BuildSql();
        var readAction = new Action<DbDataReader>(reader => DataReader.Fill([Data], reader, context, _readActions, () => _returningColumns));
        return Connection.GetAsync(sql, readAction, context, Timeout, token);
    }

    [MethodImpl(Flags.HotPath)]
    internal void AddReadAction<T>(Action<TResult, T> readAction) => ScalarReadBuilder.Add(ref _readActions, readAction);

    [MethodImpl(Flags.HotPath)]
    internal void AddReadAction(Type type, Action<TResult, object> readAction) => ScalarReadBuilder.Add(ref _readActions, type, readAction);
}
