using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RedLight.Internal;

internal static class DataReader
{
    [MethodImpl(Flags.HotPath)]
    public static List<TResult> Read<TResult>(DbDataReader reader, QueryOptions options,
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

                        if (propertyInfo.PropertyType == typeof(int))
                            propertyInfo.SetValue(obj, reader.GetInt32(index));
                        else if (propertyInfo.PropertyType == typeof(string))
                            propertyInfo.SetValue(obj, reader.GetString(index));
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

}
