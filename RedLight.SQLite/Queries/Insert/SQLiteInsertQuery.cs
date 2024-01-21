using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteInsertQuery<TResult> : InsertQuery<TResult>
{
    public SQLiteInsertQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        BuildSqlBegin(builder);
        BuildSqlEnd(builder, options);
        BuildSqlReturning(builder);
    }

}
