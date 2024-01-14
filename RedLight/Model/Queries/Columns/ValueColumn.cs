using System;

namespace RedLight;

/// <summary>Конструктор поля для изменения данных</summary>
public abstract class ValueColumn
{
    protected ValueColumn(string name)
        => Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;

    /// <summary>Имя поля</summary>
    public string Name { get; }

    internal abstract string GetEscapedString(DatabaseConnection connection, QueryOptions options);

    public override string ToString() => Name;
}
