using System.Text;
using RedLight.Internal;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlJoinQuery : JoinQuery
{
    public PostgreSqlJoinQuery(Query owner, string tableName, string alias) : base(owner, tableName, alias) { }

    internal override void BuildJoinSql(StringBuilder builder, QueryOptions options, TermBlock additionalBlockTerm = null)
    {
        builder.AppendLine().Append(GetTypeString()).Append(TableName);

        if (Alias is not null)
            builder.Append(' ').Append(Alias);

        switch (Type)
        {
            case JoinQueryMode.CrossApply:
            case JoinQueryMode.OuterApply:
                return;
        }

        On.BuildSql(builder, options, Consts.On, additionalBlockTerm);
    }

}