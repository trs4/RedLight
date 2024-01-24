namespace RedLight;

internal sealed class RawQueryParameter : QueryParameter
{
    public RawQueryParameter(string name, object value, ColumnType type, bool nullable = true)
        : base(name, value)
    {
        Type = type;
        Nullable = nullable;
    }

    public override ColumnType Type { get; }

    public override bool Nullable { get; }
}
