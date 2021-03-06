using MongoDBWebAPI.Core.Interfaces;

namespace MongoDBWebAPI.Core.Settings
{
    public class BookstoreDatabaseSettings : IBookstoreDatabaseSettings
    {
        public string BooksCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public BookstoreDatabaseSettings() { }

        public BookstoreDatabaseSettings(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
    }
}
