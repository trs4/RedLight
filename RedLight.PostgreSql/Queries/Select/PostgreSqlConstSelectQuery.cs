using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlConstSelectQuery : ConstSelectQuery
{
    public PostgreSqlConstSelectQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize)
        => QueryBuilder.BuildBlock(builder, options, Connection, _columns, TableName, startIndex, packetSize);

    protected override void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount)
        => QueryBuilder.BuildPacketBlock(builder, options, Connection, _columns, TableName, packetSize, packetCount, rowCount);
}
