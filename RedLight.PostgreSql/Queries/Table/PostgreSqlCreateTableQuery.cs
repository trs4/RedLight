using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlCreateTableQuery : CreateTableQuery
{
    public PostgreSqlCreateTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override IdentityColumn CreateIdentityColumn(string name, string sequenceName, ColumnType type, long increment, long minValue)
        => new PostgreSqlIdentityColumn(name, sequenceName, type, increment, minValue);

    protected override ModifyColumn CreateModifyingColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
        => new PostgreSqlModifyColumn(this, name, type, nullable, size, precision, defaultValue, defaultConstraint);

    protected override PrimaryColumn CreatePrimaryColumn(string keyName, string[] columns) => new PostgreSqlPrimaryColumn(keyName, columns);

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
