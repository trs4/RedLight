namespace RedLight;

public interface IDatabaseRegister
{
    DatabaseConnectionParameters ParseParameters(string connectionString);

    DatabaseConnection Create(DatabaseConnectionParameters parameters);
}
