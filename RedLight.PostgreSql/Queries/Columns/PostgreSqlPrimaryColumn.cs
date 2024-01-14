using System;
using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlPrimaryColumn : PrimaryColumn
{
    public PostgreSqlPrimaryColumn(string keyName, string[] columns) : base(keyName, columns) { }

    internal override void BuildSql(StringBuilder builder)
        => builder.Append("\r\n    PRIMARY KEY (").Append(String.Join(", ", Columns)).Append(')');
}
