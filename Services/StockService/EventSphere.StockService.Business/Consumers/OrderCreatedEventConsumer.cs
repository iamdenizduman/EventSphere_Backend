using EventSphere.Core.Entity.Messaging.Orders;
using EventSphere.StockService.Business.Abstract;
using EventSphere.StockService.Entity.Dtos;
using EventSphere.StockService.Entity.Enums;
using MassTransit;
using MassTransit.Mediator;

namespace EventSphere.StockService.Business.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly IStockService _stockService;
        private readonly IStockHistoryService _stockHistoryService;

        public OrderCreatedEventConsumer(IStockService stockService, IStockHistoryService stockHistoryService)
        {
            _stockService = stockService;
            _stockHistoryService = stockHistoryService;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var req = context.Message;
            int eventId = req.EventId;
            int quantity = req.Quantity;

            var stock = await _stockService.GetAsync(s => s.EventId == eventId);

            UpdateStockDto updateStockDto = new()
            {
                Id = stock.Id,
                EventId = eventId,
                Quantity = quantity,
                AvailableQuantity = stock.AvailableQuantity - quantity,
                SoldQuantity = stock.SoldQuantity + quantity
            };

            await _stockService.UpdateAsync(updateStockDto);

            AddStockHistoryDto addStockHistoryDto = new()
            {
                Action = nameof(StockHistoryEnum.Sold),
                QuantityChanged = quantity,
                StockId = stock.Id
            };

            await _stockHistoryService.AddAsync(addStockHistoryDto);
        }
    }
}
