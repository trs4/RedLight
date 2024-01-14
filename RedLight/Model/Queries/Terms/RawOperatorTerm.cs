namespace RedLight;

/// <summary>Условие с оператором со строковыми значениями</summary>
internal sealed class RawOperatorTerm : OperatorTerm
{
    internal RawOperatorTerm(Query owner, string firstOperand, Op termOperator, string secondOperand)
        : base(owner, firstOperand, termOperator)
        => SecondOperand = secondOperand;

    /// <summary>Второй операнд (имя поля или значение)</summary>
    public string SecondOperand { get; }

    protected override string GetSecondOperand(QueryOptions options) => SecondOperand;
}
