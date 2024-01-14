using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDeleteColumnQuery : DeleteColumnQuery
{
    public PostgreSqlDeleteColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
