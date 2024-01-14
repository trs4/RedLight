using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerInsertQuery<TResult> : InsertQuery<TResult>
{
    public SqlServerInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        BuildSqlBegin(builder);

        if (_returningColumns.Count > 0)
        {
            builder.Append("OUTPUT ");
            ColumnBuilder.Build(builder, _returningColumns, f => builder.Append("INSERTED.").Append(f));

            if (OutputTableName != null)
                builder.Append("\r\n  INTO ").Append(OutputTableName);

            builder.AppendLine();
        }

        BuildSqlEnd(builder, options);
    }

}
