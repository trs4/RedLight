using System.Data.Common;

namespace RedLight.Internal;

public abstract class ColumnReadAction
{
    protected readonly DatabaseConnection _connection;
    protected readonly int _index;

    protected ColumnReadAction(DatabaseConnection connection, int index)
    {
        _connection = connection;
        _index = index;
    }

    public abstract void Read(DbDataReader reader, int row);
}
