using System.Data.Common;

namespace RedLight.Internal;

public interface IScalarReadAction
{
    object Read(DbDataReader reader, int index);
}
