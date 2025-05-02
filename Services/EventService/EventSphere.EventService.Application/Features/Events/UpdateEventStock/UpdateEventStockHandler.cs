using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.Entities;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.UpdateEventStock
{
    public class UpdateEventStockHandler : IRequestHandler<UpdateEventStockRequest, DataResult<UpdateEventStockResponse>>
    {
        private readonly IEventWriteRepository _eventWriteRepository;
        private readonly IEventReadRepository _eventReadRepository;

        public UpdateEventStockHandler(IEventWriteRepository eventWriteRepository, IEventReadRepository eventReadRepository)
        {
            _eventWriteRepository = eventWriteRepository;
            _eventReadRepository = eventReadRepository;
        }

        public async Task<DataResult<UpdateEventStockResponse>> Handle(UpdateEventStockRequest request, CancellationToken cancellationToken)
        {
            Event? @event = await _eventReadRepository.GetSingleAsync(e => e.RecordId == request.EventId);

            if (@event == null) 
            {
                return new DataResult<UpdateEventStockResponse>(null, ResultStatus.Error, "Event bulunamadı");
            }

            @event.IsStockCreated = true;

            _eventWriteRepository.Update(@event);
            await _eventWriteRepository.SaveChangesAsync();

            var res = new UpdateEventStockResponse();
            return new DataResult<UpdateEventStockResponse>(res, ResultStatus.Error, "Event başarıyla güncellendi");
        }
    }
}
