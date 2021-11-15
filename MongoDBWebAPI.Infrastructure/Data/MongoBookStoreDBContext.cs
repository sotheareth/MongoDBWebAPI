using MongoDB.Driver;
using MongoDBWebAPI.Core.Interfaces;

namespace MongoDBWebAPI.Infrastructure.Data
{
    public class MongoBookStoreDBContext : IMongoBookStoreDBContext
    {
        private IMongoDatabase _db { get; set; }
        private IMongoClient _mongoClient { get; set; }

        public MongoBookStoreDBContext(IBookstoreDatabaseSettings configuration)
        {
            _mongoClient = new MongoClient(configuration.ConnectionString);
            _db = _mongoClient.GetDatabase(configuration.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _db.GetCollection<T>(name);
        }


    }
}
