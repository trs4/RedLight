using System;
using System.Linq;

namespace RedLight;

/// <summary>Генератор описания таблицы</summary>
public static class TableGenerator
{
    private static readonly Type _columnAttributeType = typeof(ColumnAttribute);
    private static readonly Type _identityColumnAttributeType = typeof(IdentityColumnAttribute);
    private static readonly Type _primaryKeyAttributeType = typeof(PrimaryKeyAttribute);

    /// <summary>Получает описание таблицы из перечисления</summary>
    /// <typeparam name="T">Перечисление таблицы с полями</typeparam>
    /// <returns>Описание таблицы</returns>
    public static Table From<T>() where T : Enum => EnumTable<T>.Table;

    private static class EnumTable<T> where T : Enum
    {
        public static readonly Table Table;

        static EnumTable()
        {
            var type = typeof(T);
            var table = new Table(type.Name);

            foreach (var field in type.GetFields())
            {
                if (!field.IsStatic)
                    continue;

                var attribute = field.GetCustomAttributes(_columnAttributeType, false).OfType<ColumnAttribute>().FirstOrDefault();
                Column column;

                if (attribute is not null)
                {
                    column = table.AddColumn(attribute.Name ?? field.Name, attribute.Type, attribute.Nullable, attribute.Size, attribute.Precision,
                        attribute.DefaultValue, attribute.DefaultConstraint);
                }
                else
                    column = table.AddColumn(field.Name, ColumnType.String);

                if (table.IdentityColumn is null)
                {
                    var identityColumnAttribute = field.GetCustomAttributes(_identityColumnAttributeType, true).OfType<IdentityColumnAttribute>().FirstOrDefault();

                    if (identityColumnAttribute is not null)
                        table.IdentityColumn = identityColumnAttribute.ForTable(column);
                }

                if (table.PrimaryKey is null)
                {
                    var primaryKeyAttribute = field.GetCustomAttributes(_primaryKeyAttributeType, true).OfType<PrimaryKeyAttribute>().FirstOrDefault();

                    if (primaryKeyAttribute is not null)
                        table.PrimaryKey = primaryKeyAttribute.ForTable(column);
                }
            }

            Table = table;
        }

    }

}
