using System.IO;
using Microsoft.Data.Sqlite;
using RedLight.Internal;

namespace RedLight.SQLite;

public sealed class DatabaseRegister : IDatabaseRegister
{
    public DatabaseConnectionParameters ParseParameters(string connectionString)
    {
        var builder = new SqliteConnectionStringBuilder(connectionString);
        string fileName = Path.GetFileNameWithoutExtension(builder.DataSource);

        return DatabaseConnectionParameters.Create(DatabaseProvider.SQLite, fileName, builder.DataSource,
            null, builder.Password, builder.ConnectionString, builder.Pooling,
            applicationName: DatabaseConnectionCreator.GetApplicationName(builder),
            autoConvertDatesInUTC: DatabaseConnectionCreator.GetAutoConvertDatesInUTC(builder));
    }

    public DatabaseConnection Create(DatabaseConnectionParameters parameters) => new SQLiteDatabaseConnection(parameters);
}
