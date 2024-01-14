using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteExplainQuery : ExplainQuery
{
    public SQLiteExplainQuery(Query owner) : base(owner) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append("EXPLAIN QUERY PLAN ");
        Owner.BuildSql(builder, options);
    }

}
