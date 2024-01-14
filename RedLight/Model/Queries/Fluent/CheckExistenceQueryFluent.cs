using System;

namespace RedLight;

public static class CheckExistenceQueryFluent
{
    /// <summary>Добавляет условие, проверяющее факт существования данных</summary>
    /// <param name="joinColumns">Поле для отсечения данных по условию</param>
    public static TQuery CheckExistence<TQuery>(this TQuery query, params string[] joinColumns)
        where TQuery : ICheckExistenceQuery
    {
        if (joinColumns.Length == 0)
            throw new ArgumentNullException(nameof(joinColumns));

        string firstColumn = query.Connection.Naming.GetName(joinColumns[0]);
        var join = query.AddCheckExistenceJoin(firstColumn);

        join.On.WithRawTerm(Naming.GetRawNameWithAlias(query.Alias, firstColumn),
            Op.Equal, Naming.GetRawNameWithAlias(query.DataAlias, firstColumn));

        for (int i = 1; i < joinColumns.Length; i++)
        {
            string column = query.Connection.Naming.GetName(joinColumns[i]);

            join.On.WithRawTerm(Naming.GetRawNameWithAlias(query.Alias, column),
                Op.Equal, Naming.GetRawNameWithAlias(query.DataAlias, column));
        }

        return query;
    }

    /// <summary>Добавляет условие, проверяющее факт существования данных</summary>
    /// <param name="joinColumns">Поле для отсечения данных по условию</param>
    public static TQuery CheckExistence<TQuery, TEnum>(this TQuery query, params TEnum[] joinColumns)
        where TQuery : ICheckExistenceQuery
        where TEnum : Enum
    {
        if (joinColumns.Length == 0)
            throw new ArgumentNullException(nameof(joinColumns));

        string firstColumn = query.Connection.Naming.GetName(joinColumns[0]);
        var join = query.AddCheckExistenceJoin(firstColumn);

        join.On.WithRawTerm(Naming.GetRawNameWithAlias(query.Alias, firstColumn),
            Op.Equal, Naming.GetRawNameWithAlias(query.DataAlias, firstColumn));

        for (int i = 1; i < joinColumns.Length; i++)
        {
            string column = query.Connection.Naming.GetName(joinColumns[i]);

            join.On.WithRawTerm(Naming.GetRawNameWithAlias(query.Alias, column),
                Op.Equal, Naming.GetRawNameWithAlias(query.DataAlias, column));
        }

        return query;
    }

}
