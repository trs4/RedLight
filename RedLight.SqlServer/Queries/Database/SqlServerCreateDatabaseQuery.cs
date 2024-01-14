using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerCreateDatabaseQuery : CreateDatabaseQuery
{
    public SqlServerCreateDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("CREATE DATABASE '").Append(DatabaseName).Append('\'');
}
