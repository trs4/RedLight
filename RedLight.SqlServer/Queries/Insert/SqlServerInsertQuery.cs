using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerInsertQuery<TResult> : InsertQuery<TResult>
{
    public SqlServerInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        BuildSqlBegin(builder);
        BuildSqlOutput(builder);
        BuildSqlEnd(builder, options);
    }

}
