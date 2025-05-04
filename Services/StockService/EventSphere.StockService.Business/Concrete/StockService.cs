using EventSphere.StockService.Business.Abstract;
using EventSphere.StockService.DataAccess.Abstract;
using EventSphere.StockService.Entity.Dtos;
using EventSphere.StockService.Entity.Entities;

namespace EventSphere.StockService.Business.Concrete
{
    public class StockService : IStockService
    {
        IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<string> AddAsync(AddStockDto addStockDto)
        {
            Stock stock = new()
            {
                EventId = addStockDto.EventId,
                TotalQuantity = addStockDto.TotalQuantity,
                AvailableQuantity = addStockDto.TotalQuantity,
                CreatedDate = DateTime.UtcNow
            };

            await _stockRepository.AddAsync(stock);

            return stock.Id;
        }
    }
}
