using System.Text;

namespace RedLight.SQLite;

internal sealed class SQLiteModifyColumn : ModifyColumn
{
    public SQLiteModifyColumn(SchemaQuery query, string name, ColumnType type, bool nullable,
        int size, int precision, string defaultValue, string defaultConstraint)
        : base(query, name, type, nullable, size, precision, defaultValue, defaultConstraint) { }

    internal override void BuildSql(StringBuilder builder)
    {
        var dbType = SQLiteColumnTypes.Instance.GetDataType(Type);
        builder.Append(Name).Append(' ').Append(SQLiteColumnTypes.Instance.GetDataTypeName(dbType));
        SQLiteColumnTypes.Instance.AppendTypeOptions(builder, dbType, Size, Precision);

        if (!Nullable)
            builder.Append(" NOT NULL");
    }

}
