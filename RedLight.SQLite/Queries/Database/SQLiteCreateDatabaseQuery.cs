using System.IO;
using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteCreateDatabaseQuery : CreateDatabaseQuery
{
    public SQLiteCreateDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        using var stream = File.Create(Connection.Details.SchemaName);
        stream.Flush();
    }

}
