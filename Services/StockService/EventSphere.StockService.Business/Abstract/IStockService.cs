using EventSphere.StockService.Entity.Dtos;
using EventSphere.StockService.Entity.Entities;
using System.Linq.Expressions;

namespace EventSphere.StockService.Business.Abstract
{
    public interface IStockService
    {
        Task<string> AddAsync(AddStockDto addStockDto);
        Task UpdateAsync(UpdateStockDto updateStockDto);
        Task<Stock> GetAsync(Expression<Func<Stock, bool>> predicate);
    }
}
