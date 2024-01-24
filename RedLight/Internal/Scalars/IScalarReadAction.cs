using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Reflection;

namespace RedLight.Internal;

public interface IScalarReadAction
{
    IList Fill<TResult>(PropertyInfo propertyInfo, IReadOnlyCollection<TResult> rows);

    object Read(DatabaseConnection connection, DbDataReader reader, int index);
}
