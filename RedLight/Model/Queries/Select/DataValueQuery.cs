﻿using System;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса управления данными</summary>
public abstract class DataValueQuery : ValueQuery, ICheckExistenceQuery
{
    /// <summary>Условия проверки существования данных</summary>
    protected JoinQuery _checkExistenceJoin;
    protected TermBlock _checkExistenceTerm;

    protected DataValueQuery(DatabaseConnection connection, string tableName)
        : base(connection, tableName, connection.Naming.GetName(Consts.TableAlias))
        => DataAlias = connection.Naming.GetName(Consts.DataTableAlias);

    /// <summary>Псевдоним таблицы данных</summary>
    public string DataAlias { get; }

    /// <summary>Добавляет условие, проверяющее факт существования данных</summary>
    /// <param name="joinColumn">Поле для отсечения данных по условию</param>
    JoinQuery ICheckExistenceQuery.AddCheckExistenceJoin(string joinColumn)
    {
        if (String.IsNullOrEmpty(joinColumn))
            throw new ArgumentNullException(nameof(joinColumn));

        if (_checkExistenceJoin is not null)
            return _checkExistenceJoin;

        _checkExistenceTerm = CreateCheckExistenceTerm(joinColumn);
        _checkExistenceJoin = CreateCheckExistenceJoin();
        return _checkExistenceJoin;
    }

}
