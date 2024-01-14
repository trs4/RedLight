using System;
using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerIdentityColumn : IdentityColumn
{
    public SqlServerIdentityColumn(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue)
        : base(name, sequenceName, type, increment, minValue, maxValue) { }

    internal override void BuildSql(StringBuilder builder)
    {
        var dbType = SqlServerColumnTypes.Instance.GetDataType(Type);
        int size = Type == ColumnType.Long ? sizeof(long) : sizeof(int);
        builder.Append("\r\n    ").Append(Name).Append(' ').Append(SqlServerColumnTypes.Instance.GetDataTypeName(dbType));
        SqlServerColumnTypes.Instance.AppendTypeOptions(builder, dbType, size, -1);

        if (String.IsNullOrEmpty(SequenceName))
            builder.Append(" IDENTITY(").Append(MinValue).Append(", ").Append(Increment).Append("),");
        else
            builder.Append(" DEFAULT (NEXT VALUE FOR dbo.").Append(SequenceName).Append("),");
    }

}
