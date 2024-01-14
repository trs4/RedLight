using System;

namespace RedLight.SQLite;

internal sealed class SQLiteValueEscape : ValueEscape
{
    public SQLiteValueEscape(DatabaseConnection connection) : base(connection) { }

    public override string Escape(string value) => $"'{value}'";

    public override string Escape(DateTime value) => value.Kind == DateTimeKind.Utc
        ? $"datetime('{value.ToLocalTime():yyyy-MM-dd HH:mm:ss.fff tt zzz}')"
        : $"datetime('{value:yyyy-MM-dd HH:mm:ss.fff}')";

    public override string Escape(Guid value) => $"'{value}'";

    public override string Escape(byte[] value) => $"x'{BitConverter.ToString(value).Replace("-", "")}'";
}
