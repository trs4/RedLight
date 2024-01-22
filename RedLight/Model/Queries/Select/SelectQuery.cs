using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса выборки данных</summary>
public abstract class SelectQuery : WhereQuery
{
    /// <summary>Запрашиваемые поля</summary>
    protected readonly List<QueryColumn> _columns = new(8);

    /// <summary>Пересечения с другими таблицами</summary>
    protected readonly List<JoinQuery> _joins = [];

    /// <summary>Порядки сортировок</summary>
    protected readonly List<string> _orderColumns = new(1);

    /// <summary>Группы</summary>
    protected readonly List<string> _groupColumns = [];

    protected SelectQuery(DatabaseConnection connection, string tableName, string alias)
        : base(connection, tableName, alias)
        => Hints = Hints.NoLock;

    /// <summary>Выставляет оператор удаления дубликатов строк</summary>
    public bool Distinct { get; set; }

    /// <summary>Количество записей, которые требуется прочитать</summary>
    public int Top { get; set; }

    /// <summary>Количество записей, которые требуется пропустить</summary>
    public long Offset { get; set; }

    /// <summary>Режим выборки данных</summary>
    public SelectQueryMode Mode { get; set; }

    /// <summary>Вложенный запрос выборки данных</summary>
    public SelectQuery FromSelect { get; set; }

    /// <summary>Список выбираемых полей</summary>
    public ReadOnlyCollection<QueryColumn> Columns => _columns.AsReadOnly();

