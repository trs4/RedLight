using RedLight;
using RedLight.Console;

File.Delete(@"C:\Users\evolution\Music\Sunrise\MediaLibrary.db");

//string connectionString = @"Provider=SQLite;Data Source='C:\GitHubProjects\RedLight\test.db'"; // SQLite
string connectionString = @"Provider=SQLite;Data Source='C:\Users\evolution\Music\Sunrise\MediaLibrary.db'"; // SQLite
using var connection = DatabaseConnection.Create(connectionString);
//var r1 = connection.Details.Version.ToString();



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
    new Track() { Guid = Guid.NewGuid(), Path = "test1", Title = "q1", Year = 2024, Duration = DateTime.Now.TimeOfDay, Artist = "w1", Created = DateTime.Now, Size = 4 },
    new Track() { Guid = Guid.NewGuid(), Path = "test2", Title = "q2", Year = 2024, Duration = DateTime.Now.TimeOfDay, Artist = "w2", Created = DateTime.Now, Size = 5 },
    new Track() { Guid = Guid.NewGuid(), Path = "test3", Title = "q3", Year = 2024, Duration = DateTime.Now.TimeOfDay, Artist = "w3", Created = DateTime.Now, Size = 7 },
};

var track = tracks[0];

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

connection.Insert.CreateWithParseQuery<Track, Tracks>(track).Fill(); // Duration (TimeSpan) - integer
connection.Insert.CreateWithParseMultiQuery<Track, Tracks>(tracks).Fill();
//List<Track> r3 = connection.Select.CreateWithParseQuery<Track, Tracks>("t").Get();
//var q1 = TableGenerator.From<ColumnType>();

List<Track> r6 = connection.Select.CreateWithParseQuery<Track, Tracks>().Get();

Console.WriteLine("Exit");
Console.ReadLine();