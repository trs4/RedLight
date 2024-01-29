using System;
using RedLight.Internal;

namespace RedLight.SQLite;

internal sealed class SQLiteValueEscape : ValueEscape
{
    public SQLiteValueEscape(DatabaseConnection connection) : base(connection) { }

    public override string Escape(string value)
    {
        if (value is null)
            return Consts.Null;

        if (value.Contains('\''))
            value = value.Replace("'", "''");

        return $"'{value}'";
    }

    public override string Escape(DateTime value)
    {
        if (Connection.Parameters.AutoConvertDatesInUTC && value.Kind == DateTimeKind.Local)
            value = value.ToUniversalTime();

        return $"datetime('{value:yyyy-MM-dd HH:mm:ss.fff}')";
    }

    public override string Escape(Guid value) => $"'{value}'";

    public override string Escape(byte[] value) => $"x'{BitConverter.ToString(value).Replace("-", "")}'";
}
