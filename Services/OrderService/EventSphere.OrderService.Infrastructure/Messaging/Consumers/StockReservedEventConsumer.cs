using EventSphere.Core.Entity.Messaging.Orders;
using EventSphere.Core.Entity.Messaging.Stocks;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.OrderService.Application.Interfaces.Repositories;
using EventSphere.OrderService.Domain.Enums;
using MassTransit;
using MassTransit.Transports;

namespace EventSphere.OrderService.Infrastructure.Messaging.Consumers
{
    public class StockReservedEventConsumer : IConsumer<StockReservedEvent>
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StockReservedEventConsumer(IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository, IUnitOfWork unitOfWork, ISendEndpointProvider sendEndpointProvider)
        {
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _unitOfWork = unitOfWork;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Consume(ConsumeContext<StockReservedEvent> context)
        {
            var msg = context.Message;
            var eventId = msg.EventRecordId;
            var orderId = msg.OrderId;

            var order = await _orderReadRepository.GetSingleAsync(o => o.EventId == eventId && o.Id == orderId);
            
            order.Status = OrderStatus.StockReserved;

            _orderWriteRepository.Update(order);
            await _orderWriteRepository.SaveChangesAsync();

            await _unitOfWork.BeginTransactionAsync();
            try
            {
                order.Status = OrderStatus.PaymentProcessing;
                
                _orderWriteRepository.Update(order);
                await _unitOfWork.SaveChangesAsync();

                OrderPaymentStartedEvent @event = new()
                {
                    BuyerId = order.BuyerId,
                    EventId = order.EventId,
                    OrderId = order.Id,
                    TotalPrice = order.TotalPrice
                };

                ISendEndpoint sendEndPoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:order-service-payment-started-order-queue"));
                await sendEndPoint.Send(@event);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
            }
        } 
    }
}
