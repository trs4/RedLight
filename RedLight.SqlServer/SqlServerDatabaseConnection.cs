using RedLight.Internal;

namespace RedLight.SqlServer;

/// <summary>Соединение с базой данных</summary>
public sealed class SqlServerDatabaseConnection : DatabaseConnection
{
    internal SqlServerDatabaseConnection(DatabaseConnectionParameters parameters) : base(parameters) { }

    public override DatabaseProvider Provider => DatabaseProvider.SqlServer;

    public override Naming Naming => DboSquareBracketsNaming.Instance;

    internal override ParameterNaming ParameterNaming => AtParameterNaming.Instance;

    internal override ColumnTypes ColumnTypes => SqlServerColumnTypes.Instance;

    /// <summary>Создаёт подключение для работы с базой данных через строку подключения</summary>
    /// <param name="connectionString">Строка подключения</param>
    public static new DatabaseConnection Create(string connectionString)
        => DatabaseConnectionCreator.From(connectionString, Providers.Init<DatabaseRegister>());

    /// <summary>Создаёт подключение для работы с базой данных через параметры подключения</summary>
    /// <param name="parameters">Параметры подключения</param>
    public static new DatabaseConnection Create(DatabaseConnectionParameters parameters)
        => DatabaseConnectionCreator.From(parameters, Providers.Init<DatabaseRegister>());

    internal override ExplainQuery CreateExplainQuery(Query owner) => new SqlServerExplainQuery(owner);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias) => new SqlServerJoinQuery(owner, tableName, alias);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias, ConstSelectQuery values)
        => new SqlServerJoinQuery(owner, tableName, alias, values);

    internal override Executor CreateExecutor(DatabaseConnectionParameters parameters) => new SqlServerExecutor(parameters);

    protected override DatabaseFunctions CreateFunctions() => new SqlServerDatabaseFunctions();

    protected override DatabaseDetails CreateDetails() => new SqlServerDatabaseDetails(this);

    protected override ValueEscape CreateEscaping() => new SqlServerValueEscape(this);

    protected override DatabaseSchemaQueries CreateSchema() => new SqlServerDatabaseSchemaQueries(this);

    protected override DatabaseSelectQueries CreateSelect() => new SqlServerDatabaseSelectQueries(this);

    protected override DatabaseInsertQueries CreateInsert() => new SqlServerDatabaseInsertQueries(this);

    protected override DatabaseUpdateQueries CreateUpdate() => new SqlServerDatabaseUpdateQueries(this);

    protected override DatabaseDeleteQueries CreateDelete() => new SqlServerDatabaseDeleteQueries(this);
}
