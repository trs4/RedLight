namespace RedLight;

/// <summary>Тип базы данных</summary>
public enum DatabaseProvider
{
    /// <summary>Компактная встраиваемая SQLite</summary>
    SQLite,

    /// <summary>Реляционная PostgreSQL</summary>
    PostgreSql,

    /// <summary>Реляционная Microsoft Sql Server</summary>
    SqlServer,
}
