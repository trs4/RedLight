namespace RedLight;

internal sealed class RawValueColumn : ValueColumn
{
    private readonly string _escapedValue;

    public RawValueColumn(string name, string escapedValue)
        : base(name)
        => _escapedValue = escapedValue;

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options) => _escapedValue;
}
