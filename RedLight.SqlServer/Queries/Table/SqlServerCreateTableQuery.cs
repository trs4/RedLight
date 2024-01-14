using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerCreateTableQuery : CreateTableQuery
{
    public SqlServerCreateTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override IdentityColumn CreateIdentityColumn(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue)
        => new SqlServerIdentityColumn(name, sequenceName, type, increment, minValue, maxValue);

    protected override ModifyColumn CreateModifyingColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
        => new SqlServerModifyColumn(this, name, type, nullable, size, precision, defaultValue, defaultConstraint);

    protected override PrimaryColumn CreatePrimaryColumn(string keyName, string[] columns) => new SqlServerPrimaryColumn(keyName, columns);

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
