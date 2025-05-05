using EventSphere.Core.Entity.Messaging.Orders;
using EventSphere.Core.Enums;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.Core.Result;
using EventSphere.OrderService.Application.Interfaces.External;
using EventSphere.OrderService.Application.Interfaces.Messaging;
using EventSphere.OrderService.Application.Interfaces.Repositories;
using EventSphere.OrderService.Domain.Entities;
using EventSphere.OrderService.Domain.Enums;
using MediatR;

namespace EventSphere.OrderService.Application.Features.Orders.CreateOrder
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, DataResult<CreateOrderResponse>>
    {
        private readonly IOrderWriteRepository _orderWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventServiceClient _eventServiceClient;
        private readonly IOrderPublisher _orderPublisher;

        public CreateOrderHandler(IOrderWriteRepository orderWriteRepository, IUnitOfWork unitOfWork, IEventServiceClient eventServiceClient, IOrderPublisher orderPublisher)
        {
            _orderWriteRepository = orderWriteRepository;
            _unitOfWork = unitOfWork;
            _eventServiceClient = eventServiceClient;
            _orderPublisher = orderPublisher;
        }

        public async Task<DataResult<CreateOrderResponse>> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var eventDto = await _eventServiceClient.GetEventPriceById(request.EventId);

            var entity = new Order
            {
                BuyerId = request.BuyerId,
                EventId = request.EventId,
                Quantity = request.Quantity,
                CreatedDate = DateTime.UtcNow,
                Status = OrderStatus.Pending,
                TotalPrice = request.Quantity * eventDto.Price
            };

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                
                await _orderWriteRepository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                OrderCreatedEvent @event = new()
                {
                    EventId = request.EventId
                };

                await _orderPublisher.PublishOrderCreatedAsync(@event);

                await _unitOfWork.CommitAsync();

                CreateOrderResponse response = new()
                {
                    Message = $"{eventDto.Name}'e ait order başarıyla gerçekleştirildi"
                };

                return new DataResult<CreateOrderResponse>(response, ResultStatus.Success, "Order create edilirken hata");
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackAsync();
                return new DataResult<CreateOrderResponse>(null, ResultStatus.Error, "Order create edilirken hata");
            }
        }
    }
}
