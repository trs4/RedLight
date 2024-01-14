using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteCreateTableQuery : CreateTableQuery
{
    public SQLiteCreateTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    protected override IdentityColumn CreateIdentityColumn(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue)
        => new SQLiteIdentityColumn(name, sequenceName, type, increment, minValue, maxValue);

    protected override ModifyColumn CreateModifyingColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
        => new SQLiteModifyColumn(this, name, type, nullable, size, precision, defaultValue, defaultConstraint);

    protected override PrimaryColumn CreatePrimaryColumn(string keyName, string[] columns) => new SQLitePrimaryColumn(keyName, columns);

    internal override void BuildSql(StringBuilder builder, QueryOptions options) => BuildSqlWithoutLastComma(TableName, builder);
}
