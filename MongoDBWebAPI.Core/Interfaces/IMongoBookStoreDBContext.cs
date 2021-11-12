using MongoDB.Driver;

namespace MongoDBWebAPI.Core.Interfaces
{
    public interface IMongoBookStoreDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
