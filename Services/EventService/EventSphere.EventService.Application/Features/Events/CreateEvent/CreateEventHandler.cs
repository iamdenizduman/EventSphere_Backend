using EventSphere.Core.Entity.Messaging.Events;
using EventSphere.Core.Repository.Interfaces;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Interfaces.Messaging;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.Entities;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventRequest, DataResult<CreateEventResponse>>
    {
        private readonly IEventWriteRepository _eventWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventPublisher _eventPublisher;

        public CreateEventHandler(IEventWriteRepository eventWriteRepository, IUnitOfWork unitOfWork, IEventPublisher eventPublisher)
        {
            _eventWriteRepository = eventWriteRepository;
            _unitOfWork = unitOfWork;
            _eventPublisher = eventPublisher;
        }

        public async Task<DataResult<CreateEventResponse>> Handle(CreateEventRequest request, CancellationToken cancellationToken)
        {
            var entity = new Event
            {
                Name = request.Name,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Capacity = request.Capacity,
                Location = request.Location,
                Price = request.Price,
                CreatedDate = DateTime.UtcNow
            };

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                await _eventWriteRepository.AddAsync(entity);
                await _unitOfWork.SaveChangesAsync();

                EventCreated @event = new EventCreated
                {
                    Capacity = request.Capacity,
                    EventId = entity.RecordId
                };
                await _eventPublisher.PublishEventCreatedAsync(@event);
                await _unitOfWork.CommitAsync();

                var res = new CreateEventResponse
                {
                    Name = entity.Name
                };

                return new DataResult<CreateEventResponse>(res, Core.Enums.ResultStatus.Success, "Event başarıyla eklendi");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();

                return new DataResult<CreateEventResponse>(null, Core.Enums.ResultStatus.Error, ex.Message);
            }
        }
    }
}
