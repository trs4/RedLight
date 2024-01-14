using System.Text;

namespace RedLight;

/// <summary>Добавление колонки в таблицу</summary>
public abstract class CreateColumnQuery : SchemaQuery
{
    protected CreateColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    /// <summary>Добавляемое поле</summary>
    public ModifyColumn Column { get; private set; }

    #region Internal

    internal void SetColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint)
        => Column = CreateColumn(name, type, nullable, size, precision, defaultValue, defaultConstraint);

    protected abstract ModifyColumn CreateColumn(string name, ColumnType type, bool nullable, int size, int precision,
        string defaultValue, string defaultConstraint);

    protected void BuildSqlWithoutLastComma(string tableName, StringBuilder builder)
    {
        builder.Append("ALTER TABLE ").Append(tableName).Append("\r\n    ADD COLUMN ");
        Column.BuildSql(builder);
    }

    #endregion
}
