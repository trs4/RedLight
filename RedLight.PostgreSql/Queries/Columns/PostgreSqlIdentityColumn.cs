using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlIdentityColumn : IdentityColumn
{
    public PostgreSqlIdentityColumn(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue)
        : base(name, sequenceName, type, increment, minValue, maxValue) { }

    internal override void BuildSql(StringBuilder builder)
    {
        var dbType = PostgreSqlColumnTypes.Instance.GetDataType(Type);
        int size = Type == ColumnType.Long ? sizeof(long) : sizeof(int);
        builder.Append("\r\n    ").Append(Name).Append(' ').Append(PostgreSqlColumnTypes.Instance.GetDataTypeName(dbType));
        PostgreSqlColumnTypes.Instance.AppendTypeOptions(builder, dbType, size, -1);
        builder.Append(')');
    }

}
