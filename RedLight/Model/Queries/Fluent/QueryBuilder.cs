using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

internal static class QueryBuilder
{
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
