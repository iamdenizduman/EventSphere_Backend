using EventSphere.StockService.Entity.Entities;
using System.Linq.Expressions;

namespace EventSphere.StockService.DataAccess.Abstract
{
    public interface IStockRepository
    {
        Task AddAsync(Stock entity);
        Task<List<Stock>> GetAllAsync(Expression<Func<Stock, bool>>? predicate = null);
        Task<Stock> GetAsync(Expression<Func<Stock, bool>> predicate);
        Task UpdateFieldsAsync(Expression<Func<Stock, bool>> filterExpression, Dictionary<Expression<Func<Stock, object>>, object> updates);
    }
}
