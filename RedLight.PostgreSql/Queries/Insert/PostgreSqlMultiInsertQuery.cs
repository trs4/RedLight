using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlMultiInsertQuery<TResult> : MultiInsertQuery<TResult>
{
    public PostgreSqlMultiInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize)
    {
        BuildSqlBegin(builder);
        BuildSqlEnd(builder, options, startIndex, packetSize);
        BuildSqlReturning(builder);
    }

    protected override void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount)
    {
        int startIndex = 0;

        for (int packetIndex = 0; packetIndex < packetCount; packetIndex++)
        {
            BuildBlock(builder, options, startIndex, packetSize);
            builder.Append(";\r\n\r\n");
            startIndex += packetCount;
        }

        BuildBlock(builder, options, startIndex, rowCount - startIndex);
    }

}
