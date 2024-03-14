using System;

namespace RedLight;

public static class JoinFluent
{
    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm(this JoinQuery query, string ownerColumn, Op termOperator, string joinColumn)
    {
        ownerColumn = query.Connection.Naming.GetName(ownerColumn);
        joinColumn = query.Connection.Naming.GetName(joinColumn);

        if (query.Owner is WhereQuery q && q.Alias is not null)
            ownerColumn = Naming.GetRawNameWithAlias(q.Alias, ownerColumn);

        if (query.Values is not null)
            joinColumn = Naming.GetRawNameWithAlias(query.Values.TableName, joinColumn);
        else if (query.Alias is not null)
            joinColumn = Naming.GetRawNameWithAlias(query.Alias, joinColumn);

        query.On.AddTerm(new RawOperatorTerm(query, ownerColumn, termOperator, joinColumn));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm<TEnum1, TEnum2>(this JoinQuery query, TEnum1 ownerColumn, Op termOperator, TEnum2 joinColumn)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        string ownerColumnName = query.Connection.Naming.GetName(ownerColumn);
        string joinColumnName = query.Connection.Naming.GetName(joinColumn);

        if (query.Owner is WhereQuery q && q.Alias is not null)
            ownerColumnName = Naming.GetRawNameWithAlias(q.Alias, ownerColumnName);

        if (query.Values is not null)
            joinColumnName = Naming.GetRawNameWithAlias(query.Values.TableName, joinColumnName);
        else if (query.Alias is not null)
            joinColumnName = Naming.GetRawNameWithAlias(query.Alias, joinColumnName);

        query.On.AddTerm(new RawOperatorTerm(query, ownerColumnName, termOperator, joinColumnName));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerAlias">Имя псевдонима основной таблицы</param>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinAlias">Имя псевдонима таблицы пересечения</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm(this JoinQuery query, string ownerAlias, string ownerColumn, Op termOperator, string joinAlias, string joinColumn)
    {
        ownerColumn = query.Connection.Naming.GetNameWithAlias(ownerAlias, ownerColumn);
        joinColumn = query.Connection.Naming.GetNameWithAlias(joinAlias, joinColumn);
        query.On.AddTerm(new RawOperatorTerm(query, ownerColumn, termOperator, joinColumn));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerAlias">Имя псевдонима основной таблицы</param>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinAlias">Имя псевдонима таблицы пересечения</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm<TEnum1, TEnum2>(this JoinQuery query, string ownerAlias, TEnum1 ownerColumn, Op termOperator, string joinAlias, TEnum2 joinColumn)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        string ownerColumnName = query.Connection.Naming.GetNameWithAlias(ownerAlias, ownerColumn);
        string joinColumnName = query.Connection.Naming.GetNameWithAlias(joinAlias, joinColumn);
        query.On.AddTerm(new RawOperatorTerm(query, ownerColumnName, termOperator, joinColumnName));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerAlias">Имя псевдонима основной таблицы</param>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm(this JoinQuery query, string ownerAlias, string ownerColumn, Op termOperator, string joinColumn)
    {
        ownerColumn = query.Connection.Naming.GetNameWithAlias(ownerAlias, ownerColumn);
        joinColumn = query.Connection.Naming.GetName(joinColumn);

        if (query.Values is not null)
            joinColumn = Naming.GetRawNameWithAlias(query.Values.TableName, joinColumn);
        else if (query.Alias is not null)
            joinColumn = Naming.GetRawNameWithAlias(query.Alias, joinColumn);

        query.On.AddTerm(new RawOperatorTerm(query, ownerColumn, termOperator, joinColumn));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerAlias">Имя псевдонима основной таблицы</param>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm<TEnum1, TEnum2>(this JoinQuery query, string ownerAlias, TEnum1 ownerColumn, Op termOperator, TEnum2 joinColumn)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        string ownerColumnName = query.Connection.Naming.GetNameWithAlias(ownerAlias, ownerColumn);
        string joinColumnName = query.Connection.Naming.GetName(joinColumn);

        if (query.Values is not null)
            joinColumnName = Naming.GetRawNameWithAlias(query.Values.TableName, joinColumnName);
        else if (query.Alias is not null)
            joinColumnName = Naming.GetRawNameWithAlias(query.Alias, joinColumnName);

        query.On.AddTerm(new RawOperatorTerm(query, ownerColumnName, termOperator, joinColumnName));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinAlias">Имя псевдонима таблицы пересечения</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm(this JoinQuery query, string ownerColumn, Op termOperator, string joinAlias, string joinColumn)
    {
        ownerColumn = query.Connection.Naming.GetName(ownerColumn);
        joinColumn = query.Connection.Naming.GetNameWithAlias(joinAlias, joinColumn);

        if (query.Owner is WhereQuery q && q.Alias is not null)
            ownerColumn = Naming.GetRawNameWithAlias(q.Alias, ownerColumn);

        query.On.AddTerm(new RawOperatorTerm(query, ownerColumn, termOperator, joinColumn));
        return query;
    }

    /// <summary>Добавляет условие по полям</summary>
    /// <param name="ownerColumn">Имя поля основной таблицы</param>
    /// <param name="termOperator">Оператор</param>
    /// <param name="joinAlias">Имя псевдонима таблицы пересечения</param>
    /// <param name="joinColumn">Имя поля таблицы пересечения</param>
    public static JoinQuery WithTerm<TEnum1, TEnum2>(this JoinQuery query, TEnum1 ownerColumn, Op termOperator, string joinAlias, TEnum2 joinColumn)
        where TEnum1 : Enum
        where TEnum2 : Enum
    {
        string ownerColumnName = query.Connection.Naming.GetName(ownerColumn);
        string joinColumnName = query.Connection.Naming.GetNameWithAlias(joinAlias, joinColumn);

        if (query.Owner is WhereQuery q && q.Alias is not null)
            ownerColumnName = Naming.GetRawNameWithAlias(q.Alias, ownerColumnName);

        query.On.AddTerm(new RawOperatorTerm(query, ownerColumnName, termOperator, joinColumnName));
        return query;
    }

}
