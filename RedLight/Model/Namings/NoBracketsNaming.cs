using System;

namespace RedLight;

/// <summary>Именование таблиц и полей в запросах без экранирования</summary>
internal sealed class NoBracketsNaming : Naming
{
    private NoBracketsNaming() { }

    public static Naming Instance { get; } = new NoBracketsNaming();

    #region Name with schema

    public override string GetNameWithSchema(string name) => name;

    public override string GetNameWithSchema<TEnum>(TEnum name) => name.ToString();

    public override string GetNameWithSchema<TEnum>() => EnumName<TEnum>.Name;

    #endregion
    #region Name

    public override string GetName(string name) => name;

    public override string GetName<TEnum>(TEnum name) => name.ToString();

    public override string GetName<TEnum>() => EnumName<TEnum>.Name;

    private static class EnumName<T> where T : Enum
    {
        public static readonly string Name = typeof(T).Name;
    }

    #endregion
    #region Clear name

    public override string GetClearName(string name) => name;

    #endregion
    #region Internal

    internal override string StrictEscapedTrim(string name) => name.Contains('-') ? name.Replace("-", "_") : name;

    internal override void ClearCache() { }

    #endregion
}
