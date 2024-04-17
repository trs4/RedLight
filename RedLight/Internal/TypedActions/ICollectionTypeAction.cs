using System.Collections.Generic;
using System.Data.Common;

namespace RedLight.Internal;

internal sealed class ICollectionTypeAction<T, TCollection> : CollectionTypeAction<ICollection<T>>
    where TCollection : ICollection<T>, new()
{
    public sealed override ICollection<T> FillCollection(DatabaseConnection connection, DbDataReader reader, QueryOptions options)
    {
        var source = new TCollection();
        FillCollection(connection, source, reader, options);
        return source;
    }

    public override void FillCollection(DatabaseConnection connection, ICollection<T> source, DbDataReader reader, QueryOptions options)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            ScalarReadAction<T>.Instance.Read(connection, source, reader);
        } while (multipleResult && reader.NextResult());
    }

}
