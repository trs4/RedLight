﻿using System;
using RedLight.Internal;

namespace RedLight;

internal sealed class DateTimeQueryParameter : QueryParameter
{
    public DateTimeQueryParameter(DatabaseConnection connection, string name, DateTime value)
        : base(name, connection.ConvertToParameter(value)) { }

    public override ColumnType Type => ColumnType.DateTime;

    public override bool Nullable => false;
}

internal sealed class NullableDateTimeQueryParameter : QueryParameter
{
    public NullableDateTimeQueryParameter(DatabaseConnection connection, string name, DateTime? value)
        : base(name, value.HasValue ? connection.ConvertToParameter(value.Value) : DBNull.Value) { }

    public override ColumnType Type => ColumnType.DateTime;

    public override bool Nullable => true;
}
