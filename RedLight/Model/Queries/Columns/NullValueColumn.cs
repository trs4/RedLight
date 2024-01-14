using RedLight.Internal;

namespace RedLight;

internal sealed class NullValueColumn : ValueColumn
{
    public NullValueColumn(string name) : base(name) { }

    internal override string GetEscapedString(DatabaseConnection connection, QueryOptions options) => Consts.Null;
}
