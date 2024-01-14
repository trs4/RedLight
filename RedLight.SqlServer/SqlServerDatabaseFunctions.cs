namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseFunctions : DatabaseFunctions
{
    public override string NewGuid() => "NEWID()";

    public override string Now() => "GETDATE()";

    public override string UtcNow() => "GETUTCDATE()";
}
