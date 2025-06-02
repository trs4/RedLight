using Npgsql;
using RedLight.Internal;

namespace RedLight.PostgreSql;

public sealed class DatabaseRegister : IDatabaseRegister
{
    public DatabaseProvider Provider => DatabaseProvider.PostgreSql;

    public DatabaseConnectionParameters ParseParameters(string connectionString)
    {
        var builder = new NpgsqlConnectionStringBuilder(connectionString);

        return DatabaseConnectionParameters.Create(DatabaseProvider.PostgreSql, builder.Database, builder.Host,
            builder.Username, builder.Password, builder.ConnectionString,
            builder.Pooling, builder.MinPoolSize, builder.MaxPoolSize, builder.Port,
            applicationName: builder.ApplicationName,
            autoConvertDatesInUTC: DatabaseConnectionCreator.GetAutoConvertDatesInUTC(builder));
    }

    public DatabaseConnection Create(DatabaseConnectionParameters parameters) => new PostgreSqlDatabaseConnection(parameters);
}
