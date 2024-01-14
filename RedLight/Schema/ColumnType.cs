namespace RedLight;

/// <summary>Тип колонки</summary>
public enum ColumnType
{
    /// <summary>Неизвестный</summary>
    Unknown,

    /// <summary>Логическое значение</summary>
    Boolean,

    /// <summary>8-разрядное целое число без знака</summary>
    Byte,

    /// <summary>16-разрядное целое число со знаком</summary>
    Short,

    /// <summary>32-разрядное целое число со знаком</summary>
    Integer,

    /// <summary>64-разрядное целое число со знаком</summary>
    Long,

    /// <summary>Число с плавающей запятой одиночной точности</summary>
    Float,

    /// <summary>Число двойной точности с плавающей запятой</summary>
    Double,

    /// <summary>Десятичное число с плавающей запятой</summary>
    Decimal,

    /// <summary>Текст</summary>
    String,

    /// <summary>Глобальный уникальный идентификатор</summary>
    Guid,

    /// <summary>Текущее время, обычно выраженное как дата и время суток</summary>
    DateTime,

    /// <summary>Интервал времени</summary>
    TimeSpan,

    /// <summary>Массив 8-разрядных целых чисел без знака</summary>
    ByteArray,
}
