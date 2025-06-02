using RedLight.Internal;

namespace RedLight.SQLite;

/// <summary>Соединение с базой данных</summary>
public sealed class SQLiteDatabaseConnection : DatabaseConnection
{
    internal SQLiteDatabaseConnection(DatabaseConnectionParameters parameters) : base(parameters) { }

    public override DatabaseProvider Provider => DatabaseProvider.SQLite;

    public override Naming Naming => SquareBracketsNaming.Instance;

    internal override ParameterNaming ParameterNaming => AtParameterNaming.Instance;

    internal override ColumnTypes ColumnTypes => SQLiteColumnTypes.Instance;

    /// <summary>Создаёт подключение для работы с базой данных через строку подключения</summary>
    /// <param name="connectionString">Строка подключения</param>
    public static new DatabaseConnection Create(string connectionString)
        => DatabaseConnectionCreator.From(connectionString, Providers.Init<DatabaseRegister>());

    /// <summary>Создаёт подключение для работы с базой данных через параметры подключения</summary>
    /// <param name="parameters">Параметры подключения</param>
    public static new DatabaseConnection Create(DatabaseConnectionParameters parameters)
        => DatabaseConnectionCreator.From(parameters, Providers.Init<DatabaseRegister>());

    internal override ExplainQuery CreateExplainQuery(Query owner) => new SQLiteExplainQuery(owner);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias) => new SQLiteJoinQuery(owner, tableName, alias);

    internal override JoinQuery CreateJoin(Query owner, string tableName, string alias, ConstSelectQuery values)
        => new SQLiteJoinQuery(owner, tableName, alias, values);

    internal override Executor CreateExecutor(DatabaseConnectionParameters parameters) => new SQLiteExecutor(parameters);

    protected override DatabaseFunctions CreateFunctions() => new SQLiteDatabaseFunctions();

    protected override DatabaseDetails CreateDetails() => new SQLiteDatabaseDetails(this);

    protected override ValueEscape CreateEscaping() => new SQLiteValueEscape(this);

    protected override DatabaseSchemaQueries CreateSchema() => new SQLiteDatabaseSchemaQueries(this);

    protected override DatabaseSelectQueries CreateSelect() => new SQLiteDatabaseSelectQueries(this);

    protected override DatabaseInsertQueries CreateInsert() => new SQLiteDatabaseInsertQueries(this);

    protected override DatabaseUpdateQueries CreateUpdate() => new SQLiteDatabaseUpdateQueries(this);

    protected override DatabaseDeleteQueries CreateDelete() => new SQLiteDatabaseDeleteQueries(this);
}
