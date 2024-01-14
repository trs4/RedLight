using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteIdentityColumn : IdentityColumn
{
    public SQLiteIdentityColumn(string name, string sequenceName, ColumnType type, long increment, long minValue)
        : base(name, sequenceName, type, increment, minValue) { }

    internal override void BuildSql(StringBuilder builder)
    {
        var dbType = SQLiteColumnTypes.Instance.GetDataType(Type);
        int size = Type == ColumnType.Long ? sizeof(long) : sizeof(int);
        builder.Append("\r\n    ").Append(Name).Append(' ').Append(SQLiteColumnTypes.Instance.GetDataTypeName(dbType));
        SQLiteColumnTypes.Instance.AppendTypeOptions(builder, dbType, size, -1);
    }

}
