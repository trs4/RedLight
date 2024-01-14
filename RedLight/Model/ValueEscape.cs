using System;
using System.Globalization;
using System.Linq;
using RedLight.Internal;

namespace RedLight;

/// <summary>Экранирование значений для составления запроса</summary>
public abstract class ValueEscape
{
    protected const int MaxCachedIntValues = 2048;
    protected static readonly NumberFormatInfo InvariantNumberFormat = NumberFormatInfo.InvariantInfo;
    protected static readonly string[] IntToStringCache = Enumerable.Range(0, MaxCachedIntValues).Select(i => i.ToString(InvariantNumberFormat)).ToArray();

    protected ValueEscape(DatabaseConnection connection)
        => Connection = connection ?? throw new ArgumentNullException(nameof(connection));

    /// <summary>Интерфейс взаимодействия с базой данных</summary>
    public DatabaseConnection Connection { get; }

    public virtual string Escape(bool value)
        => value ? "'1'" : "'0'";

    public virtual string Escape(byte value)
        => IntToStringCache[value];

    public virtual string Escape(short value)
        => value >= 0 ? IntToStringCache[value] : value.ToString(InvariantNumberFormat);

    public virtual string Escape(int value)
        => value >= 0 && value < MaxCachedIntValues ? IntToStringCache[value] : value.ToString(InvariantNumberFormat);

    public virtual string Escape(long value)
        => value >= 0 && value < MaxCachedIntValues ? IntToStringCache[value] : value.ToString(InvariantNumberFormat);

    public virtual string Escape(float value)
        => value.ToString(InvariantNumberFormat);

    public virtual string Escape(double value)
        => value.ToString(InvariantNumberFormat);

    public virtual string Escape(decimal value)
        => value.ToString(InvariantNumberFormat);

    public virtual string Escape(string value)
    {
        if (value is null)
            return Consts.Null;

        if (value.Contains('\''))
            value = value.Replace("'", "''");

        return $"N'{value}'";
    }

    public abstract string Escape(DateTime value);

    public virtual string Escape(TimeSpan value) => value.Ticks.ToString();

    public abstract string Escape(Guid value);

    public abstract string Escape(byte[] value);
}
