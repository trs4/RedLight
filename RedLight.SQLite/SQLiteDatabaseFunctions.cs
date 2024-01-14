namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseFunctions : DatabaseFunctions
{
    public override string NewGuid() => "UUID()";

    public override string Now() => "DATETIME('now')";

    public override string UtcNow() => "DATETIME('now', 'utc')";
}
