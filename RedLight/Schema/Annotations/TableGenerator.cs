using System;
using System.Linq;

namespace RedLight;

/// <summary>Генератор описания таблицы</summary>
public static class TableGenerator
{
    private static readonly Type _columnAttributeType = typeof(ColumnAttribute);

    /// <summary>Получает описание таблицы из перечисления</summary>
    /// <typeparam name="T">Перечисление таблицы с полями</typeparam>
    /// <returns>Описание таблицы</returns>
    public static Table From<T>()
        where T : Enum
    {
        var type = typeof(T);
        var table = new Table(type.Name);

        foreach (var field in type.GetFields())
        {
            if (!field.IsStatic)
                continue;

            var attribute = field.GetCustomAttributes(_columnAttributeType, false).OfType<ColumnAttribute>().FirstOrDefault();

            if (attribute is not null)
            {
                table.AddColumn(attribute.Name ?? field.Name, attribute.Type, attribute.Nullable, attribute.Size, attribute.Precision,
                    attribute.DefaultValue, attribute.DefaultConstraint);
            }
            else
                table.AddColumn(field.Name, ColumnType.String);
        }

        return table;
    }

}
