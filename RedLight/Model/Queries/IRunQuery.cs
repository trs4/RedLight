namespace RedLight;

/// <summary>Запрос с выполнением</summary>
public interface IRunQuery
{
    /// <summary>Максимальное время ожидания выполнения запроса</summary>
    int Timeout {  get; }
}
