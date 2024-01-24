using System.Data.SqlClient;
using RedLight.Internal;

namespace RedLight.SqlServer;

public sealed class DatabaseRegister : IDatabaseRegister
{
    public DatabaseConnectionParameters ParseParameters(string connectionString)
    {
        var builder = new SqlConnectionStringBuilder(connectionString);

        return DatabaseConnectionParameters.Create(DatabaseProvider.SqlServer, builder.InitialCatalog, builder.DataSource,
            builder.UserID, builder.Password, builder.ConnectionString,
            builder.Pooling, builder.MinPoolSize, builder.MaxPoolSize,
            applicationName: builder.ApplicationName,
            autoConvertDatesInUTC: DatabaseConnectionCreator.GetAutoConvertDatesInUTC(builder));
    }

    public DatabaseConnection Create(DatabaseConnectionParameters parameters) => new SqlServerDatabaseConnection(parameters);
}
