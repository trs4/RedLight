using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerDeleteColumnQuery : DeleteColumnQuery
{
    public SqlServerDeleteColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
