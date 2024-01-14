using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteUpdateQuery : UpdateQuery
{
    public SQLiteUpdateQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append("UPDATE ").Append(Connection.Naming.GetNameWithSchema(TableName)).Append("\r\n    SET ");

        ColumnBuilder.Build(builder, _columns,
            f => builder.Append(f.Name).Append(" = ").Append(f.GetEscapedString(Connection, options)));

        BuildWhereBlock(builder, options);
    }

}

