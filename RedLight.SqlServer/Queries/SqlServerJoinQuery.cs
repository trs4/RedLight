﻿using System.Text;
using RedLight.Internal;

namespace RedLight.SqlServer;

internal sealed class SqlServerJoinQuery : JoinQuery
{
    public SqlServerJoinQuery(Query owner, string tableName, string alias) : base(owner, tableName, alias) { }

    public SqlServerJoinQuery(Query owner, string tableName, string alias, ConstSelectQuery values) : base(owner, tableName, alias, values) { }

    internal override void BuildJoinSql(StringBuilder builder, QueryOptions options, TermBlock additionalBlockTerm = null)
    {
        builder.AppendLine().Append(GetTypeString()).Append(TableName);

        if (Alias is not null)
            builder.Append(' ').Append(Alias);

        switch (Type)
        {
            case JoinQueryMode.CrossApply:
            case JoinQueryMode.OuterApply:
                return;
        }

        builder.Append(SqlServerHints.Get(Hints));
        On.BuildSql(builder, options, Consts.On, additionalBlockTerm);
    }

}
