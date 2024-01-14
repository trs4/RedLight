using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerSelectQuery<TResult> : SelectQuery<TResult>
{
    public SqlServerSelectQuery(DatabaseConnection connection, string tableName, string alias)
        : base(connection, tableName, alias) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        BuildFromBlock(builder, options);

        if (FromSelect is null)
            builder.Append(SqlServerHints.Get(Hints));

        BuildJoinsBlock(builder, options);
        BuildWhereBlock(builder, options);
        BuildGroupByBlock(builder);

        if (_orderColumns.Count > 0 && Mode == SelectQueryMode.Default)
        {
            BuildOrderByBlock(builder);

            if (Offset > 0)
            {
                builder.Append("\r\n  OFFSET ").Append(Offset).Append(" ROWS");

                if (Top > 0)
                    builder.Append(" FETCH NEXT ").Append(Top).Append(" ROWS ONLY");
            }
        }
    }

}
