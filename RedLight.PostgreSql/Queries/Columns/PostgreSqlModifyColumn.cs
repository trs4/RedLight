using System.Text;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlModifyColumn : ModifyColumn
{
    public PostgreSqlModifyColumn(SchemaQuery query, string name, ColumnType type, bool nullable,
        int size, int precision, string defaultValue, string defaultConstraint)
        : base(query, name, type, nullable, size, precision, defaultValue, defaultConstraint) { }

    internal override void BuildSql(StringBuilder builder)
    {
        var dbType = PostgreSqlColumnTypes.Instance.GetDataType(Type);
        builder.Append(Name).Append(' ').Append(PostgreSqlColumnTypes.Instance.GetDataTypeName(dbType));
        PostgreSqlColumnTypes.Instance.AppendTypeOptions(builder, dbType, Size, Precision);
    }

}
