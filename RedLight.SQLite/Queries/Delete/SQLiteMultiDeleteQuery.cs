using System.Text;
using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteMultiDeleteQuery : MultiDeleteQuery
{
    public SQLiteMultiDeleteQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override void BuildPackets(StringBuilder builder, QueryOptions options, int packetSize, int packetCount, int rowCount)
    {
        var onTerm = new TermBlock(this);

        foreach (var column in _columns)
        {
            onTerm.WithRawTerm(Naming.GetRawNameWithAlias(Alias, column.Name), Op.Equal,
                Naming.GetRawNameWithAlias(DataAlias, column.Name));
        }

        builder.Append("DELETE FROM ").Append(TableName)
            .Append("\r\nWHERE ROWID IN (")
            .Append("\r\nSELECT ").Append(Alias).Append(".ROWID FROM ").Append(TableName).Append(' ').Append(Alias)
            .Append("\r\nINNER JOIN\r\n(\r\n");

        base.BuildPackets(builder, options, packetSize, packetCount, rowCount);

        builder.Append("\r\n) ").Append(DataAlias);
        onTerm.BuildSql(builder, options, Consts.On);
        BuildWhereBlock(builder, options);

        builder.Append("\r\n)");
    }

    protected override void BuildBlock(StringBuilder builder, QueryOptions options, int startIndex, int packetSize, string tableName)
    {
        int number = 0;
        builder.Append("SELECT ");
        ColumnBuilder.Build(builder, _columns, f => builder.Append(tableName).Append(".[column").Append(++number).Append("] ").Append(f.Name));
        builder.Append(" FROM (\r\n");
        QueryBuilder.BuildValues(builder, Connection, _columns, startIndex, packetSize);
        builder.Append("\r\n) AS ").Append(tableName);
    }

}
