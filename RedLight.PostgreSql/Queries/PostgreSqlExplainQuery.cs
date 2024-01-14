using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlExplainQuery : ExplainQuery
{
    public PostgreSqlExplainQuery(Query owner) : base(owner) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append("EXPLAIN ");
        Owner.BuildSql(builder, options);
    }

}
