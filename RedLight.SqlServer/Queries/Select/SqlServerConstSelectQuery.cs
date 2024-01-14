using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerConstSelectQuery : ConstSelectQuery
{
    public SqlServerConstSelectQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize)
        => QueryBuilder.BuildBlock(builder, options, Connection, _columns, TableName, startIndex, packetSize);

    protected override void BuildPacketBlock(StringBuilder builder, QueryOptions options,
        int packetSize, int packetCount, int rowCount)
        => QueryBuilder.BuildPacketBlock(builder, options, Connection, _columns, TableName, packetSize, packetCount, rowCount);
}
