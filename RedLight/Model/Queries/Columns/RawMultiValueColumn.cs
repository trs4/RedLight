using System.Collections.Generic;

namespace RedLight;

internal sealed class RawMultiValueColumn : MultiValueColumn
{
    public RawMultiValueColumn(string name, IReadOnlyList<string> escapedValues)
        : base(name)
        => EscapedValues = escapedValues;

    public override int RowCount => EscapedValues.Count;

    /// <summary>Список значений поля</summary>
    public IReadOnlyList<string> EscapedValues { get; }

    internal override string GetEscapedString(DatabaseConnection connection, int rowIndex) => EscapedValues[rowIndex];
}
