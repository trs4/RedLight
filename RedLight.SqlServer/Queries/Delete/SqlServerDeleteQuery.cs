using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerDeleteQuery : DeleteQuery
{
    public SqlServerDeleteQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append("DELETE FROM ").Append(TableName);
        BuildWhereBlock(builder, options);
    }

}
