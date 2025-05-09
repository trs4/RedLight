using System.Data.Common;
using Microsoft.Data.Sqlite;
using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteExecutor : Executor
{
    public SQLiteExecutor(DatabaseConnectionParameters parameters) : base(parameters) { }

    protected override string BuildConnectionString()
    {
        var builder = new SqliteConnectionStringBuilder();
        Prepare(builder);
        builder.DataSource = Parameters.ServerName;
        builder.Pooling = Parameters.UsePooling;
        return builder.ToString();
    }

    protected override DbConnection CreateConnection() => new SqliteConnection(ConnectionString);

    protected override DbParameter CreateParameter(QueryParameter parameter)
    {
        var dataType = SQLiteColumnTypes.Instance.GetDataType(parameter.Type);
        int maxSize = parameter.MaxSize > 0 ? parameter.MaxSize : SQLiteColumnTypes.Instance.GetMaxSize(dataType);

        return new SqliteParameter(parameter.Name, dataType, maxSize)
        {
            Value = parameter.Value,
            IsNullable = parameter.Nullable,
        };
    }

}
