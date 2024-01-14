using System.Threading;
using System.Threading.Tasks;
using IcyRain.Tables;

namespace RedLight;

/// <summary>Построитель плана запроса</summary>
public abstract class ExplainQuery : Query
{
    protected ExplainQuery(Query owner) : base(owner?.Connection, owner) { }

    /// <summary>Получить статистику при выполнении запроса</summary>
    public bool LiveStatistics { get; set; }

    /// <summary>Получает план выполнения запроса</summary>
    /// <returns>Текст плана выполнения запроса</returns>
    public string Run()
    {
        int timeout = ((IRunQuery)Owner).Timeout;
        using var session = DatabaseConnectionSession.Open(Connection, "EXPLAIN_TRAN");
        return GetPlanAsync(timeout, CancellationToken.None).Result;
    }

    /// <summary>Получает план выполнения запроса</summary>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Текст плана выполнения запроса</returns>
    public async Task<string> RunAsync(CancellationToken token = default)
    {
        int timeout = ((IRunQuery)Owner).Timeout;
        using var session = DatabaseConnectionSession.Open(Connection, "EXPLAIN_TRAN");
        return await GetPlanAsync(timeout, token).ConfigureAwait(false);
    }

    protected virtual string GetPlan(int timeout)
    {
        string sql = Sql;

        if (sql.Length == 0)
            return null;

        var options = new QueryOptions(false)
        {
            MultipleResult = true,
        };

        var dataSet = Connection.Get<DataTable>(sql, options, timeout);
        return dataSet.GetView();
    }

    protected async virtual Task<string> GetPlanAsync(int timeout, CancellationToken token)
    {
        string sql = Sql;

        if (sql.Length == 0)
            return null;

        var options = new QueryOptions(false)
        {
            MultipleResult = true,
        };

        var dataSet = await Connection.GetAsync<DataTable>(sql, options, timeout, token).ConfigureAwait(false);
        return dataSet.GetView();
    }

    protected virtual string GetQueryPlanExtension() => ".queryplan";
}
