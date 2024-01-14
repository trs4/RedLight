using System.Text;
using RedLight.Internal;

namespace RedLight.SqlServer;

internal sealed class SqlServerMultiUpdateQuery : MultiUpdateQuery
{
    public SqlServerMultiUpdateQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildPackets(StringBuilder builder, QueryOptions options, int packetSize, int packetCount, int rowCount)
    {
        var (columns, onTerm) = PrepareColumns();
        builder.Append("UPDATE ").Append(Alias).Append("\r\n    SET ");

        ColumnBuilder.Build(builder, columns,
            f => builder.Append(f.Value).Append(" = ").Append(DataAlias).Append('.').Append(f.Key));

        builder.Append("\r\nFROM ").Append(Connection.Naming.GetNameWithSchema(TableName)).Append(' ').Append(Alias)
            .Append(" INNER JOIN\r\n(\r\n");

        base.BuildPackets(builder, options, packetSize, packetCount, rowCount);
        builder.Append("\r\n) ").Append(DataAlias);
        onTerm.BuildSql(builder, options, Consts.On);
        BuildWhereBlock(builder, options);
    }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize)
        => QueryBuilder.BuildBlock(builder, options, Connection, _columns, DataAlias, startIndex, packetSize);

    protected override void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount)
        => QueryBuilder.BuildPacketBlock(builder, options, Connection, _columns, DataAlias, packetSize, packetCount, rowCount);
}
