using EventSphere.Core.Entity.Messaging.Orders;
using EventSphere.PaymentService.Application.Features.CreatePayment;
using MassTransit;
using MediatR;

namespace EventSphere.PaymentService.Infrastructure.Messaging.Consumers
{
    public class OrderPaymentStartedEventConsumer : IConsumer<OrderPaymentStartedEvent>
    {
        private readonly IMediator _mediator;

        public OrderPaymentStartedEventConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<OrderPaymentStartedEvent> context)
        {
            var msg = context.Message;

            var createPaymentRequest = new CreatePaymentRequest
            {
                BuyerId = msg.BuyerId,
                EventId = msg.EventId,
                OrderId = msg.OrderId,
                TotalPrice = msg.TotalPrice
            };

            var response = await _mediator.Send(createPaymentRequest);
        }
    }
}
