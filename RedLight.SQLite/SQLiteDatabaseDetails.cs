namespace RedLight.SQLite;

internal sealed class SQLiteDatabaseDetails : DatabaseDetails
{
    public SQLiteDatabaseDetails(DatabaseConnection connection) : base(connection) { }

    public override string SchemaName => null;

    public override int MaxInListItems => 25_000;

    public override int MaxRowsPerChanging => 1_000;

    public override bool LikeEscaping => true;
}
