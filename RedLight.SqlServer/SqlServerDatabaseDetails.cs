namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseDetails : DatabaseDetails
{
    public SqlServerDatabaseDetails(DatabaseConnection connection) : base(connection) { }

    public override string SchemaName => "dbo";

    public override int MaxInListItems => 25_000;

    public override int MaxRowsPerChanging => 1_000;

    public override bool LikeEscaping => false;
}
