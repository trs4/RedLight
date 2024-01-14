namespace RedLight;

/// <summary>Колонка в запросе обновления данных</summary>
public sealed class UpdateColumn
{
    internal UpdateColumn(string column, string dataColumn)
    {
        Column = column;
        DataColumn = dataColumn;
    }

    /// <summary>Имя поля в основном запросе</summary>
    public string Column { get; }

    /// <summary>Имя поля в таблице значений</summary>
    public string DataColumn { get; }

    public override string ToString() => $"{Column} - {DataColumn}";
}
