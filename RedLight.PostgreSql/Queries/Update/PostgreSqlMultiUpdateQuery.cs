using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlMultiUpdateQuery : MultiUpdateQuery
{
    public PostgreSqlMultiUpdateQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildPackets(StringBuilder builder, QueryOptions options, int packetSize, int packetCount, int rowCount)
    {
        var (columns, onTerm) = PrepareColumns(Alias);
        builder.Append("UPDATE ").Append(TableName).Append(' ').Append(Alias).Append("\r\n    SET ");

        ColumnBuilder.Build(builder, columns,
            f => builder.Append(f.Value).Append(" = ").Append(DataAlias).Append('.').Append(f.Key));

        builder.Append("\r\nFROM (\r\n    ");
        base.BuildPackets(builder, options, packetSize, packetCount, rowCount);
        builder.Append("\r\n) ").Append(DataAlias);
        BuildWhereBlock(builder, options);
    }

}
