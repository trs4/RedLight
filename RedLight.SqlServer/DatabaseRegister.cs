using System.Data.SqlClient;

namespace RedLight.SqlServer;

public sealed class DatabaseRegister : IDatabaseRegister
{
    public DatabaseConnectionParameters ParseParameters(string connectionString)
    {
        var builder = new SqlConnectionStringBuilder(connectionString);

        return DatabaseConnectionParameters.Create(DatabaseProvider.SqlServer, builder.InitialCatalog, builder.DataSource,
            builder.UserID, builder.Password, builder.ConnectionString,
            builder.Pooling, builder.MinPoolSize, builder.MaxPoolSize);
    }

    public DatabaseConnection Create(DatabaseConnectionParameters parameters) => new SqlServerDatabaseConnection(parameters);
}
