namespace RedLight;

/// <summary>Состояние транзакции</summary>
public enum DatabaseTransactionState
{
    /// <summary>Не открыта</summary>
    None,

    /// <summary>Открыта</summary>
    Opened,

    /// <summary>Завершена</summary>
    Commited,

    /// <summary>Отменена</summary>
    Rollbacked,
}
