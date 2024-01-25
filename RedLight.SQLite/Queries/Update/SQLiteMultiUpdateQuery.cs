using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteMultiUpdateQuery : MultiUpdateQuery
{
    public SQLiteMultiUpdateQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildPackets(StringBuilder builder, QueryOptions options, int packetSize, int packetCount, int rowCount)
    {
        var (columns, onTerm) = PrepareColumns(TableName);
        builder.Append("UPDATE ").Append(TableName).Append("\r\n    SET ");

        ColumnBuilder.Build(builder, columns,
            f => builder.Append(f.Value).Append(" = ").Append(DataAlias).Append('.').Append(f.Key));

        builder.Append("\r\nFROM (\r\n    ");
        base.BuildPackets(builder, options, packetSize, packetCount, rowCount);
        builder.Append("\r\n) AS ").Append(DataAlias);
        BuildWhereBlock(builder, options, onTerm);
    }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize)
        => QueryBuilder.BuildLiteBlock(builder, options, Connection, _columns, DataAlias, startIndex, packetSize);

    protected override void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount)
        => QueryBuilder.BuildPacketBlock(builder, options, Connection, _columns, DataAlias, packetSize, packetCount, rowCount);
}
