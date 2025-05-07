using EventSphere.Core.Entity.Messaging.Orders;
using EventSphere.Core.Entity.Messaging.Stocks;
using EventSphere.StockService.Business.Abstract;
using EventSphere.StockService.Entity.Dtos;
using EventSphere.StockService.Entity.Enums;
using MassTransit;

namespace EventSphere.StockService.Business.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IStockService _stockService;
        private readonly IStockHistoryService _stockHistoryService;

        public OrderCreatedEventConsumer(IStockService stockService, IStockHistoryService stockHistoryService, ISendEndpointProvider sendEndpointProvider)
        {
            _stockService = stockService;
            _stockHistoryService = stockHistoryService;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var req = context.Message;
            int eventId = req.EventId;
            int quantity = req.Quantity;
            int orderId = req.OrderId;

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

            StockReservedEvent @event = new()
            {
                EventRecordId = eventId,
                OrderId = orderId
            };

            ISendEndpoint sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:stock-service-reserved-stock-queue"));

            await sendEndPoint.Send(@event);
        }
    }
}
