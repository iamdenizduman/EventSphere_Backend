using MongoDB.Driver;

namespace EventSphere.Core.Repository.Abstract.MongoDb
{
    public class MongoDbService
    {
        readonly IMongoDatabase _database;
        public MongoDbService(string connectionString, string databaseName)
        {
            MongoClient client = new(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
        }
    }
}
