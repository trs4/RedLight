using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RedLight.Internal;

namespace RedLight;

internal static class ColumnBuilder
{
    /// <summary>Максимальное количество полей в строке</summary>
    private const int MaxInLine = 4;

    private const string LineSplitter = "\r\n       ";

    [MethodImpl(Flags.HotPath)]
    public static void Build(StringBuilder builder, List<string> columns)
    {
        if (columns.Count == 0)
            throw new ArgumentException("Empty columns");

        int countInLine = 1;
        builder.Append(columns[0]);

        for (int i = 1; i < columns.Count; ++i)
        {
            builder.Append(", ");

            if (countInLine >= MaxInLine)
            {
                builder.Append(LineSplitter);
                countInLine = 0;
            }
            else
                countInLine++;

            builder.Append(columns[i]);
        }
    }

    [MethodImpl(Flags.HotPath)]
    public static void Build<TColumn>(StringBuilder builder, List<TColumn> columns, Func<TColumn, string> getValue)
    {
        if (columns.Count == 0)
            throw new ArgumentException("Empty columns");

        int countInLine = 1;
        builder.Append(getValue(columns[0]));

        for (int i = 1; i < columns.Count; ++i)
        {
            builder.Append(", ");

            if (countInLine >= MaxInLine)
            {
                builder.Append(LineSplitter);
                countInLine = 0;
            }
            else
                countInLine++;

            builder.Append(getValue(columns[i]));
        }
    }

    [MethodImpl(Flags.HotPath)]
    public static void Build<TColumn>(StringBuilder builder, List<TColumn> columns, Action<TColumn> buildValue)
    {
        if (columns.Count == 0)
            throw new ArgumentException("Empty columns");

        int countInLine = 1;
        buildValue(columns[0]);

        for (int i = 1; i < columns.Count; ++i)
        {
            builder.Append(", ");

            if (countInLine >= MaxInLine)
            {
                builder.Append(LineSplitter);
                countInLine = 0;
            }
            else
                countInLine++;

            buildValue(columns[i]);
        }
    }

    [MethodImpl(Flags.HotPath)]
    public static void Build<TKey, TValue>(StringBuilder builder, Dictionary<TKey, TValue> columns,
        Func<KeyValuePair<TKey, TValue>, string> getValue)
    {
        if (columns.Count == 0)
            throw new ArgumentException("Empty columns");

        int countInLine = 0;
        bool appendSplitter = false;

        foreach (var pair in columns)
        {
            if (appendSplitter)
                builder.Append(", ");
            else
                appendSplitter = true;

            if (countInLine >= MaxInLine)
            {
                builder.Append(LineSplitter);
                countInLine = 0;
            }
            else
                countInLine++;

            builder.Append(getValue(pair));
        }
    }

    [MethodImpl(Flags.HotPath)]
    public static void Build<TKey, TValue>(StringBuilder builder, Dictionary<TKey, TValue> columns,
        Action<KeyValuePair<TKey, TValue>> buildValue)
    {
        if (columns.Count == 0)
            throw new ArgumentException("Empty columns");

        int countInLine = 0;
        bool appendSplitter = false;

        foreach (var pair in columns)
        {
            if (appendSplitter)
                builder.Append(", ");
            else
                appendSplitter = true;

            if (countInLine >= MaxInLine)
            {
                builder.Append(LineSplitter);
                countInLine = 0;
            }
            else
                countInLine++;

            buildValue(pair);
        }
    }

}
