using System;
using System.Text;

namespace RedLight;

/// <summary>Колонка первичного ключа</summary>
public abstract class PrimaryColumn
{
    protected PrimaryColumn(string keyName, string[] columns)
    {
        KeyName = String.IsNullOrWhiteSpace(keyName) ? throw new ArgumentNullException(nameof(keyName)) : keyName;
        Columns = columns;
    }

    /// <summary>Название первичного ключа</summary>
    public string KeyName { get; }

    /// <summary>Список полей первичного ключа</summary>
    public string[] Columns { get; }

    internal abstract void BuildSql(StringBuilder builder);

    public override string ToString() => KeyName;
}
