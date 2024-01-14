using RedLight;

//string connectionString = @"Provider=SQLite;Data Source='C:\GitHubProjects\RedLight\test.db'"; // SQLite
//using var connection = DatabaseConnection.Create(connectionString);
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

var q1 = TableGenerator.From<ColumnType>();

Console.WriteLine("Exit");
Console.ReadLine();