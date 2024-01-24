using System;
using System.Collections.Frozen;
using System.Text;

namespace RedLight.Internal;

internal abstract class ColumnTypes
{
    public abstract ColumnType GetType(object dataType);

    public abstract ColumnType GetType(string stringDataType);

    public abstract string GetDataTypeName(ColumnType type);

    public abstract int GetMaxSize(ColumnType type);
}

internal abstract class ColumnTypes<TDataType> : ColumnTypes
    where TDataType : Enum
{
    protected FrozenDictionary<TDataType, string> _typeNames;
    protected FrozenDictionary<string, TDataType> _nameTypes; // IgnoreCase
    protected FrozenDictionary<ColumnType, TDataType> _types;
    protected FrozenDictionary<TDataType, ColumnType> _dataTypes;
    protected FrozenDictionary<TDataType, int> _maxSizes;
    protected FrozenDictionary<TDataType, Action<StringBuilder, TDataType, int, int>> _appendTypeOptions;
    protected FrozenDictionary<ColumnType, string> _defaultValues;

    public sealed override ColumnType GetType(object dataType)
    {
        if (dataType is string stringDbType)
            return GetType(stringDbType);
        else if (dataType is int)
            return GetType((TDataType)dataType);

        throw new NotSupportedException(dataType?.GetType().FullName);
    }

    public ColumnType GetType(TDataType dataType)
        => _dataTypes.TryGetValue(dataType, out var type) ? type : ColumnType.Unknown;

    public override ColumnType GetType(string stringDataType)
        => _nameTypes.TryGetValue(stringDataType, out var dbType) && _dataTypes.TryGetValue(dbType, out var type)
            ? type : ColumnType.Unknown;

    public TDataType GetDataType(ColumnType type)
        => _types.TryGetValue(type, out var dbType) ? dbType : throw new NotSupportedException(type.ToString());

    public string GetDefaultValue(ColumnType type)
        => _defaultValues.TryGetValue(type, out string defaultValue) ? defaultValue : null;

    public sealed override string GetDataTypeName(ColumnType type) => _typeNames[GetDataType(type)];

    public string GetDataTypeName(TDataType dataType) => _typeNames[dataType];

    public override int GetMaxSize(ColumnType type) => GetMaxSize(GetDataType(type));

    public int GetMaxSize(TDataType dataType)
        => _maxSizes.TryGetValue(dataType, out int maxSize) ? maxSize : Int32.MaxValue;

    public void AppendTypeOptions(StringBuilder builder, TDataType dataType, int size, int precision)
    {
        if (_appendTypeOptions.TryGetValue(dataType, out var buildAction))
            buildAction(builder, dataType, size, precision);
    }

}
