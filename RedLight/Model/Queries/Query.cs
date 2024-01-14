using System;
using System.Text;
using RedLight.Internal;

namespace RedLight;

/// <summary>Построитель запроса</summary>
public abstract class Query
{
    private Query _owner;

    protected Query(DatabaseConnection connection, Query owner = null)
    {
        Connection = connection ?? throw new ArgumentNullException(nameof(connection));
        _owner = owner;
    }

    /// <summary>Соединение с базой данных</summary>
    public DatabaseConnection Connection { get; }

    /// <summary>Владелец</summary>
    public Query Owner
    {
        get => _owner;
        internal set
        {
            if (_owner is not null)
                throw new InvalidOperationException("Owner is alreary set");

            _owner = value;
        }
    }

    /// <summary>Текст</summary>
    public string Sql
    {
        get
        {
            try
            {
                var builder = CacheStringBuilder.Get();
                BuildSql(builder, new QueryOptions(false));
                return CacheStringBuilder.ToString(builder);
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }

    /// <summary>Формирует текст запроса с описанием параметров</summary>
    public (string sql, QueryOptions options) BuildSql()
    {
        var builder = CacheStringBuilder.Get();
        var options = new QueryOptions();
        BuildSql(builder, options);
        return (CacheStringBuilder.ToString(builder), options);
    }

    internal abstract void BuildSql(StringBuilder builder, QueryOptions options);

    public override string ToString() => Sql;
}
