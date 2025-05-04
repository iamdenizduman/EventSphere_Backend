using EventSphere.Core.Entity.Messaging.Stocks;
using EventSphere.EventService.Application.Features.Events.UpdateEventStock;
using MassTransit;
using MediatR;

namespace EventSphere.EventService.Infrastructure.Messaging.RabbitMQ.Consumers
{
    public class StockCreatedEventConsumer : IConsumer<StockCreatedEvent>
    {
        private readonly IMediator _mediator;

        public StockCreatedEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<StockCreatedEvent> context)
        {
            var msg = context.Message;
            int recordId = msg.EventRecordId;

            var request = new UpdateEventStockRequest
            {
                EventId = recordId
            };

            await _mediator.Send(request);
        }
    }
}
