using EventSphere.Core.Repository.Abstract.MongoDb;
using EventSphere.StockService.DataAccess.Abstract;
using EventSphere.StockService.Entity.Entities;
using System.Linq.Expressions;

namespace EventSphere.StockService.DataAccess.Concrete.MongoDb
{
    public class MdbStockRepository : MdbBaseRepository<Stock>, IStockRepository
    {
        private readonly MongoDbService _mongoDbService;
        public MdbStockRepository(MongoDbService mongoDbService) : base(mongoDbService)
        {
            _mongoDbService = mongoDbService;
        }
    }
}
