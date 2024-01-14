using System;
using System.Text;

namespace RedLight.SqlServer;

internal sealed class SqlServerModifyColumn : ModifyColumn
{
    public SqlServerModifyColumn(SchemaQuery query, string name, ColumnType type, bool nullable,
        int size, int precision, string defaultValue, string defaultConstraint)
        : base(query, name, type, nullable, size, precision, defaultValue, defaultConstraint) { }

    internal override void BuildSql(StringBuilder builder)
    {
        var dbType = SqlServerColumnTypes.Instance.GetDataType(Type);
        builder.Append(Name).Append(' ').Append(SqlServerColumnTypes.Instance.GetDataTypeName(dbType));
        SqlServerColumnTypes.Instance.AppendTypeOptions(builder, dbType, Size, Precision);

        if (!Query.IsTempTable)
            builder.Append(Nullable ? " NULL" : " NOT NULL");

        if (!Nullable && !String.IsNullOrEmpty(DefaultValue))
        {
            if (!Query.IsTempTable)
            {
                if (!String.IsNullOrEmpty(DefaultConstraint))
                    builder.Append(" CONSTRAINT ").Append(DefaultConstraint);
                else
                {
                    builder.Append(" CONSTRAINT ");
                    AppendDefaultConstraintName(builder);
                }
            }

            builder.Append(" DEFAULT ").Append(DefaultValue);
        }

        builder.Append(',');
    }

}
