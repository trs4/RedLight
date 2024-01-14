using System.Text;

namespace RedLight;

/// <summary>Изменение колонки таблицы</summary>
public abstract class ModifyColumnQuery : SchemaQuery
{
    protected ModifyColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    /// <summary>Изменяемое поле</summary>
    public ModifyColumn Column { get; private set; }

    #region Internal

    internal void SetColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
        => Column = CreateColumn(name, type, nullable, size, precision, defaultValue, defaultConstraint);

    protected abstract ModifyColumn CreateColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint);

    protected void BuildSqlWithoutLastComma(string tableName, StringBuilder builder)
    {
        builder.Append("ALTER TABLE ").Append(tableName).Append("\r\n    ALTER COLUMN ");
        Column.BuildSql(builder);
    }

    #endregion
}
