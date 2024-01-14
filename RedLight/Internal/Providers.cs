using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;

namespace RedLight.Internal;

internal static class Providers
{
    private static readonly ConcurrentDictionary<DatabaseProvider, IDatabaseRegister> _providers = new();
    private static readonly Type _databaseRegisterType = typeof(IDatabaseRegister);

    public static IDatabaseRegister Get(DatabaseProvider provider) => _providers.GetOrAdd(provider, Load);

    private static IDatabaseRegister Load(DatabaseProvider provider)
    {
        string name = provider switch
        {
            DatabaseProvider.SQLite => "RedLight.SQLite.dll",
            DatabaseProvider.PostgreSql => "RedLight.PostgreSql.dll",
            DatabaseProvider.SqlServer => "RedLight.SqlServer.dll",
            _ => throw new NotSupportedException(provider.ToString())
        };

        var assembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(
            a => !a.IsDynamic && !String.IsNullOrEmpty(a.Location) && String.Compare(new FileInfo(a.Location).Name, name, true) == 0);

        if (assembly is null)
        {
            string location = typeof(Providers).Assembly.Location;
            string assemblyFile = Path.Combine(Path.GetDirectoryName(location), name);
            assembly = Assembly.LoadFrom(assemblyFile);
        }

        if (assembly is null)
            throw new InvalidOperationException($"Assembly '{name}' not found");

        var databaseRegisterType = assembly.ExportedTypes.FirstOrDefault(t => t.GetInterfaces().Any(it => it == _databaseRegisterType))
            ?? throw new InvalidOperationException($"Register type in assembly '{name}' not found");

        return (IDatabaseRegister)Activator.CreateInstance(databaseRegisterType)
            ?? throw new InvalidOperationException($"Register object in assembly '{name}' not found");
    }

}
