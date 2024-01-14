using System;
using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerPrimaryColumn : PrimaryColumn
{
    public SqlServerPrimaryColumn(string keyName, string[] columns) : base(keyName, columns) { }

    internal override void BuildSql(StringBuilder builder)
    {
        builder.Append("\r\n    ");

        if (!String.IsNullOrEmpty(KeyName))
            builder.Append("CONSTRAINT ").Append(KeyName).Append(' ');

        builder.Append("PRIMARY KEY CLUSTERED (").Append(String.Join(", ", Columns)).Append("),");
    }

}
