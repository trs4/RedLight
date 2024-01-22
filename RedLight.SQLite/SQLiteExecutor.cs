using System.Data.Common;
using System.Data.SQLite;
using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteExecutor : Executor
{
    public SQLiteExecutor(DatabaseConnectionParameters parameters) : base(parameters) { }

    protected override string BuildConnectionString()
    {
        var builder = new SQLiteConnectionStringBuilder();
        Prepare(builder);
        builder.DataSource = Parameters.ServerName;
        builder.Pooling = Parameters.UsePooling;
        return builder.ToString();
    }

    protected override DbConnection CreateConnection() => new SQLiteConnection(ConnectionString);

    protected override DbParameter CreateParameter(QueryParameter parameter)
    {
        var dataType = SQLiteColumnTypes.Instance.GetDataType(parameter.Type);
        int maxSize = parameter.MaxSize > 0 ? parameter.MaxSize : SQLiteColumnTypes.Instance.GetMaxSize(dataType);

        return new SQLiteParameter(parameter.Name, dataType, maxSize)
        {
            Value = SQLiteColumnTypes.Instance.GetValue(parameter),
            IsNullable = parameter.Nullable,
        };
    }

}
