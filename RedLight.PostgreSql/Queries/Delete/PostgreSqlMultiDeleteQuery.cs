using System.Text;
using RedLight.Internal;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlMultiDeleteQuery : MultiDeleteQuery
{
    public PostgreSqlMultiDeleteQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildPackets(StringBuilder builder, QueryOptions options, int packetSize, int packetCount, int rowCount)
    {
        var onTerm = new TermBlock(this);

        foreach (var column in _columns)
        {
            onTerm.WithRawTerm(Naming.GetRawNameWithAlias(Alias, column.Name), Op.Equal,
                Naming.GetRawNameWithAlias(DataAlias, column.Name));
        }

        builder.Append("WITH ").Append(DataAlias).Append(" AS (\r\n");
        base.BuildPackets(builder, options, packetSize, packetCount, rowCount);
        builder.Append("\r\n)\r\nDELETE FROM ").Append(TableName).Append(' ').Append(Alias).Append("\r\nUSING ").Append(DataAlias);
        onTerm.BuildSql(builder, options, Consts.Where);
        BuildWhereBlock(builder, options);
    }

}
