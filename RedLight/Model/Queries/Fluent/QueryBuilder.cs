using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

internal static class QueryBuilder
{
    [MethodImpl(Flags.HotPath)]
    public static void BuildBlock(StringBuilder builder, QueryOptions options, DatabaseConnection connection, List<MultiValueColumn> columns,
        string tableName, int startIndex, int packetSize)
    {
        builder.Append("SELECT * FROM (\r\n");
        BuildValues(builder, connection, columns, startIndex, packetSize);
        builder.Append("\r\n) AS ").Append(tableName).Append(" (");
        ColumnBuilder.Build(builder, columns, f => f.Name);
        builder.Append(')');
    }

    [MethodImpl(Flags.HotPath)]
    public static void BuildLiteBlock(StringBuilder builder, QueryOptions options, DatabaseConnection connection, List<MultiValueColumn> columns,
        string tableName, int startIndex, int packetSize)
    {
        int number = 0;
        builder.Append("SELECT ");
        ColumnBuilder.Build(builder, columns, f => builder.Append(tableName).Append(".[column").Append(++number).Append("] ").Append(f.Name));
        builder.Append(" FROM (\r\n");
        BuildValues(builder, connection, columns, startIndex, packetSize);
        builder.Append("\r\n) AS ").Append(tableName);
    }

    [MethodImpl(Flags.HotPath)]
    public static void BuildPacketBlock(StringBuilder builder, QueryOptions options, DatabaseConnection connection, List<MultiValueColumn> columns,
        string tableName, int packetSize, int packetCount, int rowCount)
    {
        builder.Append("SELECT * FROM ( /* count: ").Append(rowCount).Append(" packet size: ").Append(packetSize).Append(" */\r\n");
        int startIndex = 0;

        for (int packetIndex = 0; packetIndex < packetCount; packetIndex++)
        {
            BuildBlock(builder, options, connection, columns, tableName, startIndex, packetSize);
            builder.Append("\r\n  UNION ALL\r\n");
            startIndex += packetCount;
        }

        BuildBlock(builder, options, connection, columns, tableName, startIndex, rowCount - startIndex);
        builder.Append("\r\n) AS ").Append(tableName);
    }

    [MethodImpl(Flags.HotPath)]
    public static void BuildValues(StringBuilder builder, DatabaseConnection connection, List<MultiValueColumn> columns,
        int startIndex, int packetSize)
    {
        builder.Append("VALUES");

        if (packetSize >= 10)
            builder.Append(" /* count: ").Append(packetSize).Append(" */");

        builder.Append("\r\n  (");
        ColumnBuilder.Build(builder, columns, f => f.GetEscapedString(connection, startIndex));
        int endCount = startIndex + packetSize;

        for (int i = startIndex + 1; i < endCount; i++)
        {
            builder.Append("),\r\n  (");
            ColumnBuilder.Build(builder, columns, f => f.GetEscapedString(connection, i));
        }

        builder.Append(')');
    }

}
