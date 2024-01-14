using System;
using System.Collections.Generic;
using RedLight.Internal;

namespace RedLight;

/// <summary>Описание базы данных</summary>
public abstract class DatabaseDetails
{
    private Version _version;

    protected DatabaseDetails(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Версия</summary>
    public Version Version => _version ??= LoadVersion();

    /// <summary>Имя схемы</summary>
    public abstract string SchemaName { get; }

    /// <summary>Максимальное количество элементов в блоке IN</summary>
    public abstract int MaxInListItems { get; }

    /// <summary>Максимальное количество строк для одновременного изменения</summary>
    public abstract int MaxRowsPerChanging { get; }

    /// <summary>Необходимо ли добавлять экранирующий символ к оператору LIKE</summary>
    public abstract bool LikeEscaping { get; }

    private Version LoadVersion()
    {
        string serverVersion;

        try
        {
            Connection.Executor.BeginSession();
            serverVersion = Connection.Executor.Connection.ServerVersion;
        }
        finally
        {
            Connection.Executor.EndSession();
        }

        var versions = new List<int>(4);

        if (!String.IsNullOrEmpty(serverVersion))
        {
            var builder = CacheStringBuilder.Get();

            foreach (char s in serverVersion)
            {
                if (Char.IsDigit(s))
                {
                    builder.Append(s);
                    continue;
                }

                if (builder.Length == 0)
                {
                    versions.Add(0);
                    continue;
                }

                versions.Add(Int32.Parse(builder.ToString()));
                builder.Clear();
            }

            if (builder.Length > 0)
                versions.Add(Int32.Parse(builder.ToString()));

            CacheStringBuilder.ToString(builder);
        }

        for (int i = versions.Count; i < 4; i++)
            versions.Add(0);

        return new Version(versions[0], versions[1], versions[2], versions[3]);
    }

}
