using System;
using System.Collections.Generic;
using System.Text;

namespace RedLight;

/// <summary>Условие по списку значений</summary>
public abstract class InTerm : Term
{
    protected InTerm(Query owner, string column)
        : base(owner)
        => Column = String.IsNullOrWhiteSpace(column) ? throw new ArgumentNullException(nameof(column)) : column;

    /// <summary>Имя колонки</summary>
    public string Column { get; }

    /// <summary>Указывает на то, что перед IN надо поставить NOT (NOT IN (...))</summary>
    public bool Not { get; set; }

    #region Internal

    protected abstract string[] GetStringValues();

    internal sealed override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        string[] values = GetStringValues();

        if (values.Length == 0)
        {
            builder.Append("(1 = 1)");
            return;
        }

        builder.Append('(').Append(Column);

        if (Not)
            builder.Append(" NOT");

        builder.Append(" IN (");

        if (values.Length >= 10)
            builder.Append("/* count: ").Append(values.Length).Append(" */ ");

        builder.Append(values[0]);

        for (int i = 1; i < values.Length; i++)
            builder.Append(", ").Append(values[i]);

        builder.Append("))");
    }

    #endregion
}

/// <summary>Условие по списку значений</summary>
public abstract class InTerm<TValue> : InTerm
{
    protected InTerm(Query owner, string column, IReadOnlyList<TValue> values)
        : base(owner, column)
        => Values = values ?? throw new ArgumentNullException(nameof(values));

    /// <summary>Список значений</summary>
    public IReadOnlyList<TValue> Values { get; }

    #region Internal

    protected abstract string EscapeValue(TValue value);

    protected sealed override string[] GetStringValues()
    {
        string[] values = new string[Values.Count];

        for (int i = 0; i < Values.Count; i++)
            values[i] = EscapeValue(Values[i]);

        return values;
    }

    #endregion
}
