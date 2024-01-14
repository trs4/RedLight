using System;
using System.IO;
using RedLight.Internal;

namespace RedLight;

/// <summary>Параметры подключения к базе данных</summary>
public sealed class DatabaseConnectionParameters
{
    private string _serverName;
    private string _applicationName;

    private DatabaseConnectionParameters(DatabaseProvider databaseProvider,
        string databaseName, string serverName,
        string userName, string password, string connectionString,
        bool usePooling, int minPoolSize, int maxPoolSize, int port)
    {
        DatabaseProvider = databaseProvider;
        DatabaseName = databaseName;
        ServerName = serverName;
        UserName = userName;
        Password = password;
        ConnectionString = connectionString;
        UsePooling = usePooling;
        MinPoolSize = minPoolSize;
        MaxPoolSize = maxPoolSize;
        Port = port;
    }

    public static DatabaseConnectionParameters Create(DatabaseProvider databaseProvider,
        string databaseName, string serverName = null,
        string userName = null, string password = null, string connectionString = null,
        bool usePooling = false, int minPoolSize = 0, int maxPoolSize = 0, int port = 0)
        => new DatabaseConnectionParameters(databaseProvider, databaseName, serverName,
            userName, password, connectionString,
            usePooling, minPoolSize, maxPoolSize, port);

    public static DatabaseConnectionParameters Parse(string connectionString)
        => DatabaseConnectionCreator.Parse(connectionString);

    /// <summary>Строка подключения</summary>
    public string ConnectionString { get; set; }

    /// <summary>Тип базы данных</summary>
    public DatabaseProvider DatabaseProvider { get; }

    /// <summary>Драйвер для доступа к базе данных</summary>
    public string Provider { get; set; }

    /// <summary>Имя базы данных</summary>
    public string DatabaseName { get; set; }

    /// <summary>Имя сервера</summary>
    public string ServerName
    {
        get => _serverName;
        set
        {
            _serverName = value;

            if (value is not null && value.IndexOf('.') > 1)
                FileExtension = Path.GetExtension(value).TrimStart('.').ToLower();
        }
    }

    /// <summary>Порт сервера</summary>
    public int Port { get; set; }

    /// <summary>Имя пользователя</summary>
    public string UserName { get; set; }

    /// <summary>Пароль</summary>
    public string Password { get; set; }

    /// <summary>Название приложения, из которого подключаемся к базе данных</summary>
    public string ApplicationName
    {
        get => _applicationName ?? "RedLight";
        set => _applicationName = String.IsNullOrEmpty(value) ? null : value;
    }

    /// <summary>Использовать пул соединений с сервером</summary>
    public bool UsePooling { get; set; }

    /// <summary>Минимальное количество подключений в пуле</summary>
    public int MinPoolSize { get; set; }

    /// <summary>Максимальное количество подключений в пуле</summary>
    public int MaxPoolSize { get; set; }

    /// <summary>Расширение файла</summary>
    public string FileExtension { get; private set; }

    public override string ToString() => DatabaseName;
}
