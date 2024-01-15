using System;
using System.Collections.Generic;
using System.Reflection;

namespace RedLight.Internal;

internal class Types
{
    public static readonly Type ICollection = typeof(ICollection<>);

    public static bool TryGetICollectionArgumentType(Type type, out Type elementType)
    {
        foreach (var interfaceType in type.GetInterfaces())
        {
            var typeInfo = interfaceType.GetTypeInfo();

            if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition() == ICollection)
            {
                elementType = typeInfo.GetGenericArguments()[0];
                return true;
            }
        }

        elementType = null;
        return false;
    }

}
