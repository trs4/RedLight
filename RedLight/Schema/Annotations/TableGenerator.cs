using System;
using System.Linq;

namespace RedLight;

/// <summary>Генератор описания таблицы</summary>
public static class TableGenerator
{
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

                var attributes = field.GetCustomAttributes(false);
                var attribute = attributes.OfType<ColumnAttribute>().FirstOrDefault();
                IdentityColumnAttribute identityAttribute = null;
                Column column;

                if (attribute is not null)
                {
                    column = table.AddColumn(attribute.Name ?? field.Name, attribute.Type, attribute.Nullable, attribute.Size, attribute.Precision,
                        attribute.DefaultValue, attribute.DefaultConstraint);
                }
                else
                {
                    identityAttribute = attributes.OfType<IdentityColumnAttribute>().FirstOrDefault();

                    if (identityAttribute is not null)
                        column = table.AddColumn(identityAttribute.Name ?? field.Name, identityAttribute.Type);
                    else
                        column = table.AddColumn(field.Name, ColumnType.String);
                }

                if (table.Identity is null)
                {
                    identityAttribute ??= attributes.OfType<IdentityColumnAttribute>().FirstOrDefault();

                    if (identityAttribute is not null)
                    {
                        table.IdentityColumn = column;
                        table.Identity = identityAttribute.ForTable(column);
                    }
                }

                if (table.PrimaryKey is null)
                {
                    var primaryKeyAttribute = attributes.OfType<PrimaryKeyAttribute>().FirstOrDefault();

                    if (primaryKeyAttribute is not null)
                    {
                        table.PrimaryKeyColumn = column;
                        table.PrimaryKey = primaryKeyAttribute.ForTable(column);
                    }
                }
            }

            Table = table;
        }

    }

}
