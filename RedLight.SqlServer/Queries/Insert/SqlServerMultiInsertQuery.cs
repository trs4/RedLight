using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerMultiInsertQuery<TResult> : MultiInsertQuery<TResult>
{
    public SqlServerMultiInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize, string tableName)
    {
        BuildSqlBegin(builder);
        BuildSqlOutput(builder);
        BuildSqlEnd(builder, options, startIndex, packetSize);
    }

    protected override void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount, string tableName)
    {
        int startIndex = 0;

        for (int packetIndex = 0; packetIndex < packetCount; packetIndex++)
        {
            BuildBlock(builder, options, startIndex, packetSize, tableName);
            builder.Append(";\r\n\r\n");
            startIndex += packetCount;
        }

        BuildBlock(builder, options, startIndex, rowCount - startIndex, tableName);
    }

}
