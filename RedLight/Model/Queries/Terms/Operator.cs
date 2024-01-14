namespace RedLight;

/// <summary>Оператор блока с условием</summary>
public enum Op
{
    /// <summary>Равно</summary>
    Equal,

    /// <summary>Не равно</summary>
    NotEqual,

    /// <summary>Больше</summary>
    GreaterThan,

    /// <summary>Больше или равно</summary>
    GreaterThanOrEqual,

    /// <summary>Меньше</summary>
    LessThan,

    /// <summary>Меньше или равно</summary>
    LessThanOrEqual,

    /// <summary>Является</summary>
    Is,

    /// <summary>Не является</summary>
    IsNot,

    /// <summary>Содержит</summary>
    Like,
}