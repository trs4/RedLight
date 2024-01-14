using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteDeleteTableQuery : DeleteTableQuery
{
    public SQLiteDeleteTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
        => builder.Append("DROP TABLE IF EXISTS ").Append(TableName);
}
