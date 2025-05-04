using EventSphere.StockService.Entity.Dtos;

namespace EventSphere.StockService.Business.Abstract
{
    public interface IStockService
    {
        Task<string> AddAsync(AddStockDto addStockDto);
    }
}
