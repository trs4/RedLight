using System.Text;

namespace RedLight;

/// <summary>Удаление колонки из таблицы</summary>
public abstract class DeleteColumnQuery : SchemaQuery
{
    protected DeleteColumnQuery(DatabaseConnection connection, string tableName) : base(connection, tableName) { }

    /// <summary>Удаляемая колонка</summary>
    public string Column { get; internal set; }

    #region Internal

    protected void BuildSqlWithoutLastComma(string tableName, StringBuilder builder)
        => builder.Append("ALTER TABLE ").Append(tableName).Append("\r\n    DROP COLUMN ").Append(Column);

    #endregion
}
