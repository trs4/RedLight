namespace RedLight;

#pragma warning disable CA1822 // Mark members as static
/// <summary>Системные функции базы данных</summary>
public abstract class DatabaseFunctions
{
    /// <summary>Среднее арифметическое</summary>
    public string Avg(string expression) => $"AVG({expression})";

    /// <summary>Количество</summary>
    public string Count(string expression) => $"COUNT({expression})";

    /// <summary>Максимальное значение</summary>
    public string Max(string expression) => $"MAX({expression})";

    /// <summary>Минимальное значение</summary>
    public string Min(string expression) => $"MIN({expression})";

    /// <summary>Сгенерировать новый уникальный идентификатор</summary>
    public abstract string NewGuid();

    /// <summary>Текущая дата и время</summary>
    public abstract string Now();

    /// <summary>Текущая дата и время UTC</summary>
    public abstract string UtcNow();

    /// <summary>Сумма</summary>
    public string Sum(string expression) => $"SUM({expression})";
}
#pragma warning restore CA1822 // Mark members as static
