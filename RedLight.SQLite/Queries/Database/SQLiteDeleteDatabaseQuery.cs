using System.IO;
using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteDeleteDatabaseQuery : DeleteDatabaseQuery
{
    public SQLiteDeleteDatabaseQuery(DatabaseConnection connection, string databaseName) : base(connection, databaseName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => File.Delete(Connection.Details.SchemaName);
}