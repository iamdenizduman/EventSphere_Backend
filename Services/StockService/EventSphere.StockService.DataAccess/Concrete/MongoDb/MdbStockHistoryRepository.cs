using EventSphere.Core.Repository.Abstract.MongoDb;
using EventSphere.StockService.DataAccess.Abstract;
using EventSphere.StockService.Entity.Entities;

namespace EventSphere.StockService.DataAccess.Concrete.MongoDb
{
    public class MdbStockHistoryRepository : MdbBaseRepository<StockHistory>, IStockHistoryRepository
    {
        public MdbStockHistoryRepository(MongoDbService mongoDbService) : base(mongoDbService)
        {
        }
    }
}
