using System;
using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlInsertQuery<TResult> : InsertQuery<TResult>
{
    public PostgreSqlInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        if (_returningColumns.Count > 0)
            throw new NotSupportedException("RETURNING");

        BuildSqlBegin(builder);
        BuildSqlEnd(builder, options);
    }

}
