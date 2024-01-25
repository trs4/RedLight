using System;

namespace RedLight;

/// <summary>Расширения для типа колонки</summary>
public static class ColumnTypeExtensions
{
    /// <summary>Получить тип колонки</summary>
    /// <param name="type">Тип колонки</param>
    public static Type GetLanguageType(this ColumnType type) => type switch
    {
        ColumnType.Boolean => typeof(bool),
        ColumnType.Byte => typeof(byte),
        ColumnType.Short => typeof(short),
        ColumnType.Integer => typeof(int),
        ColumnType.Long => typeof(long),
        ColumnType.Float => typeof(float),
        ColumnType.Double => typeof(double),
        ColumnType.Decimal => typeof(decimal),
        ColumnType.String => typeof(string),
        ColumnType.Guid => typeof(Guid),
        ColumnType.DateTime => typeof(DateTime),
        ColumnType.TimeSpan => typeof(TimeSpan),
        ColumnType.ByteArray => typeof(byte[]),
        _ => typeof(object),
    };
}
