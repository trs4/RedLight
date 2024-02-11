using System;
using System.Threading;
using System.Threading.Tasks;

namespace RedLight;

public static class SelectQueryGetOneFluent
{
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, bool value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, bool value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, bool value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, bool value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, byte value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, byte value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, byte value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, byte value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, short value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, short value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, short value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, short value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, int value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, int value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, int value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, int value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, long value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, long value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, long value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, long value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, float value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, float value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, float value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, float value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, double value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, double value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, double value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, double value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, decimal value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, decimal value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, decimal value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, decimal value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, string value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, string value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, string value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, DateTime value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, DateTime value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, DateTime value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, DateTime value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, TimeSpan value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, TimeSpan value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, TimeSpan value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, TimeSpan value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult>(
        this SelectQuery<TResult> query, string name, Guid value)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult>(
        this SelectQuery<TResult> query, string name, Guid value, CancellationToken token = default)
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);
        
    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <returns>Результат заданного типа</returns>
    public static TResult GetOne<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Guid value)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOne();

    /// <summary>Выполняет запрос с получением результата в данном формате</summary>
    /// <param name="name">Имя поля</param>
    /// <param name="value">Значение</param>
    /// <param name="token">Оповещение отмены задачи</param>
    /// <returns>Результат заданного типа</returns>
    public static Task<TResult> GetOneAsync<TResult, TEnum>(
        this SelectQuery<TResult> query, TEnum name, Guid value, CancellationToken token = default)
        where TEnum : Enum
        => query.TakeFirst().WithTerm(name, Op.Equal, value).GetOneAsync(token);

}