using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;

namespace RedLight.Internal;

internal static class DatabaseConnectionCreator
{
    private static readonly HashSet<string> _sqLiteProviders = new(StringComparer.OrdinalIgnoreCase)
    {
        "db",
        "sqlite",
    };

    public static DatabaseConnection From(string connectionString)
    {
        var parameters = Parse(connectionString);
        return From(parameters);
    }

    public static DatabaseConnection From(DatabaseConnectionParameters parameters)
    {
        ArgumentNullException.ThrowIfNull(parameters);
        return Providers.Get(parameters.DatabaseProvider).Create(parameters);
    }

    public static DatabaseConnectionParameters Parse(string connectionString)
    {
        if (String.IsNullOrEmpty(connectionString))
            throw new ArgumentNullException(nameof(connectionString));

        var builder = new DbConnectionStringBuilder() { ConnectionString = connectionString, };
        string provider = GetValue(builder, nameof(DatabaseConnectionParameters.Provider));

        if (provider is null)
            return ParseNonProvider(connectionString, builder);

        DatabaseProvider? databaseProvider = null;

        if (provider.Equals("SQLite", StringComparison.OrdinalIgnoreCase))
            databaseProvider = DatabaseProvider.SQLite;
        else if (provider.Equals("PostgreSql", StringComparison.OrdinalIgnoreCase))
            databaseProvider = DatabaseProvider.PostgreSql;
        else if (provider.Equals("SqlServer", StringComparison.OrdinalIgnoreCase))
            databaseProvider = DatabaseProvider.SqlServer;

        if (databaseProvider.HasValue)
        {
            builder.Remove(nameof(DatabaseConnectionParameters.Provider));
            return Providers.Get(databaseProvider.Value).ParseParameters(builder.ConnectionString);
        }

        throw new InvalidOperationException($"Unknown provider. Connection string:\r\n{connectionString}");
    }

    private static DatabaseConnectionParameters ParseNonProvider(string connectionString, DbConnectionStringBuilder builder)
    {
        string dataSourceLowerString = GetValue(builder, "Data Source")?.ToLower()
            ?? throw new InvalidOperationException("Provider or data source not set");

        string extension = Path.GetExtension(dataSourceLowerString).TrimStart('.');

        if (_sqLiteProviders.Contains(extension))
            return Providers.Get(DatabaseProvider.SQLite).ParseParameters(connectionString);

        throw new InvalidOperationException($"Unknown provider. Connection string:\r\n{builder.ConnectionString}");
    }

    public static string GetValue(DbConnectionStringBuilder builder, string key)
    {
        builder.TryGetValue(key, out object value);
        string stringValue = value as string;
        return String.IsNullOrWhiteSpace(stringValue) ? null : stringValue;
    }

    public static bool TryGetValue(DbConnectionStringBuilder builder, string key, out string stringValue)
    {
        if (!builder.TryGetValue(key, out object value))
        {
            stringValue = null;
            return false;
        }

        stringValue = value as string;

        if (String.IsNullOrWhiteSpace(stringValue))
            stringValue = null;

        return true;
    }

}
