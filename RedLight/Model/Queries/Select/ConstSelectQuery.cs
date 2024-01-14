using System;

namespace RedLight;

/// <summary>Построитель запроса ввода данных</summary>
public abstract class ConstSelectQuery : MultiValueQuery, IUnionQuery
{
    protected ConstSelectQuery(DatabaseConnection connection, string tableName) : base(connection, tableName, null) { }

    #region Internal

    protected override void OnEmptyRows()
    {
        base.OnEmptyRows();
        throw new InvalidOperationException("Empty rows");
    }

    #endregion
}
