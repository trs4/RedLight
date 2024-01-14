using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDeleteDatabaseQuery : DeleteDatabaseQuery
{
    public PostgreSqlDeleteDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("DROP DATABASE IF EXISTS '").Append(DatabaseName).Append('\'');
}
