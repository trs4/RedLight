using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight.Internal;

internal sealed class EmptyDataReader : DbDataReader
{
    private EmptyDataReader() { }

    public static readonly EmptyDataReader Instance = new();

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static T ThrowDisposed<T>() => throw new ObjectDisposedException(nameof(DbDataReader));

    public override object this[int ordinal] => null;

    public override object this[string name] => null;

    public override int Depth => 0;

    public override int FieldCount => 0;

    public override bool HasRows => false;

    public override bool IsClosed => true;

    public override int RecordsAffected => -1;

    public override int VisibleFieldCount => 0;

    public override bool GetBoolean(int ordinal) => ThrowDisposed<bool>();

    public override byte GetByte(int ordinal) => ThrowDisposed<byte>();

    public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) => ThrowDisposed<long>();

    public override char GetChar(int ordinal) => ThrowDisposed<char>();

    public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) => ThrowDisposed<long>();

    public override string GetDataTypeName(int ordinal) => ThrowDisposed<string>();

    public override DateTime GetDateTime(int ordinal) => ThrowDisposed<DateTime>();

    public override decimal GetDecimal(int ordinal) => ThrowDisposed<decimal>();

    public override double GetDouble(int ordinal) => ThrowDisposed<double>();

    public override IEnumerator GetEnumerator() => ThrowDisposed<IEnumerator>();

    public override Type GetFieldType(int ordinal) => ThrowDisposed<Type>();

    public override float GetFloat(int ordinal) => ThrowDisposed<float>();

    public override Guid GetGuid(int ordinal) => ThrowDisposed<Guid>();

    public override short GetInt16(int ordinal) => ThrowDisposed<short>();

    public override int GetInt32(int ordinal) => ThrowDisposed<int>();

    public override long GetInt64(int ordinal) => ThrowDisposed<long>();

    public override string GetName(int ordinal) => ThrowDisposed<string>();

    public override int GetOrdinal(string name) => ThrowDisposed<int>();

    public override string GetString(int ordinal) => ThrowDisposed<string>();

    public override object GetValue(int ordinal) => ThrowDisposed<object>();

    public override int GetValues(object[] values) => ThrowDisposed<int>();

    public override bool IsDBNull(int ordinal) => ThrowDisposed<bool>();

    public override bool NextResult() => ThrowDisposed<bool>();

    public override bool Read() => ThrowDisposed<bool>();

    public override T GetFieldValue<T>(int ordinal) => ThrowDisposed<T>();

    public override Task<T> GetFieldValueAsync<T>(int ordinal, CancellationToken cancellationToken) => ThrowDisposed<Task<T>>();

    public override Type GetProviderSpecificFieldType(int ordinal) => ThrowDisposed<Type>();

    public override object GetProviderSpecificValue(int ordinal) => ThrowDisposed<object>();

    public override int GetProviderSpecificValues(object[] values) => ThrowDisposed<int>();

    public override DataTable GetSchemaTable() => ThrowDisposed<DataTable>();

    public override Stream GetStream(int ordinal) => ThrowDisposed<Stream>();

    public override TextReader GetTextReader(int ordinal) => ThrowDisposed<TextReader>();

    public override Task<bool> IsDBNullAsync(int ordinal, CancellationToken cancellationToken) => ThrowDisposed<Task<bool>>();

    public override Task<bool> NextResultAsync(CancellationToken cancellationToken) => ThrowDisposed<Task<bool>>();

    public override Task<bool> ReadAsync(CancellationToken cancellationToken) => ThrowDisposed<Task<bool>>();
}
