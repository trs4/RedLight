namespace RedLight.Internal;

/// <summary>Значения, связанные с базой данных</summary>
internal static class Consts
{
    /// <summary>Пустое значение</summary>
    public const string Null = "NULL";

    /// <summary>Максимальное количество символов в строке запроса</summary>
    public const int MaxQuerySize = 268435456;

    /// <summary>Максимальное число параметров в запросе</summary>
    public const int MaxQueryParameters = 2090;

    public const int PoolSize = 100;
    public const string Encoding = "UTF8";

    public const int DecimalScale = 10;
    public const string TableAlias = "t";
    public const string DataTableAlias = "d";
    public const string Where = "\r\nWHERE";
    public const string On = "\r\n    ON";
}
