namespace RedLight.PostgreSql;

internal sealed class PostgreSqlDatabaseDetails : DatabaseDetails
{
    public PostgreSqlDatabaseDetails(DatabaseConnection connection) : base(connection) { }

    public override string SchemaName => "dbo";

    public override int MaxInListItems => 25_000;

    public override int MaxRowsPerChanging => 1_000;

    public override bool LikeEscaping => true;
}
