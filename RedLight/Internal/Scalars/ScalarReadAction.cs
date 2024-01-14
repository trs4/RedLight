using System;
using System.Data.Common;

namespace RedLight.Internal;

public abstract class ScalarReadAction<T>
{
    static ScalarReadAction()
        => Instance = (ScalarReadAction<T>)Create();

    public static ScalarReadAction<T> Instance { get; }

    private static object Create()
    {
        var type = typeof(T);

        if (type == typeof(bool))
            return new ScalarReadActionBool();
        else if (type == typeof(byte))
            return new ScalarReadActionByte();
        else if (type == typeof(short))
            return new ScalarReadActionShort();
        else if (type == typeof(int))
            return new ScalarReadActionInt();
        else if (type == typeof(long))
            return new ScalarReadActionLong();
        else if (type == typeof(float))
            return new ScalarReadActionFloat();
        else if (type == typeof(double))
            return new ScalarReadActionDouble();
        else if (type == typeof(decimal))
            return new ScalarReadActionDecimal();
        else if (type == typeof(string))
            return new ScalarReadActionString();
        else if (type == typeof(DateTime))
            return new ScalarReadActionDateTime();
        else if (type == typeof(Guid))
            return new ScalarReadActionGuid();
        else if (type == typeof(byte[]))
            return new ScalarReadActionByteArray();
        else if (type == typeof(bool?))
            return new ScalarReadActionNullableBool();
        else if (type == typeof(byte?))
            return new ScalarReadActionNullableByte();
        else if (type == typeof(short?))
            return new ScalarReadActionNullableShort();
        else if (type == typeof(int?))
            return new ScalarReadActionNullableInt();
        else if (type == typeof(long?))
            return new ScalarReadActionNullableLong();
        else if (type == typeof(float?))
            return new ScalarReadActionNullableFloat();
        else if (type == typeof(double?))
            return new ScalarReadActionNullableDouble();
        else if (type == typeof(decimal?))
            return new ScalarReadActionNullableDecimal();
        else if (type == typeof(DateTime?))
            return new ScalarReadActionNullableDateTime();
        else if (type == typeof(Guid?))
            return new ScalarReadActionNullableGuid();

        throw new NotSupportedException(type.FullName);
    }

    public abstract T Read(DbDataReader reader, int index);
}
