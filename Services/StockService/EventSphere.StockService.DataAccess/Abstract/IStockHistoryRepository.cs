using EventSphere.StockService.Entity.Entities;
using System.Linq.Expressions;

namespace EventSphere.StockService.DataAccess.Abstract
{
    public interface IStockHistoryRepository
    {
        Task AddAsync(StockHistory entity);
        Task<List<StockHistory>> GetAllAsync(Expression<Func<StockHistory, bool>>? predicate = null);
    }
}
