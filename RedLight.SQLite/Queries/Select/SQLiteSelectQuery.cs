using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteSelectQuery<TResult> : SelectQuery<TResult>
{
    public SQLiteSelectQuery(DatabaseConnection connection, string tableName, string alias)
        : base(connection, tableName, alias) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        BuildFromBlock(builder, options, false);
        BuildJoinsBlock(builder, options);
        BuildWhereBlock(builder, options);
        BuildGroupByBlock(builder);

        if (_orderColumns.Count > 0 && Mode == SelectQueryMode.Default)
            BuildOrderByBlock(builder);

        if (Top > 0)
        {
            builder.Append("\r\n  LIMIT ").Append(Top);

            if (Offset > 0)
                builder.Append(" OFFSET ").Append(Offset);
        }
    }

}
