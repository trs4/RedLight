using System;
using System.Data.Common;
using Npgsql;
using RedLight.Internal;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlExecutor : Executor
{
    public PostgreSqlExecutor(DatabaseConnectionParameters parameters) : base(parameters) { }

    protected override string BuildConnectionString()
    {
        var builder = new NpgsqlConnectionStringBuilder();
        Prepare(builder);
        builder.ApplicationName = Parameters.ApplicationName;
        builder.Database = Parameters.DatabaseName;
        builder.Host = Parameters.ServerName;
        builder.Port = Parameters.Port;

        if (!String.IsNullOrEmpty(Parameters.UserName))
        {
            builder.Username = Parameters.UserName;
            builder.Password = Parameters.Password ?? String.Empty;
        }

        builder.Pooling = Parameters.UsePooling;
        builder.MinPoolSize = Parameters.MinPoolSize <= 0 ? Consts.PoolSize : Parameters.MinPoolSize;
        builder.MaxPoolSize = Parameters.MaxPoolSize <= 0 ? Consts.PoolSize : Parameters.MaxPoolSize;
        builder.Encoding = Consts.Encoding;
        builder.ClientEncoding = Consts.Encoding;
        builder.ConnectionLifetime = 0;
        return builder.ToString();
    }

    protected override DbConnection CreateConnection() => new NpgsqlConnection(ConnectionString);

    protected override DbParameter CreateParameter(QueryParameter parameter)
    {
        var dataType = PostgreSqlColumnTypes.Instance.GetDataType(parameter.Type);
        int maxSize = parameter.MaxSize > 0 ? parameter.MaxSize : PostgreSqlColumnTypes.Instance.GetMaxSize(dataType);

        return new NpgsqlParameter(parameter.Name, dataType, maxSize)
        {
            Value = PostgreSqlColumnTypes.Instance.GetValue(parameter),
            IsNullable = parameter.Nullable,
        };
    }

}
