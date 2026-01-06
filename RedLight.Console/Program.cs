using IcyRain.Tables;
using RedLight;
using RedLight.Console;

//File.Delete(@"C:\Users\evolution\Music\Sunrise\MediaLibrary.db");

//string connectionString = @"Provider=SQLite;Data Source='C:\GitHubProjects\RedLight\test.db'"; // SQLite
string connectionString = @"Provider=SQLite;Data Source='C:\Users\user\Music\Sunrise\MediaLibrary.db'"; // SQLite
//string connectionString = @"Provider=SqlServer"; // SQL Server
using var connection = DatabaseConnection.Create(connectionString);
//var r1 = connection.Details.Version.ToString();

{
    var removePlaylistTracks = new DataTable();
    var removePlaylistIdColumn = removePlaylistTracks.AddInt32Column(nameof(PlaylistTracks.PlaylistId));
    var removeTrackIdColumn = removePlaylistTracks.AddInt32Column(nameof(PlaylistTracks.TrackId));


    int row = removePlaylistTracks.RowCount++;
    removePlaylistIdColumn.Set(row, 10000);
    removeTrackIdColumn.Set(row, 20);

    row = removePlaylistTracks.RowCount++;
    removePlaylistIdColumn.Set(row, 11000);
    removeTrackIdColumn.Set(row, 21);

    row = removePlaylistTracks.RowCount++;
    removePlaylistIdColumn.Set(row, 12000);
    removeTrackIdColumn.Set(row, 22);

    string sql = connection.Delete.CreateWithParseMultiQuery<DataTable, PlaylistTracks>(removePlaylistTracks).Sql;
}
//    await _connection.Insert.CreateWithParseMultiQuery<DataTable, PlaylistTracks>(addPlaylistTracks, returningIdentity: false).RunAsync(token);







    //SQLite:

    //Data Source=c:\mydb.db;Version=3;Password=myPassword;Pooling=True;Max Pool Size=100;
    //Data Source=:memory:;Version=3;New=True;


    //SqlServer:

    //Server = myServerName\myInstanceName; Database = myDataBase; User Id = myUsername; Password = myPassword;
    //Data Source = 190.190.200.100,1433; Network Library = DBMSSOCN; Initial Catalog = myDataBase; User ID = myUsername; Password = myPassword;
    //Server =.\SQLExpress; AttachDbFilename = C:\MyFolder\MyDataFile.mdf; Database = dbname; Trusted_Connection = Yes;
    //Server = (localdb)\v11.0; Integrated Security = true; AttachDbFileName = C:\MyFolder\MyData.mdf;

    //PostgreSql:
    //User ID = root; Password = myPassword; Host = localhost; Port = 5432; Database = myDataBase; Pooling = true; Min Pool Size=0; Max Pool Size=100; Connection Lifetime = 0;

    var tracks = new List<Track>()
{
    new Track() { Guid = Guid.NewGuid(), Path = "test1", Title = "q1", Year = 2024, Duration = DateTime.Now.TimeOfDay, Artist = "w1",
        Created = DateTime.Now, Size = 4 },
    new Track() { Guid = Guid.NewGuid(), Path = "test2", Title = "q2", Year = 2024, Duration = DateTime.Now.TimeOfDay, Artist = "w2",
        Created = DateTime.Now.AddDays(1), Size = 5 },
    new Track() { Guid = Guid.NewGuid(), Path = "test3", Title = "q3", Year = 2024, Duration = DateTime.Now.TimeOfDay, Artist = "w3",
        Created = DateTime.Now.AddDays(2), Size = 7 },
};

var track = tracks[0];
int number = 1000;

foreach (var t in tracks)
    t.Id = number++;

//var r1 = connection.Select.CreateWithParseQuery<List<Track>, Tracks>("t");
//var r2 = connection.Select.CreateWithParseQuery<Track, Tracks>("t").Sql;

//var r3 = connection.Insert.CreateQuery<Track, Tracks>()
//    .AddColumn(Tracks.Guid, track.Guid)
//    .AddColumn(Tracks.Title, track.Title)
//    .AddIntReturningColumn(Tracks.Id, (t, value) => t.Id = value)
//    .Sql;

//var r4 = connection.Insert.CreateWithParseQuery<Track, Tracks>(track).Sql;
//var r5 = connection.Insert.CreateWithParseMultiQuery<Track, Tracks>(tracks).Sql;

connection.Schema.CreateTableWithParseQuery<Tracks>().Run();

//connection.Insert.CreateWithParseQuery<Track, Tracks>(track).Fill(); // Duration (TimeSpan) - integer
connection.Insert.CreateWithParseMultiQuery<Track, Tracks>(tracks, returningIdentity: false).Fill();
//List<Track> r3 = connection.Select.CreateWithParseQuery<Track, Tracks>("t").Get();
//var q1 = TableGenerator.From<ColumnType>();

//List<string> tracks3 = connection.Select.CreateQuery(nameof(Tracks)).AddColumn(Tracks.Title).Get<List<string>>();

//List<Track> tracks2 = connection.Select.CreateWithParseQuery<Track, Tracks>().Get();
//var track2 = tracks2[0];

//foreach (var t in tracks2)
//{
//    t.Genre = "test";
//    t.Added = DateTime.Now.AddDays(10);
//}

//var r20 = connection.Update.CreateWithParseQuery<Track, Tracks>(track2).Sql;
//var r21 = connection.Update.CreateWithParseMultiQuery<Track, Tracks>(tracks2).Sql;
//var r22 = connection.Update.CreateWithParseQuery<Track, Tracks>(track2).Run();
//var r23 = connection.Update.CreateWithParseMultiQuery<Track, Tracks>(tracks2).Run();


//var r10 = connection.Delete.CreateWithParseQuery<int, Tracks>(track.Id).Sql;
//var r11 = connection.Delete.CreateWithParseQuery<int, Tracks>(tracks.Select(t => t.Id).ToList()).Sql;
//var r12 = connection.Delete.CreateWithParseQuery<Track, Tracks>(track).Run();
//var r13 = connection.Delete.CreateWithParseQuery<Track, Tracks>(tracks).Run();

//var trackReproduceds = new List<TrackReproduced>()
//{
//    new TrackReproduced(1, 2, 3),
//    new TrackReproduced(11, 21, 31),
//    new TrackReproduced(12, 22, 32),
//    new TrackReproduced(13, 23, 33),
//};

//var r10 = connection.Delete.CreateWithParseMultiQuery<TrackReproduced, TrackReproduceds>(trackReproduceds).Sql;
//var r30 = connection.Select.CreateWithParseQuery<DataTable, Tracks>().Get();
var r31 = connection.Select.CreateWithParseQuery<Tracks>().Get<DataTable>();
var r32 = connection.Select.CreateWithParseQuery<DataTable, Tracks>().GetOne();

Console.WriteLine("Exit");
Console.ReadLine();