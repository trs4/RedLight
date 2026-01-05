using System;
using System.Collections.Generic;
using IcyRain.Tables;
using RedLight.Internal;

namespace RedLight;

/// <summary>Описание таблицы</summary>
public sealed class Table
{
    private readonly Dictionary<string, Column> _columns = new(8, StringComparer.OrdinalIgnoreCase);

    public Table(string name)
        => Name = String.IsNullOrWhiteSpace(name) ? throw new ArgumentNullException(nameof(name)) : name;

    /// <summary>Наименование</summary>
    public string Name { get; }

    /// <summary>Список полей</summary>
    public IReadOnlyCollection<Column> Columns => _columns.Values;

    /// <summary>Описание схемы данных</summary>
    public Database Database { get; internal set; }

    internal Column IdentityColumn { get; set; } // %%TODO Отдельный тип сделать

    internal IdentityColumnAttribute Identity { get; set; } // %%TODO Отдельный тип сделать

    internal Column PrimaryKeyColumn { get; set; } // %%TODO Отдельный тип сделать

    internal PrimaryKeyAttribute PrimaryKey { get; set; } // %%TODO Отдельный тип сделать

    internal string[] GetPrimaryKeyNames()
        => TryGetPrimaryKeyNames(out string[] primaryKeyNames) ? primaryKeyNames : throw new InvalidOperationException(nameof(PrimaryKey));

    internal IReadOnlyList<string> GetPrimaryKeyNames<TResult>(TResult row)
    {
        if (TryGetPrimaryKeyNames(out string[] primaryKeyNames))
            return primaryKeyNames;

        if (row is DataTable dataTable)
        {
            var columns = new List<string>();

            foreach (string dataColumn in dataTable.Keys)
            {
                if (_columns.TryGetValue(dataColumn, out var column))
                    columns.Add(column.Name);
            }

            if (columns.Count > 0)
                return columns;
        }

        throw new InvalidOperationException(nameof(PrimaryKey));
    }

    private bool TryGetPrimaryKeyNames(out string[] primaryKeyNames)
    {
        if (PrimaryKey is not null && PrimaryKey.Columns.Length > 0)
        {
            primaryKeyNames = PrimaryKey.Columns;
            return true;
        }

        if (Identity is not null)
        {
            primaryKeyNames = [Identity.Name];
            return true;
        }

        primaryKeyNames = null;
        return false;
    }

    /// <summary>Ищет описание поля по наименованию</summary>
    /// <param name="columnName">Наименование</param>
    public Column FindColumn(string columnName)
        => !String.IsNullOrEmpty(columnName) && _columns.TryGetValue(columnName.TrimWhitespaces(), out var column) ? column : null;

    /// <summary>Проверяет наличие описание поля по наименованию</summary>
    /// <param name="columnName">Наименование</param>
    public bool ContainsColumn(string columnName)
        => !String.IsNullOrEmpty(columnName) && _columns.ContainsKey(columnName.TrimWhitespaces());

    /// <summary>Добавляет описание поля</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="type">Тип поля</param>
    /// <param name="nullable">Типу значения можно задать пустое значение</param>
    /// <param name="size">Размер поля</param>
    /// <param name="precision">Точность</param>
    /// <param name="defaultValue">Значение по-умолчанию</param>
    /// <param name="defaultConstraint">Имя ограничения по-умолчанию</param>
    /// <returns>Описание поля</returns>
    public Column AddColumn(string name, ColumnType type, bool nullable = false, int size = 0, int precision = 0,
        string defaultValue = null, string defaultConstraint = null)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (Database is not null && Database.IsReadOnly)
            throw new InvalidOperationException(nameof(Database.IsReadOnly));

        if (_columns.ContainsKey(name.TrimWhitespaces()))
            throw new InvalidOperationException(name);

        var column = new Column(name, type, nullable, size, precision, defaultValue, defaultConstraint);
        AddColumnCore(column);
        return column;
    }

    /// <summary>Добавляет описание поля, если в таблице его нет по наименованию</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="type">Тип поля</param>
    /// <param name="nullable">Типу значения можно задать пустое значение</param>
    /// <param name="size">Размер поля</param>
    /// <param name="precision">Точность</param>
    /// <param name="defaultValue">Значение по-умолчанию</param>
    /// <param name="defaultConstraint">Имя ограничения по-умолчанию</param>
    /// <returns>Описание поля</returns>
    public Column GetOrAddColumn(string name, ColumnType type, bool nullable = false, int size = 0, int precision = 0,
        string defaultValue = null, string defaultConstraint = null)
    {
        if (String.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name));

        if (Database is not null && Database.IsReadOnly)
            throw new InvalidOperationException(nameof(Database.IsReadOnly));

        if (_columns.TryGetValue(name.TrimWhitespaces(), out var existingColumn))
            return existingColumn;

        var column = new Column(name, type, nullable, size, precision, defaultValue, defaultConstraint);
        AddColumnCore(column);
        return column;
    }

    /// <summary>Добавляет описание поля</summary>
    /// <param name="column">Описание поля</param>
    public void AddColumn(Column column)
    {
        ArgumentNullException.ThrowIfNull(column);

        if (Database is not null && Database.IsReadOnly)
            throw new InvalidOperationException(nameof(Database.IsReadOnly));

        if (_columns.ContainsKey(column.Name.TrimWhitespaces()))
            throw new InvalidOperationException(column.Name);

        if (column.Table is not null)
            throw new InvalidOperationException($"Column '{column.Name}' already exists in table '{Name}'");

        AddColumnCore(column);
    }

    /// <summary>Добавляет описание поля, если в таблице его нет по наименованию</summary>
    /// <param name="column">Описание поля</param>
    public Column GetOrAddColumn(Column column)
    {
        ArgumentNullException.ThrowIfNull(column);

        if (Database is not null && Database.IsReadOnly)
            throw new InvalidOperationException(nameof(Database.IsReadOnly));

        if (_columns.TryGetValue(column.Name.TrimWhitespaces(), out var existingColumn))
            return existingColumn;

        if (column.Table != null)
            throw new InvalidOperationException($"Column '{column.Name}' already exists in table '{Name}'");

        AddColumnCore(column);
        return column;
    }

    internal void AddColumnInternal(Column column)
    {
        if (_columns.ContainsKey(column.Name.TrimWhitespaces()))
            throw new InvalidOperationException($"Column '{column.Name}' already exists in table '{Name}'");

        AddColumnCore(column);
    }

    private void AddColumnCore(Column column)
    {
        _columns.Add(column.Name.TrimWhitespaces(), column);
        column.Table = this;
    }

    public override string ToString() => Name;
}
