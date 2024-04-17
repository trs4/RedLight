using System.Collections.Generic;
using System.Data.Common;

namespace RedLight.Internal;

internal sealed class ListTypeAction<T> : CollectionTypeAction<List<T>>
{
    public sealed override List<T> FillCollection(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
    {
        var source = new List<T>();
        FillCollection(connection, source, reader, options);
        return source;
    }

    public override void FillCollection(DatabaseConnection connection, List<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(connection, source, reader);
        } while (multipleResult && reader.NextResult());
    }

}
