using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDeleteTableQuery : DeleteTableQuery
{
    public PostgreSqlDeleteTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("DROP TABLE IF EXISTS ").Append(TableName);
}
