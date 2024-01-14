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

    internal void SetIdentityColumnCore(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue)
        => _identityColumn = CreateIdentityColumn(name, sequenceName, type, increment, minValue, maxValue);

    protected abstract IdentityColumn CreateIdentityColumn(string name, string sequenceName, ColumnType type,
        long increment, long minValue, long maxValue);

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
        bool hasColumns = false;

        builder.Append("CREATE TABLE ").Append(tableName)
            .Append("\r\n(");

        if (_identityColumn is not null)
        {
            _identityColumn.BuildSql(builder);
            hasColumns = true;
        }

        if (_columns.Count > 0)
        {
            if (hasColumns)
                builder.Append(',');
            else
                hasColumns = true;

            builder.Append("\r\n    ");
            _columns[0].BuildSql(builder);

            for (int i = 1; i < _columns.Count; i++)
            {
                builder.Append(",\r\n    ");
                _columns[i].BuildSql(builder);
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
