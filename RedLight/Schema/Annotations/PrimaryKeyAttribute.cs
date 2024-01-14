using System;

namespace RedLight;

#pragma warning disable CA1813 // Avoid unsealed attributes
#pragma warning disable CA1019 // Define accessors for attribute arguments
/// <summary>Описание поля первичного ключа</summary>
[AttributeUsage(AttributeTargets.Field)]
public class PrimaryKeyAttribute : Attribute
{
    public PrimaryKeyAttribute()
        => Columns = [];

    public PrimaryKeyAttribute(params string[] columns)
        => Columns = columns;

    protected PrimaryKeyAttribute(string name, string[] columns)
    {
        Name = name;
        Columns = columns;
    }

    /// <summary>Имя ограничения</summary>
    public string Name { get; }

    /// <summary>Поля</summary>
    public string[] Columns { get; }

    internal PrimaryKeyAttribute ForTable(Column column)
        => Columns.Length == 0 ? new PrimaryKeyWithNameAttribute(Name, column.Name) : this;

    public override string ToString() => Name;
}

public sealed class PrimaryKeyWithNameAttribute : PrimaryKeyAttribute
{
    public PrimaryKeyWithNameAttribute(string name, params string[] columns) : base(name, columns) { }
}

/// <summary>Описание поля первичного ключа</summary>
public class PrimaryKeyAttribute<TEnum> : PrimaryKeyAttribute
    where TEnum : Enum
{
    public PrimaryKeyAttribute(params TEnum[] columns) : base(GetColumns(columns)) { }

    protected PrimaryKeyAttribute(string name, params TEnum[] columns) : base(name, GetColumns(columns)) { }

    private static string[] GetColumns(TEnum[] columns)
    {
        if (columns.Length == 0)
            return [];

        string[] result = new string[columns.Length];

        for (int i = 0; i < columns.Length; i++)
            result[i] = columns[i].ToString();

        return result;
    }

}

/// <summary>Описание поля первичного ключа</summary>
public sealed class PrimaryKeyWithNameAttribute<TEnum> : PrimaryKeyAttribute<TEnum>
    where TEnum : Enum
{
    public PrimaryKeyWithNameAttribute(string name, params TEnum[] columns) : base(name, columns) { }
}
#pragma warning restore CA1019 // Define accessors for attribute arguments
#pragma warning restore CA1813 // Avoid unsealed attributes