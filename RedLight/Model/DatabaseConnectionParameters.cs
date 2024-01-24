using System;
using System.IO;
using RedLight.Internal;

namespace RedLight;

/// <summary>Параметры подключения к базе данных</summary>
public sealed class DatabaseConnectionParameters
{
    private DatabaseConnectionParameters(DatabaseProvider databaseProvider,
        string databaseName, string serverName,
        string userName, string password, string connectionString,
        bool usePooling, int minPoolSize, int maxPoolSize, int port,
        string applicationName, bool autoConvertDatesInUTC)
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
        ApplicationName = (String.IsNullOrEmpty(applicationName) ? null : applicationName) ?? "RedLight";
        AutoConvertDatesInUTC = autoConvertDatesInUTC;

        if (serverName is not null && serverName.IndexOf('.') > 1)
            FileExtension = Path.GetExtension(serverName).TrimStart('.').ToLower();
    }

    public static DatabaseConnectionParameters Create(DatabaseProvider databaseProvider,
        string databaseName, string serverName = null,
        string userName = null, string password = null, string connectionString = null,
        bool usePooling = false, int minPoolSize = 0, int maxPoolSize = 0, int port = 0,
        string applicationName = null, bool autoConvertDatesInUTC = true)
        => new DatabaseConnectionParameters(databaseProvider, databaseName, serverName,
            userName, password, connectionString, usePooling, minPoolSize, maxPoolSize, port, applicationName, autoConvertDatesInUTC);

    public static DatabaseConnectionParameters Parse(string connectionString)
        => DatabaseConnectionCreator.Parse(connectionString);

    /// <summary>Строка подключения</summary>
    public string ConnectionString { get; }

    /// <summary>Тип базы данных</summary>
    public DatabaseProvider DatabaseProvider { get; }

    /// <summary>Драйвер для доступа к базе данных</summary>
    public string Provider { get; }

    /// <summary>Имя базы данных</summary>
    public string DatabaseName { get; }

    /// <summary>Имя сервера</summary>
    public string ServerName { get; }

    /// <summary>Порт сервера</summary>
    public int Port { get; }

    /// <summary>Имя пользователя</summary>
    public string UserName { get; }

    /// <summary>Пароль</summary>
    public string Password { get; }

    /// <summary>Название приложения, из которого подключаемся к базе данных</summary>
    public string ApplicationName { get; }

    /// <summary>Использовать пул соединений с сервером</summary>
    public bool UsePooling { get; }

    /// <summary>Минимальное количество подключений в пуле</summary>
    public int MinPoolSize { get; }

    /// <summary>Максимальное количество подключений в пуле</summary>
    public int MaxPoolSize { get; }

    /// <summary>Расширение файла</summary>
    public string FileExtension { get; }

    /// <summary>Запись в базу дат в UTC и чтение из базы в локальное время</summary>
    public bool AutoConvertDatesInUTC { get; }

    public override string ToString() => DatabaseName;
}
