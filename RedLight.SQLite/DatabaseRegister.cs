using System.Data.SQLite;
using System.IO;

namespace RedLight.SQLite;

public sealed class DatabaseRegister : IDatabaseRegister
{
    public DatabaseConnectionParameters ParseParameters(string connectionString)
    {
        var builder = new SQLiteConnectionStringBuilder(connectionString);
        string fileName = Path.GetFileNameWithoutExtension(builder.DataSource);

        return DatabaseConnectionParameters.Create(DatabaseProvider.SQLite, fileName, builder.DataSource,
            null, builder.Password, builder.ConnectionString, builder.Pooling);
    }

    public DatabaseConnection Create(DatabaseConnectionParameters parameters) => new SQLiteDatabaseConnection(parameters);
}
