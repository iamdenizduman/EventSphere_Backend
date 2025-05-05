using EventSphere.Core.Entity.Messaging.Events;
using EventSphere.Core.Entity.Messaging.Stocks;
using EventSphere.StockService.Business.Abstract;
using EventSphere.StockService.Entity.Dtos;
using EventSphere.StockService.Entity.Enums;
using MassTransit;

namespace EventSphere.StockService.Business.Consumers
{
    public class EventCreatedEventConsumer : IConsumer<EventCreatedEvent>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IStockService _stockService;
        private readonly IStockHistoryService _stockHistoryService;

        public EventCreatedEventConsumer(ISendEndpointProvider sendEndpointProvider, IStockHistoryService stockHistoryService, IStockService stockService)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _stockHistoryService = stockHistoryService;
            _stockService = stockService;
        }

        public async Task Consume(ConsumeContext<EventCreatedEvent> context)
        {
            var msg = context.Message;
            
            AddStockDto addStockDto = new AddStockDto
            {
                TotalQuantity = msg.Capacity,
                EventId = msg.EventId
            };

            var stockId = await _stockService.AddAsync(addStockDto);

            AddStockHistoryDto dto = new AddStockHistoryDto
            {
                Action = nameof(StockHistoryEnum.Added),
                QuantityChanged = addStockDto.TotalQuantity,
                StockId = stockId
            };                     

            await _stockHistoryService.AddAsync(dto);

            StockCreatedEvent @event = new StockCreatedEvent
            {
                EventRecordId = msg.EventId
            };

            ISendEndpoint sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:stock-service-created-stock-queue"));

            await sendEndPoint.Send(@event);
        }
    }

}
