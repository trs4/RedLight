using System;
using System.Collections.Generic;

namespace RedLight;

/// <summary>Описание схемы данных</summary>
public sealed class Database
{
    private readonly Dictionary<string, Table> _tables = new(StringComparer.OrdinalIgnoreCase);

    /// <summary>Создаёт описание базы данных</summary>
    /// <param name="name">Имя базы данных</param>
    /// <param name="filePath">Путь до файла</param>
    /// <param name="fileExtension">Расширение файла</param>
    public Database(string name, string filePath = null, string fileExtension = null)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        Name = name;

        if (fileExtension is not null)
            FilePath = filePath;

        FileExtension = fileExtension;
    }

    /// <summary>Наименование</summary>
    public string Name { get; }

    /// <summary>Путь до файла</summary>
    public string FilePath { get; }

    /// <summary>Расширение файла</summary>
    public string FileExtension { get; }

    /// <summary>Возможность изменить структуру таблицы</summary>
    public bool IsReadOnly { get; set; }

    /// <summary>Список таблиц</summary>
    public IReadOnlyCollection<Table> Tables => _tables.Values;

    /// <summary>Ищет описание таблицы по наименованию</summary>
    /// <param name="tableName">Наименование</param>
    public Table FindTable(string tableName)
        => !String.IsNullOrEmpty(tableName) && _tables.TryGetValue(tableName, out var table) ? table : null;

    /// <summary>Проверяет наличие описание таблицы по наименованию</summary>
    /// <param name="tableName">Наименование</param>
    public bool ContainsTable(string tableName)
        => !String.IsNullOrEmpty(tableName) && _tables.ContainsKey(tableName);

    /// <summary>Добавляет описание таблицы</summary>
    /// <param name="name">Имя таблицы</param>
    /// <returns>Описание таьлицы</returns>
    public Table AddTable(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (IsReadOnly)
            throw new InvalidOperationException(nameof(IsReadOnly));

        if (_tables.ContainsKey(name))
            throw new InvalidOperationException(name);

        var table = new Table(name);
        AddTableCore(table);
        return table;
    }

    /// <summary>Добавляет описание таблицы</summary>
    /// <param name="name">Имя таблицы</param>
    /// <returns>Описание таьлицы</returns>
    public Table GetOrAddTable(string name)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (IsReadOnly)
            throw new InvalidOperationException(nameof(IsReadOnly));

        if (_tables.TryGetValue(name, out var existingTable))
            return existingTable;

        var table = new Table(name);
        AddTableCore(table);
        return table;
    }

    /// <summary>Добавляет описание таблицы</summary>
    /// <param name="table">Описание таблицы</param>
    public void AddTable(Table table)
    {
        ArgumentNullException.ThrowIfNull(table);

        if (IsReadOnly)
            throw new InvalidOperationException(nameof(IsReadOnly));

        if (_tables.ContainsKey(table.Name))
            throw new InvalidOperationException(table.Name);

        if (table.Database is not null)
            throw new InvalidOperationException($"Table '{table.Name}' already exists in database");

        AddTableCore(table);
    }

    /// <summary>Добавляет описание таблицы</summary>
    /// <param name="table">Описание таблицы</param>
    public Table GetOrAddTable(Table table)
    {
        ArgumentNullException.ThrowIfNull(table);

        if (IsReadOnly)
            throw new InvalidOperationException(nameof(IsReadOnly));

        if (_tables.TryGetValue(table.Name, out var existingTable))
            return existingTable;

        if (table.Database is not null)
            throw new InvalidOperationException($"Table '{table.Name}' already exists in database");

        AddTableCore(table);
        return table;
    }

    internal void AddTableInternal(Table table)
    {
        if (_tables.ContainsKey(table.Name))
            throw new InvalidOperationException($"Table '{table.Name}' already exists in database");

        AddTableCore(table);
    }

    private void AddTableCore(Table table)
    {
        _tables.Add(table.Name, table);
        table.Database = this;
    }

    public override string ToString() => Name;
}
