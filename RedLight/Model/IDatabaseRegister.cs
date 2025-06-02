namespace RedLight;

public interface IDatabaseRegister
{
    /// <summary>Тип</summary>
    DatabaseProvider Provider { get; }

    DatabaseConnectionParameters ParseParameters(string connectionString);

    DatabaseConnection Create(DatabaseConnectionParameters parameters);
}
