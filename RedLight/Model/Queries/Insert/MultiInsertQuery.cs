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

/// <summary>Запрос добавления множественных данных</summary>
public abstract class MultiInsertQuery : DataMultiValueQuery
{
    protected readonly List<string> _returningColumns = new(8);

    protected MultiInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

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
    protected void BuildSqlEnd(StringBuilder builder, QueryOptions options, int startIndex, int packetSize)
    {
        bool buildSelect = _checkExistenceJoin is not null;

        if (buildSelect)
        {
            builder.Append("SELECT ");
            ColumnBuilder.Build(builder, _columns, f => Naming.BuildRawNameWithAlias(builder, DataAlias, f.Name));
            builder.Append(" FROM (\r\n");
        }

        QueryBuilder.BuildValues(builder, Connection, _columns, startIndex, packetSize);

        if (buildSelect)
        {
            builder.Append("\r\n) AS ").Append(DataAlias).Append("\r\n(\r\n  ");
            ColumnBuilder.Build(builder, _columns, f => f.Name);
            builder.Append("\r\n)");

            _checkExistenceJoin.BuildJoinSql(builder, options, _where);
            _checkExistenceTerm.BuildSql(builder, options, Consts.Where);
        }
    }

    #endregion
}

/// <summary>Запроса добавления множественных данных</summary>
public abstract class MultiInsertQuery<TResult> : MultiInsertQuery
{
    private List<Action<TResult, DbDataReader>> _readActions;

    protected MultiInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <returns>Результат заданного типа</returns>
    public List<TResult> Get()
    {
        var (sql, context) = BuildSql();

        var readAction = new Func<DbDataReader, List<TResult>>(reader
            => DataReader.Read(reader, context, _readActions, () => _returningColumns));

        return Connection.Get(sql, readAction, context, Timeout);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public async Task<List<TResult>> GetAsync(CancellationToken token = default)
    {
        var (sql, context) = BuildSql();

        var readAction = new Func<DbDataReader, List<TResult>>(reader
            => DataReader.Read(reader, context, _readActions, () => _returningColumns));

        return await Connection.GetAsync(sql, readAction, context, Timeout, token).ConfigureAwait(false);
    }

    [MethodImpl(Flags.HotPath)]
    internal void AddReadAction<T>(Action<TResult, T> readAction) => ScalarReadBuilder.Add(ref _readActions, readAction);
}
