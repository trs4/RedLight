using System;

namespace RedLight;

/// <summary>Конструктор поля для изменения данных</summary>
public abstract class MultiValueColumn
{
    protected MultiValueColumn(string name)
        => Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;

    /// <summary>Имя поля</summary>
    public string Name { get; }

    /// <summary>Количество строк</summary>
    public abstract int RowCount { get; }

    internal abstract string GetEscapedString(DatabaseConnection connection, int row);
}
