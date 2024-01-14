using System.Threading;
using System.Threading.Tasks;

namespace RedLight;

public static class ExplainQueryFluent
{
    /// <summary>Получает план выполнения запроса</summary>
    /// <param name="liveStatistics">Получить статистику при выполнении запроса</param>
    public static string Explain<TQuery>(this TQuery query, bool liveStatistics = false)
        where TQuery : Query, IRunQuery
    {
        var explainQuery = query.Connection.CreateExplainQuery(query);
        explainQuery.LiveStatistics = liveStatistics;
        return explainQuery.Run();
    }

    /// <summary>Получает план выполнения запроса</summary>
    /// <param name="liveStatistics">Получить статистику при выполнении запроса</param>
    /// <param name="token">Оповещение отмены задачи</param>
    public static Task<string> ExplainAsync<TQuery>(this TQuery query, bool liveStatistics = false, CancellationToken token = default)
        where TQuery : Query, IRunQuery
    {
        var explainQuery = query.Connection.CreateExplainQuery(query);
        explainQuery.LiveStatistics = liveStatistics;
        return explainQuery.RunAsync(token);
    }

}
