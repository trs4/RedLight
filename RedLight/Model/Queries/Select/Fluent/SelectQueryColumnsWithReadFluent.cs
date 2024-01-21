using System;

namespace RedLight;

public static class SelectQueryColumnsWithReadFluent
{
    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool</param>
    public static SelectQuery<TResult> AddBoolColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, bool> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool</param>
    public static SelectQuery<TResult> AddBoolColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, bool> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool</param>
    public static SelectQuery<TResult> AddBoolColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, bool> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool</param>
    public static SelectQuery<TResult> AddBoolColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, bool> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool?</param>
    public static SelectQuery<TResult> AddNullableBoolColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, bool?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool?</param>
    public static SelectQuery<TResult> AddNullableBoolColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, bool?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool?</param>
    public static SelectQuery<TResult> AddNullableBoolColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, bool?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа bool?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа bool?</param>
    public static SelectQuery<TResult> AddNullableBoolColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, bool?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte</param>
    public static SelectQuery<TResult> AddByteColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, byte> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte</param>
    public static SelectQuery<TResult> AddByteColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, byte> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte</param>
    public static SelectQuery<TResult> AddByteColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, byte> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte</param>
    public static SelectQuery<TResult> AddByteColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, byte> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte?</param>
    public static SelectQuery<TResult> AddNullableByteColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, byte?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte?</param>
    public static SelectQuery<TResult> AddNullableByteColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, byte?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte?</param>
    public static SelectQuery<TResult> AddNullableByteColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, byte?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte?</param>
    public static SelectQuery<TResult> AddNullableByteColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, byte?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short</param>
    public static SelectQuery<TResult> AddShortColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, short> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short</param>
    public static SelectQuery<TResult> AddShortColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, short> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа short</param>
    public static SelectQuery<TResult> AddShortColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, short> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа short</param>
    public static SelectQuery<TResult> AddShortColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, short> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short?</param>
    public static SelectQuery<TResult> AddNullableShortColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, short?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа short?</param>
    public static SelectQuery<TResult> AddNullableShortColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, short?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа short?</param>
    public static SelectQuery<TResult> AddNullableShortColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, short?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа short?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа short?</param>
    public static SelectQuery<TResult> AddNullableShortColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, short?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int</param>
    public static SelectQuery<TResult> AddIntColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, int> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int</param>
    public static SelectQuery<TResult> AddIntColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, int> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа int</param>
    public static SelectQuery<TResult> AddIntColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, int> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа int</param>
    public static SelectQuery<TResult> AddIntColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, int> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int?</param>
    public static SelectQuery<TResult> AddNullableIntColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, int?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа int?</param>
    public static SelectQuery<TResult> AddNullableIntColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, int?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа int?</param>
    public static SelectQuery<TResult> AddNullableIntColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, int?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа int?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа int?</param>
    public static SelectQuery<TResult> AddNullableIntColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, int?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long</param>
    public static SelectQuery<TResult> AddLongColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, long> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long</param>
    public static SelectQuery<TResult> AddLongColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, long> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа long</param>
    public static SelectQuery<TResult> AddLongColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, long> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа long</param>
    public static SelectQuery<TResult> AddLongColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, long> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long?</param>
    public static SelectQuery<TResult> AddNullableLongColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, long?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа long?</param>
    public static SelectQuery<TResult> AddNullableLongColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, long?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа long?</param>
    public static SelectQuery<TResult> AddNullableLongColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, long?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа long?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа long?</param>
    public static SelectQuery<TResult> AddNullableLongColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, long?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float</param>
    public static SelectQuery<TResult> AddFloatColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, float> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float</param>
    public static SelectQuery<TResult> AddFloatColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, float> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа float</param>
    public static SelectQuery<TResult> AddFloatColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, float> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа float</param>
    public static SelectQuery<TResult> AddFloatColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, float> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float?</param>
    public static SelectQuery<TResult> AddNullableFloatColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, float?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа float?</param>
    public static SelectQuery<TResult> AddNullableFloatColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, float?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа float?</param>
    public static SelectQuery<TResult> AddNullableFloatColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, float?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа float?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа float?</param>
    public static SelectQuery<TResult> AddNullableFloatColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, float?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double</param>
    public static SelectQuery<TResult> AddDoubleColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, double> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double</param>
    public static SelectQuery<TResult> AddDoubleColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, double> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа double</param>
    public static SelectQuery<TResult> AddDoubleColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, double> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа double</param>
    public static SelectQuery<TResult> AddDoubleColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, double> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double?</param>
    public static SelectQuery<TResult> AddNullableDoubleColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, double?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа double?</param>
    public static SelectQuery<TResult> AddNullableDoubleColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, double?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа double?</param>
    public static SelectQuery<TResult> AddNullableDoubleColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, double?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа double?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа double?</param>
    public static SelectQuery<TResult> AddNullableDoubleColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, double?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal</param>
    public static SelectQuery<TResult> AddDecimalColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, decimal> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal</param>
    public static SelectQuery<TResult> AddDecimalColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, decimal> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal</param>
    public static SelectQuery<TResult> AddDecimalColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, decimal> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal</param>
    public static SelectQuery<TResult> AddDecimalColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, decimal> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal?</param>
    public static SelectQuery<TResult> AddNullableDecimalColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, decimal?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal?</param>
    public static SelectQuery<TResult> AddNullableDecimalColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, decimal?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal?</param>
    public static SelectQuery<TResult> AddNullableDecimalColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, decimal?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа decimal?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа decimal?</param>
    public static SelectQuery<TResult> AddNullableDecimalColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, decimal?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа string</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа string</param>
    public static SelectQuery<TResult> AddStringColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, string> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа string</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа string</param>
    public static SelectQuery<TResult> AddStringColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, string> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа string</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа string</param>
    public static SelectQuery<TResult> AddStringColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, string> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа string</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа string</param>
    public static SelectQuery<TResult> AddStringColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, string> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime</param>
    public static SelectQuery<TResult> AddDateTimeColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, DateTime> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime</param>
    public static SelectQuery<TResult> AddDateTimeColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, DateTime> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime</param>
    public static SelectQuery<TResult> AddDateTimeColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, DateTime> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime</param>
    public static SelectQuery<TResult> AddDateTimeColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, DateTime> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime?</param>
    public static SelectQuery<TResult> AddNullableDateTimeColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, DateTime?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime?</param>
    public static SelectQuery<TResult> AddNullableDateTimeColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, DateTime?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime?</param>
    public static SelectQuery<TResult> AddNullableDateTimeColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, DateTime?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа DateTime?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа DateTime?</param>
    public static SelectQuery<TResult> AddNullableDateTimeColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, DateTime?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan</param>
    public static SelectQuery<TResult> AddTimeSpanColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, TimeSpan> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan</param>
    public static SelectQuery<TResult> AddTimeSpanColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, TimeSpan> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan</param>
    public static SelectQuery<TResult> AddTimeSpanColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, TimeSpan> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan</param>
    public static SelectQuery<TResult> AddTimeSpanColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, TimeSpan> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan?</param>
    public static SelectQuery<TResult> AddNullableTimeSpanColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, TimeSpan?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan?</param>
    public static SelectQuery<TResult> AddNullableTimeSpanColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, TimeSpan?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan?</param>
    public static SelectQuery<TResult> AddNullableTimeSpanColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, TimeSpan?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа TimeSpan?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа TimeSpan?</param>
    public static SelectQuery<TResult> AddNullableTimeSpanColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, TimeSpan?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid</param>
    public static SelectQuery<TResult> AddGuidColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, Guid> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid</param>
    public static SelectQuery<TResult> AddGuidColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, Guid> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid</param>
    public static SelectQuery<TResult> AddGuidColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, Guid> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid</param>
    public static SelectQuery<TResult> AddGuidColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, Guid> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid?</param>
    public static SelectQuery<TResult> AddNullableGuidColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, Guid?> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid?</param>
    public static SelectQuery<TResult> AddNullableGuidColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, Guid?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid?</param>
    public static SelectQuery<TResult> AddNullableGuidColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, Guid?> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа Guid?</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа Guid?</param>
    public static SelectQuery<TResult> AddNullableGuidColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, Guid?> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte[]</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte[]</param>
    public static SelectQuery<TResult> AddByteArrayColumn<TResult>(
        this SelectQuery<TResult> query, string name, Action<TResult, byte[]> readColumn)
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte[]</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte[]</param>
    public static SelectQuery<TResult> AddByteArrayColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Action<TResult, byte[]> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte[]</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte[]</param>
    public static SelectQuery<TResult> AddByteArrayColumn<TResult>(
        this SelectQuery<TResult> query, string name, string alias, Action<TResult, byte[]> readColumn)
        => query.AddColumn(name, alias, readColumn);

    /// <summary>Добавляет поле выборки данных с действием чтения данного поля типа byte[]</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="alias">Псевдоним поля</param>
    /// <param name="readColumn">Действие чтения поля типа byte[]</param>
    public static SelectQuery<TResult> AddByteArrayColumn<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string alias, Action<TResult, byte[]> readColumn)
        where TEnum : Enum
        => query.AddColumn(name, alias, readColumn);

}