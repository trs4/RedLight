namespace RedLight;

/// <summary>Запрос поддерживает добавление условия проверки существования данных</summary>
public interface ICheckExistenceQuery : IDataQuery
{
    /// <summary>Добавляет условие проверки существования данных</summary>
    JoinQuery AddCheckExistenceJoin(string joinColumn);
}