    /// <summary>Ищёт пересечение по имени таблицы</summary>
    /// <param name="tableName">Имя таблицы пересечения</param>
    public JoinQuery FindJoin(string tableName)
    {
        if (String.IsNullOrEmpty(tableName))
            throw new ArgumentNullException(nameof(tableName));

        return _joins.FirstOrDefault(j => String.Equals(j.TableName, tableName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>Ищёт пересечение по имени таблицы</summary>
    /// <param name="tableAlias">Имя псевдонима таблицы пересечения</param>
    public JoinQuery FindJoinByAlias(string tableAlias)
    {
        if (String.IsNullOrEmpty(tableAlias))
            throw new ArgumentNullException(nameof(tableAlias));

        return _joins.FirstOrDefault(j => String.Equals(j.Alias, tableAlias, StringComparison.OrdinalIgnoreCase));
    }

    #region Internal

    internal bool SupportsDistinct { get; set; } = true;

    [MethodImpl(Flags.HotPath)]
    internal void AddColumnCore(string tableName, string columnName, string alias = null)
        => _columns.Add(new SelectColumn(tableName ?? Alias, columnName, alias));

    [MethodImpl(Flags.HotPath)]
    internal void AddRawColumnCore(string columnName, string alias = null)
        => _columns.Add(new RawColumn(columnName, alias));

    [MethodImpl(Flags.HotPath)]
    internal JoinQuery AddJoinCore(string tableName, string alias = null, JoinQueryMode type = JoinQueryMode.Inner)
    {
        var join = Connection.CreateJoin(this, tableName, alias);
        join.Type = type;

        _joins.Add(join);
        return join;
    }

    [MethodImpl(Flags.HotPath)]
    private string BeforeAddOrderColumn(string tableName, string columnName, SelectQueryOrder sortOrder)
    {
        string alias = tableName ?? Alias;

        if (alias is not null)
            columnName = Naming.GetRawNameWithAlias(alias, columnName);

        switch (sortOrder)
        {
            case SelectQueryOrder.Ascending:
                columnName += " ASC";
                break;
            case SelectQueryOrder.Descending:
                columnName += " DESC";
                break;
        }

        if (_orderColumns.Contains(columnName))
            throw new InvalidOperationException($"The order list already contains the '{columnName}' column");

        return columnName;
    }

    internal void AddOrderByCore(string tableName, string columnName, SelectQueryOrder sortOrder)
        => _orderColumns.Add(BeforeAddOrderColumn(tableName, columnName, sortOrder));

    internal void InsertOrderByCore(int index, string tableName, string columnName, SelectQueryOrder sortOrder)
        => _orderColumns.Insert(index, BeforeAddOrderColumn(tableName, columnName, sortOrder));

    internal void AddGroupByCore(string tableName, string columnName)
    {
        string alias = tableName ?? Alias;

        if (alias != null)
            columnName = Naming.GetRawNameWithAlias(alias, columnName);

        _groupColumns.Add(columnName);
    }

    protected void BuildFromBlock(StringBuilder builder, QueryOptions options,
        bool canAddTop = true, string topStartBracket = "(", string topEndBracket = ") ", string tableName = null)
    {
        builder.Append("SELECT ");

        if (Distinct && SupportsDistinct)
            builder.Append("DISTINCT ");

        if (Mode == SelectQueryMode.Count)
            builder.Append("Count(*) ");
        else if (Mode == SelectQueryMode.Existence)
        {
            if (canAddTop)
                builder.Append("TOP").Append(topStartBracket).Append('1').Append(topEndBracket);

            builder.Append("* ");
        }
        else
        {
            if (canAddTop && Top > 0 && Offset <= 0)
                builder.Append("TOP").Append(topStartBracket).Append(Top).Append(topEndBracket);

            if (_columns.Count == 0)
                builder.Append("* ");
            else
            {
                ColumnBuilder.Build(builder, _columns, f => f.BuildSql(builder, true));
                builder.Append("\r\n  ");
            }
        }

        builder.Append("FROM ");

        if (FromSelect is null)
            builder.Append(tableName ?? TableName);
        else
        {
            builder.Append("(\r\n");
            FromSelect.BuildSql(builder, options);
            builder.Append("\r\n)");
        }

        if (Alias is not null)
            builder.Append(" AS ").Append(Alias);
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildGroupByBlock(StringBuilder builder)
    {
        if (_groupColumns.Count == 0)
            return;

        builder.Append("\r\n  GROUP BY ").Append(_groupColumns[0]);

        for (int i = 1; i < _groupColumns.Count; i++)
            builder.Append(", ").Append(_groupColumns[i]);
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildJoinsBlock(StringBuilder builder, QueryOptions options)
    {
        foreach (var join in _joins)
            join.BuildSql(builder, options);
    }

    [MethodImpl(Flags.HotPath)]
    protected void BuildOrderByBlock(StringBuilder builder)
    {
        builder.Append("\r\n  ORDER BY ").Append(_orderColumns[0]);

        for (int i = 1; i < _orderColumns.Count; i++)
            builder.Append(", ").Append(_orderColumns[i]);
    }

    #endregion
}

/// <summary>Построитель запроса выборки данных</summary>
public abstract class SelectQuery<TResult> : SelectQuery, IUnionQuery
{
    private List<Action<TResult, DbDataReader>> _readActions;

    protected SelectQuery(DatabaseConnection connection, string tableName, string alias)
        : base(connection, tableName, alias) { }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <returns>Результат заданного типа</returns>
    public List<TResult> Get()
    {
        var (sql, options) = BuildSql(); // Не занимаем соединение с сервером

        var readAction = new Func<DbDataReader, List<TResult>>(reader
            => DataReader.Read(reader, options, _readActions, () => _columns.OfType<SelectColumn>().Select(f => f.Name)));

        return Connection.Get(sql, readAction, options, Timeout);
    }

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public async Task<List<TResult>> GetAsync(CancellationToken token = default)
    {
        var (sql, options) = BuildSql(); // Не занимаем соединение с сервером

        var readAction = new Func<DbDataReader, List<TResult>>(reader
            => DataReader.Read(reader, options, _readActions, () => _columns.OfType<SelectColumn>().Select(f => f.Name)));

        return await Connection.GetAsync(sql, readAction, options, Timeout, token).ConfigureAwait(false);
    }

    [MethodImpl(Flags.HotPath)]
    internal void AddReadAction<T>(Action<TResult, T> readAction) => ScalarReadBuilder.Add(ref _readActions, readAction);

    [MethodImpl(Flags.HotPath)]
    internal void AddReadAction(Column column, Action<TResult, object> readAction) => ScalarReadBuilder.Add(ref _readActions, column, readAction);
}
