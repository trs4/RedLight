using RedLight.Internal;

namespace RedLight.PostgreSql;

/// <summary>Соединение с базой данных</summary>
public sealed class PostgreSqlDatabaseConnection : DatabaseConnection
{
    internal PostgreSqlDatabaseConnection(DatabaseConnectionParameters parameters) : base(parameters) { }

    public override DatabaseProvider Provider => DatabaseProvider.PostgreSql;

    public override Naming Naming => DboQuotesBracketsNaming.Instance;

    internal override ParameterNaming ParameterNaming => AtParameterNaming.Instance;

    internal override ColumnTypes ColumnTypes => PostgreSqlColumnTypes.Instance;

    /// <summary>Создаёт подключение для работы с базой данных через строку подключения</summary>
    /// <param name="connectionString">Строка подключения</param>
    public static new DatabaseConnection Create(string connectionString)
        => DatabaseConnectionCreator.From(connectionString, Providers.Init<DatabaseRegister>());

    /// <summary>Создаёт подключение для работы с базой данных через параметры подключения</summary>
    /// <param name="parameters">Параметры подключения</param>
    public static new DatabaseConnection Create(DatabaseConnectionParameters parameters)
        => DatabaseConnectionCreator.From(parameters, Providers.Init<DatabaseRegister>());

    internal override ExplainQuery CreateExplainQuery(Query owner) => new PostgreSqlExplainQuery(owner);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias) => new PostgreSqlJoinQuery(owner, tableName, alias);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias, ConstSelectQuery values)
        => new PostgreSqlJoinQuery(owner, tableName, alias, values);

    internal override Executor CreateExecutor(DatabaseConnectionParameters parameters) => new PostgreSqlExecutor(parameters);

    protected override DatabaseFunctions CreateFunctions() => new PostgreSqlDatabaseFunctions();

    protected override DatabaseDetails CreateDetails() => new PostgreSqlDatabaseDetails(this);

    protected override ValueEscape CreateEscaping() => new PostgreSqlValueEscape(this);

    protected override DatabaseSchemaQueries CreateSchema() => new PostgreSqlDatabaseSchemaQueries(this);

    protected override DatabaseSelectQueries CreateSelect() => new PostgreSqlDatabaseSelectQueries(this);

    protected override DatabaseInsertQueries CreateInsert() => new PostgreSqlDatabaseInsertQueries(this);

    protected override DatabaseUpdateQueries CreateUpdate() => new PostgreSqlDatabaseUpdateQueries(this);

    protected override DatabaseDeleteQueries CreateDelete() => new PostgreSqlDatabaseDeleteQueries(this);
}
