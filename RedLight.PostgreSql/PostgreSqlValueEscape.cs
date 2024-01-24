using System;
using System.Globalization;

namespace RedLight.PostgreSql;

internal sealed class PostgreSqlValueEscape : ValueEscape
{
    public PostgreSqlValueEscape(DatabaseConnection connection) : base(connection) { }

    public override string Escape(bool value) => value ? "true" : "false";

    public override string Escape(float value) => value.ToString("G9", CultureInfo.InvariantCulture);

    public override string Escape(double value) => value.ToString("G17", CultureInfo.InvariantCulture);

    public override string Escape(DateTime value)
    {
        if (Connection.Parameters.AutoConvertDatesInUTC && value.Kind == DateTimeKind.Local)
            value = value.ToUniversalTime();

        return $"'{value:O}'::timestamp{(value.Kind == DateTimeKind.Utc ? "tz" : String.Empty)}";
    }

    public override string Escape(Guid value) => $"'{value}'::uuid";

    public override string Escape(byte[] value) => $"decode('{Convert.ToBase64String(value)}', 'base64')";
}
