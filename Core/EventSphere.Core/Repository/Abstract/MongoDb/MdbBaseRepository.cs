using EventSphere.Core.Entity.Interfaces;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace EventSphere.Core.Repository.Abstract.MongoDb
{
    public class MdbBaseRepository<T> where T : class, IEntity, new()
    {
        MongoDbService _mongoDbService;
        IMongoCollection<T> _collections;

        public MdbBaseRepository(MongoDbService mongoDbService)
        {
            _mongoDbService = mongoDbService;
            _collections = _mongoDbService.GetCollection<T>();
        }

        public async Task AddAsync(T entity)
        { 
            await _collections.InsertOneAsync(entity);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
            {
                return await _collections.Find(_ => true).ToListAsync();
            }
            return await _collections.Find(predicate).ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _collections.Find(predicate).SingleOrDefaultAsync();
        }

        public async Task UpdateFieldsAsync(Expression<Func<T, bool>> filterExpression, Dictionary<Expression<Func<T, object>>, object> updates)
        {
            var filter = Builders<T>.Filter.Where(filterExpression);

            var updateDefinition = new List<UpdateDefinition<T>>();

            foreach (var update in updates)
            {
                updateDefinition.Add(Builders<T>.Update.Set(update.Key, update.Value));
            }

            var combinedUpdate = Builders<T>.Update.Combine(updateDefinition);

            await _collections.UpdateOneAsync(filter, combinedUpdate);
        }

    }
}
