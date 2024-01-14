using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса управления данными</summary>
public abstract class ValueQuery : WhereQuery
{
    protected readonly List<ValueColumn> _columns = new(8);

    protected ValueQuery(DatabaseConnection connection, string tableName, string alias) : base(connection, tableName, alias) { }

    /// <summary>Список полей с добавляемыми данными</summary>
    public ReadOnlyCollection<ValueColumn> Columns => _columns.AsReadOnly();

    #region Internal

    [MethodImpl(Flags.HotPath)]
    internal void AddColumnCore(ValueColumn column) => _columns.Add(column);

    #endregion
}
