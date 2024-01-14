using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteDeleteColumnQuery : DeleteColumnQuery
{
    public SQLiteDeleteColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
