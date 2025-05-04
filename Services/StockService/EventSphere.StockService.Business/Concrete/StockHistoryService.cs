using EventSphere.StockService.Business.Abstract;
using EventSphere.StockService.DataAccess.Abstract;
using EventSphere.StockService.Entity.Dtos;
using EventSphere.StockService.Entity.Entities;

namespace EventSphere.StockService.Business.Concrete
{
    public class StockHistoryService : IStockHistoryService
    {
        private readonly IStockHistoryRepository _stockHistoryRepository;

        public StockHistoryService(IStockHistoryRepository stockHistoryRepository)
        {
            _stockHistoryRepository = stockHistoryRepository;
        }

        public async Task AddAsync(AddStockHistoryDto addStockHistoryDto)
        {
            StockHistory stockHistory = new()
            {
                StockId = addStockHistoryDto.StockId,
                Action = addStockHistoryDto.Action,
                QuantityChanged = addStockHistoryDto.QuantityChanged,
                CreatedDate = DateTime.UtcNow
            };

            await _stockHistoryRepository.AddAsync(stockHistory);
        }
    }
}
