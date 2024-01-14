using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLitePrimaryColumn : PrimaryColumn
{
    public SQLitePrimaryColumn(string keyName, string[] columns) : base(keyName, columns) { }

    internal override void BuildSql(StringBuilder builder)
        => builder.Append("\r\n    PRIMARY KEY (").AppendJoin(", ", Columns).Append(')');
}
