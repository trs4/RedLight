using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса изменения множественных данных</summary>
public abstract class MultiUpdateQuery : MultiValueQuery
{
    /// <summary>Поля для составления условия пересечения</summary>
    protected readonly List<string> _onColumns = new(8);

    /// <summary>Задаёт поля, для которых имя поля в запросе не совпадает с именем поля в таблице данных</summary>
    protected readonly List<UpdateColumn> _replaceColumns = [];

    protected MultiUpdateQuery(DatabaseConnection connection, string tableName)
        : base(connection, tableName, connection.Naming.GetName(Consts.TableAlias))
        => DataAlias = connection.Naming.GetName(Consts.DataTableAlias);

    /// <summary>Псевдоним таблицы данных</summary>
    public string DataAlias { get; }

    #region Internal

    [MethodImpl(Flags.HotPath)]
    internal void AddOnColumnCore(string column) => _onColumns.Add(column);

    [MethodImpl(Flags.HotPath)]
    internal void AddReplaceColumnCore(string column, string dataColumn)
        => _replaceColumns.Add(new UpdateColumn(column, dataColumn));

    protected (Dictionary<string, string> columns, TermBlock onTerm) PrepareColumns(string tableName)
    {
        // Формируем список пар полей между таблицей куда будем записывать и таблицей откуда берём данные
        var columns = _columns.ToDictionary(f => f.Name, f => f.Name);

        if (_onColumns.Count == 0)
            throw new InvalidOperationException("Empty on columns");

        var onTerm = new TermBlock(this);

        foreach (string column in _onColumns)
        {
            onTerm.WithRawTerm(Naming.GetRawNameWithAlias(tableName, column),
                Op.Equal, Naming.GetRawNameWithAlias(DataAlias, column));

            columns.Remove(column);
        }

        if (_replaceColumns.Count > 0)
        {
            foreach (var column in _replaceColumns)
            {
                if (columns.ContainsKey(column.DataColumn)) // Проверяем чтобы не добавить лишние поля
                    columns[column.DataColumn] = column.Column;
            }
        }

        if (columns.Count == 0)
            throw new InvalidOperationException("Empty update columns");

        return (columns, onTerm);
    }

    #endregion
}
