using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlInsertQuery<TResult> : InsertQuery<TResult>
{
    public PostgreSqlInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        BuildSqlBegin(builder);
        BuildSqlEnd(builder, options);
        BuildSqlReturning(builder);
    }

}
