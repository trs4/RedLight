using Microsoft.Data.SqlClient;

namespace RedLight.SqlServer;

internal sealed class SqlServerDatabaseTransaction : DatabaseTransaction
{
    public SqlServerDatabaseTransaction(DatabaseConnection connection, string transactionName)
        : base(connection, transactionName) { }

    protected override void CreateSavepoint(string name) => ((SqlTransaction)_transaction).Save(name);

    protected override void RollbackSavepoint() => ((SqlTransaction)_transaction).Rollback(Name);
}
