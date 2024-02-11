using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class DataReader
{
    [MethodImpl(Flags.HotPath)]
    public static List<TResult> Read<TResult>(DatabaseConnection connection, DbDataReader reader, QueryOptions options,
        List<Action<TResult, DbDataReader>> readActions, Func<IEnumerable<string>> getColumns)
    {
        bool multipleResult = options?.MultipleResult ?? false;
        var result = new List<TResult>();

        do
        {
            while (reader.Read())
            {
                var obj = Activator.CreateInstance<TResult>();

                if (readActions.IsNullOrEmpty())
                {
                    var propertyNames = getColumns().Select(f => f.Substring(1, f.Length - 2));
                    int index = -1;

                    foreach (string propertyName in propertyNames)
                    {
                        index++;
                        var propertyInfo = typeof(TResult).GetProperty(propertyName);

                        if (propertyInfo is null)
                            continue;

                        propertyInfo.SetValue(obj, ScalarReadBuilder.Read(connection, propertyInfo.PropertyType, reader, index));
                    }
                }
                else
                {
                    foreach (var readAction in readActions)
                        readAction(obj, reader);
                }

                result.Add(obj);
            }
        } while (multipleResult && reader.NextResult());

        return result;
    }

    [MethodImpl(Flags.HotPath)]
    public static TResult ReadOne<TResult>(DatabaseConnection connection, DbDataReader reader, QueryOptions options,
        List<Action<TResult, DbDataReader>> readActions, Func<IEnumerable<string>> getColumns)
    {
        bool multipleResult = options?.MultipleResult ?? false;

        do
        {
            while (reader.Read())
            {
                var obj = Activator.CreateInstance<TResult>();

                if (readActions.IsNullOrEmpty())
                {
                    var propertyNames = getColumns().Select(f => f.Substring(1, f.Length - 2));
                    int index = -1;

                    foreach (string propertyName in propertyNames)
                    {
                        index++;
                        var propertyInfo = typeof(TResult).GetProperty(propertyName);

                        if (propertyInfo is null)
                            continue;

                        propertyInfo.SetValue(obj, ScalarReadBuilder.Read(connection, propertyInfo.PropertyType, reader, index));
                    }
                }
                else
                {
                    foreach (var readAction in readActions)
                        readAction(obj, reader);
                }

                return obj;
            }
        } while (multipleResult && reader.NextResult());

        return default;
    }

    [MethodImpl(Flags.HotPath)]
    public static void Fill<TResult>(DatabaseConnection connection, IReadOnlyCollection<TResult> data, DbDataReader reader, QueryOptions options,
        List<Action<TResult, DbDataReader>> readActions, Func<IEnumerable<string>> getColumns)
    {
        bool multipleResult = options?.MultipleResult ?? false;
        using var enumerator = data.GetEnumerator();

        do
        {
            while (reader.Read())
            {
                if (!enumerator.MoveNext())
                    throw new InvalidOperationException(nameof(enumerator));

                var obj = enumerator.Current;

                if (readActions.IsNullOrEmpty())
                {
                    var propertyNames = getColumns().Select(f => f.Substring(1, f.Length - 2));
                    int index = -1;

                    foreach (string propertyName in propertyNames)
                    {
                        index++;
                        var propertyInfo = typeof(TResult).GetProperty(propertyName);

                        if (propertyInfo is null)
                            continue;

                        propertyInfo.SetValue(obj, ScalarReadBuilder.Read(connection, propertyInfo.PropertyType, reader, index));
                    }
                }
                else
                {
                    foreach (var readAction in readActions)
                        readAction(obj, reader);
                }
            }
        } while (multipleResult && reader.NextResult());
    }

}
