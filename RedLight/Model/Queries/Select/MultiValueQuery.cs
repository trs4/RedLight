using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса управления множественными данными</summary>
public abstract class MultiValueQuery : WhereQuery
{
    protected readonly List<MultiValueColumn> _columns = new(8);

    protected MultiValueQuery(DatabaseConnection connection, string tableName, string alias) : base(connection, tableName, alias) { }

    /// <summary>Список полей с добавляемыми данными</summary>
    public ReadOnlyCollection<MultiValueColumn> Columns => _columns.AsReadOnly();

    #region Internal

    [MethodImpl(Flags.HotPath)]
    internal void AddColumnCore(MultiValueColumn column) => _columns.Add(column);

    protected int GetAndCheckRowCountInColumns()
    {
        if (_columns.Count == 0)
            throw new InvalidOperationException("Columns empty");

        int rowCount = _columns[0].RowCount;

        for (int i = 1; i < _columns.Count; i++)
        {
            if (_columns[i].RowCount == rowCount)
                continue;

            throw new InvalidOperationException(String.Format("RowCount {0} in column '{1}' not equal {2} in first column",
                _columns[i].RowCount, _columns[i].Name, rowCount));
        }

        return rowCount;
    }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        int rowCount = GetAndCheckRowCountInColumns();

        if (rowCount > 0)
        {
            int packetSize = Connection.Details.MaxRowsPerChanging;
            int packetCount = Extensions.GetPacketCount(rowCount, packetSize);
            BuildPackets(builder, options, packetSize, packetCount, rowCount);
        }
        else // Данных нет
            OnEmptyRows();
    }

    protected virtual string GetPacketTableName() => TableName;

    protected virtual void BuildPackets(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount)
    {
        string tableName = GetPacketTableName();

        if (packetCount == 1)
            BuildBlock(builder, options, 0, rowCount, tableName);
        else
            BuildPacketBlock(builder, options, packetSize, packetCount - 1, rowCount, tableName);
    }

    protected virtual void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize, string tableName)
    {
        builder.Append("SELECT * FROM (\r\n");
        QueryBuilder.BuildValues(builder, Connection, _columns, startIndex, packetSize);
        builder.Append("\r\n) AS ").Append(tableName).Append(" (");
        ColumnBuilder.Build(builder, _columns, f => f.Name);
        builder.Append(')');
    }

    protected virtual void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount, string tableName)
    {
        builder.Append("SELECT * FROM ( /* count: ").Append(rowCount).Append(" packet size: ").Append(packetSize).Append(" */\r\n");
        int startIndex = 0;

        for (int packetIndex = 0; packetIndex < packetCount; packetIndex++)
        {
            BuildBlock(builder, options, startIndex * packetSize, packetSize, tableName);
            builder.Append("\r\n  UNION ALL\r\n");
            startIndex += packetSize;
        }

        BuildBlock(builder, options, startIndex * packetSize, rowCount - startIndex * packetSize, tableName);
        builder.Append("\r\n) AS ").Append(tableName);
    }

    protected virtual void OnEmptyRows() { }

    #endregion
}
