using System.Collections.Generic;

namespace RedLight;

/// <summary>Опции запроса</summary>
public sealed class QueryOptions
{
    public QueryOptions(bool useParameters = true)
    {
        UseParameters = useParameters;

        if (useParameters)
            Parameters = [];
    }

    /// <summary>Можем ли добавлять значения через параметры</summary>
    public bool UseParameters { get; }

    /// <summary>Параметры запроса</summary>
    public List<QueryParameter> Parameters { get; }

    /// <summary>Установить чтения результата из нескольких запросов</summary>
    internal bool MultipleResult { get; set; }

    public override string ToString() => "Parameters: " + (Parameters?.Count ?? 0);
}
