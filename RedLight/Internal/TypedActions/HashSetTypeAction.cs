using System.Collections.Generic;
using System.Data.Common;

namespace RedLight.Internal;

internal sealed class HashSetTypeAction<T> : CollectionTypeAction<HashSet<T>>
{
    public sealed override HashSet<T> FillCollection(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
    {
        var source = new HashSet<T>();
        FillCollection(connection, source, reader, options);
        return source;
    }

    public override void FillCollection(DatabaseConnection connection, HashSet<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(connection, source, reader);
        } while (multipleResult && reader.NextResult());
    }

}
