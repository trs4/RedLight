using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlCreateDatabaseQuery : CreateDatabaseQuery
{
    public PostgreSqlCreateDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("CREATE DATABASE '").Append(DatabaseName).Append("\' WITH ENCODING = \'UTF8\'");
}
