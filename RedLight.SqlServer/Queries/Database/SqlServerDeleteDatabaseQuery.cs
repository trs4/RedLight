using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerDeleteDatabaseQuery : DeleteDatabaseQuery
{
    public SqlServerDeleteDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("DROP DATABASE '").Append(DatabaseName).Append('\'');
}
