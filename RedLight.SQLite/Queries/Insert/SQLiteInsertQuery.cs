using System;
using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteInsertQuery<TResult> : InsertQuery<TResult>
{
    public SQLiteInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        if (_returningColumns.Count > 0)
            throw new NotSupportedException("RETURNING");

        BuildSqlBegin(builder);
        BuildSqlEnd(builder, options);
    }

}
