using System;
using System.Text;

namespace RedLight;

/// <summary>Условие с диапазоном</summary>
public abstract class BetweenTerm : Term
{
    protected BetweenTerm(Query owner, string column)
        : base(owner)
        => Column = String.IsNullOrWhiteSpace(column) ? throw new ArgumentNullException(nameof(column)) : column;

    /// <summary>Имя колонки</summary>
    public string Column { get; }

    /// <summary>Отрицание диапазона</summary>
    public bool Not { get; set; }

    #region Internal

    protected abstract string GetBeginValue(QueryOptions options);

    protected abstract string GetEndValue(QueryOptions options);

    internal override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append('(').Append(Column).Append(' ');

        if (Not)
            builder.Append("NOT ");

        builder.Append("BETWEEN ").Append(GetBeginValue(options)).Append(" AND ").Append(GetEndValue(options)).Append(')');
    }

    #endregion
}
