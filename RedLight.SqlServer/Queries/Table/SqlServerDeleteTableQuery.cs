using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerDeleteTableQuery : DeleteTableQuery
{
    public SqlServerDeleteTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("IF OBJECT_ID(N'").Append(TableName).Append("', N'U') IS NOT NULL")
            .Append("\r\nDROP TABLE ").Append(TableName);
}
