using System;
using RedLight.Internal;

namespace RedLight.SqlServer;

internal sealed class SqlServerValueEscape : ValueEscape
{
    public SqlServerValueEscape(DatabaseConnection connection) : base(connection) { }

    public override string Escape(DateTime value) => value.Kind == DateTimeKind.Utc
        ? $"CONVERT(datetime2, '{value.ToLocalTime():yyyy-MM-dd HH:mm:ss.fff tt zzz}', 121)"
        : $"CONVERT(datetime2, '{value:yyyy-MM-dd HH:mm:ss.fff}', 121)";

    public override string Escape(Guid value) => $"CAST('{value}' as uniqueidentifier)";

    public override string Escape(byte[] value) => value is null ? Consts.Null : "0x" + BitConverter.ToString(value).Replace("-", "");
}
