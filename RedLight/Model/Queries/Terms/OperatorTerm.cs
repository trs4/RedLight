using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text;

namespace RedLight;

/// <summary>Условие с оператором</summary>
public abstract class OperatorTerm : Term
{
    private static readonly FrozenDictionary<Op, string> _operatorToString = new Dictionary<Op, string>()
    {
        { Op.Equal, " = " },
        { Op.NotEqual, " <> " },
        { Op.GreaterThan, " > " },
        { Op.GreaterThanOrEqual, " >= " },
        { Op.LessThan, " < " },
        { Op.LessThanOrEqual, " <= " },
        { Op.Is, " IS " },
        { Op.IsNot, " IS NOT " },
        { Op.Like, " LIKE " },
    }.ToFrozenDictionary();

    protected OperatorTerm(Query owner, string firstOperand, Op termOperator)
        : base(owner)
    {
        FirstOperand = String.IsNullOrWhiteSpace(firstOperand) ? throw new ArgumentNullException(nameof(firstOperand)) : firstOperand;
        Operator = termOperator;
    }

    /// <summary>Первый операнд (имя поля или значение)</summary>
    public string FirstOperand { get; }

    /// <summary>Оператор условия</summary>
    public Op Operator { get; set; }

    #region Internal

    protected abstract string GetSecondOperand(QueryOptions options);

    internal sealed override void BuildSql(StringBuilder builder, QueryOptions options)
    {
        builder.Append('(').Append(FirstOperand)
            .Append(_operatorToString[Operator])
            .Append(GetSecondOperand(options));

        if (Operator == Op.Like && Connection.Details.LikeEscaping)
            builder.Append(" ESCAPE '!'");

        builder.Append(')');
    }

    #endregion
}
