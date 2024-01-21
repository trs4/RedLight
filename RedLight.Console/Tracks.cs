namespace RedLight.Console;

public enum Tracks
{
    [IdentityColumn, PrimaryKey] Id,
    [Column(ColumnType.Guid)] Guid,
    [Column(ColumnType.Boolean)] Piked,
    [Column(ColumnType.String, size: 255)] Title,
    [Column(ColumnType.Integer)] Year,
    [Column(ColumnType.TimeSpan)] Duration,
    [Column(ColumnType.Byte)] Rating,
    [Column(ColumnType.String, size: 255)] Artist,
    [Column(ColumnType.String, size: 255)] Genre,
    [Column(ColumnType.Integer)] Reproduced,
    [Column(ColumnType.String, size: 255)] Album,
    [Column(ColumnType.DateTime)] Created,
    [Column(ColumnType.DateTime)] Added,
    [Column(ColumnType.Double)] Bitrate,
    [Column(ColumnType.Long)] Size,
    [Column(ColumnType.String, size: 255)] RootFolder,
    [Column(ColumnType.String, size: 255)] RelationFolder,
    [Column(ColumnType.String, size: 255)] OriginalText,
    [Column(ColumnType.String, size: 255)] TranslateText,
    [Column(ColumnType.String, size: 255)] Language,
}

/// <summary>Трек</summary>
public class Track
{
    /// <summary>Идентификатор</summary>
    public int Id { get; set; }

    /// <summary>Уникальный идентификатор</summary>
    public Guid Guid { get; set; }

    /// <summary>путь до файла</summary>
    public string Path { get; set; }

    /// <summary>Выбран</summary>
    public bool Piked { get; set; }

    /// <summary>Название</summary>
    public string Title { get; set; }

    /// <summary>Год</summary>
    public int Year { get; set; }

    /// <summary>Длительность</summary>
    public TimeSpan Duration { get; set; }

    /// <summary>Рейтинг</summary>
    public byte Rating { get; set; }

    /// <summary>Артист</summary>
    public string Artist { get; set; }

    /// <summary>Жанр</summary>
    public string Genre { get; set; }

    /// <summary>Воспроизведено</summary>
    public int Reproduced { get; set; }

    /// <summary>Альбом</summary>
    public string Album { get; set; }

    /// <summary>Создано</summary>
    public DateTime Created { get; set; }

    /// <summary>Добавлено</summary>
    public DateTime Added { get; set; }

    /// <summary>Битрейт</summary>
    public int Bitrate { get; set; }

    /// <summary>Размер</summary>
    public long Size { get; set; }

    public override string ToString() => $"{Artist} - {Title} {Year}";
}