using System.Data.Common;

namespace RedLight.Internal;

public abstract class ColumnReadAction
{
    protected readonly int _index;

    protected ColumnReadAction(int index)
        => _index = index;

    public abstract void Read(DbDataReader reader, int row);
}
