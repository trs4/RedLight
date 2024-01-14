using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerCreateColumnQuery : CreateColumnQuery
{
    public SqlServerCreateColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override ModifyColumn CreateColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
        => new SqlServerModifyColumn(this, name, type, nullable, size, precision, defaultValue, defaultConstraint);

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
