using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Создание таблицы</summary>
public abstract class CreateTableQuery : SchemaQuery
{
    protected IdentityColumn _identityColumn;
    protected readonly List<ModifyColumn> _columns = new(8);
    protected PrimaryColumn _primaryColumn;

    protected CreateTableQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    /// <summary>Создаваемые поля</summary>
    public ReadOnlyCollection<ModifyColumn> Columns => _columns.AsReadOnly();

    #region Internal

    internal void SetIdentityColumnCore(string name, string sequenceName, ColumnType type, long increment, long minValue)
        => _identityColumn = CreateIdentityColumn(name, sequenceName, type, increment, minValue);

    protected abstract IdentityColumn CreateIdentityColumn(string name, string sequenceName, ColumnType type, long increment, long minValue);

    internal void AddColumnCore(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
    {
        var column = CreateModifyingColumn(name, type, nullable, size, precision, defaultValue, defaultConstraint);
        _columns.Add(column);
    }

    protected abstract ModifyColumn CreateModifyingColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint);

    internal void SetPrimaryColumnCore(string keyName, string[] columns)
        => _primaryColumn = columns.IsNullOrEmpty() ? null : CreatePrimaryColumn(keyName, columns);

    protected abstract PrimaryColumn CreatePrimaryColumn(string keyName, string[] columns);

    protected void BuildSqlWithoutLastComma(string tableName, StringBuilder builder)
    {
        var columns = _columns;
        bool hasColumns = false;

        builder.Append("CREATE TABLE ").Append(tableName)
            .Append("\r\n(");

        if (_identityColumn is not null)
        {
            _identityColumn.BuildSql(builder);
            hasColumns = true;

            int index = columns.FindIndex(c => c.Name.Equals(_identityColumn.Name, StringComparison.OrdinalIgnoreCase));

            if (index >= 0)
            {
                columns = new(columns);
                columns.RemoveAt(index);
            }
        }

        if (columns.Count > 0)
        {
            if (hasColumns)
                builder.Append(',');
            else
                hasColumns = true;

            builder.Append("\r\n    ");
            columns[0].BuildSql(builder);

            for (int i = 1; i < columns.Count; i++)
            {
                builder.Append(",\r\n    ");
                columns[i].BuildSql(builder);
            }
        }

        if (_primaryColumn is not null)
        {
            if (hasColumns)
                builder.Append(',');

            _primaryColumn.BuildSql(builder);
        }

        builder.Append("\r\n)");
    }

    #endregion
}
