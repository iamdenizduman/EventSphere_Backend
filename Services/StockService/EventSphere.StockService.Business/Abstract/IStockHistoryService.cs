using EventSphere.StockService.Entity.Dtos;

namespace EventSphere.StockService.Business.Abstract
{
    public interface IStockHistoryService
    {
        Task AddAsync(AddStockHistoryDto addStockHistoryDto);
    }
}
