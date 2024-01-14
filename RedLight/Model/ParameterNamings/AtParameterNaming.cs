namespace RedLight;

/// <summary>Наименование параметров запроса, начинающихся с @p</summary>
internal static class AtParameterNaming
{
    public static ParameterNaming Instance { get; } = new("@p");
}
