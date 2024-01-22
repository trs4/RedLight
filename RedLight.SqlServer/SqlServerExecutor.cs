using System;
using System.Data.Common;
using System.Data.SqlClient;
using RedLight.Internal;

namespace RedLight.SqlServer;

internal sealed class SqlServerExecutor : Executor
{
    public SqlServerExecutor(DatabaseConnectionParameters parameters) : base(parameters) { }

    protected override string BuildConnectionString()
    {
        var builder = new SqlConnectionStringBuilder();
        Prepare(builder);
        builder.DataSource = Parameters.ServerName;
        builder.Pooling = Parameters.UsePooling;
        builder.MinPoolSize = Parameters.MinPoolSize <= 0 ? Consts.PoolSize : Parameters.MinPoolSize;
        builder.MaxPoolSize = Parameters.MaxPoolSize <= 0 ? Consts.PoolSize : Parameters.MaxPoolSize;
        builder.LoadBalanceTimeout = 5 * 60; // Минут
        builder.ConnectRetryCount = 3;
        builder.ApplicationName = Parameters.ApplicationName;

        if (!String.IsNullOrEmpty(Parameters.DatabaseName))
            builder.InitialCatalog = Parameters.DatabaseName;

        if (String.IsNullOrEmpty(Parameters.UserName))
            builder.IntegratedSecurity = true;
        else
        {
            builder.IntegratedSecurity = false;
            builder.UserID = Parameters.UserName;
            builder.Password = Parameters.Password ?? String.Empty;
        }

        return builder.ToString();
    }

    protected override DbConnection CreateConnection() => new SqlConnection(ConnectionString);

    protected override DbParameter CreateParameter(QueryParameter parameter)
    {
        var dataType = SqlServerColumnTypes.Instance.GetDataType(parameter.Type);
        int maxSize = parameter.MaxSize > 0 ? parameter.MaxSize : SqlServerColumnTypes.Instance.GetMaxSize(dataType);

        return new SqlParameter(parameter.Name, dataType, maxSize)
        {
            Value = SqlServerColumnTypes.Instance.GetValue(parameter),
            IsNullable = parameter.Nullable,
        };
    }

}
