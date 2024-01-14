using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDeleteQuery : DeleteQuery
{
    public PostgreSqlDeleteQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append("DELETE FROM ").Append(TableName);
        BuildWhereBlock(builder, options);
    }

}
