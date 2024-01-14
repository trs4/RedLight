namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseFunctions : DatabaseFunctions
{
    public override string NewGuid() => "gen_random_uuid()";

    public override string Now() => "now()";

    public override string UtcNow() => "timezone('UTC', now())";
}
