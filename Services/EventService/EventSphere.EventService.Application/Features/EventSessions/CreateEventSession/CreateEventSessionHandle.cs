using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Features.Events.CreateEvent;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.Entities;
using MediatR;

namespace EventSphere.EventService.Application.Features.EventSessions.CreateEventSession
{
    public class CreateEventSessionHandle : IRequestHandler<CreateEventSessionRequest, DataResult<CreateEventSessionResponse>>
    {
        private readonly IEventSessionWriteRepository _eventSessionWriteRepository;

        public CreateEventSessionHandle(IEventSessionWriteRepository eventSessionWriteRepository)
        {
            _eventSessionWriteRepository = eventSessionWriteRepository;
        }

        public async Task<DataResult<CreateEventSessionResponse>> Handle(CreateEventSessionRequest request, CancellationToken cancellationToken)
        {
            EventSession eventSession = new EventSession
            {
                EventId = request.EventId,
                SpeakerId = request.SpeakerId,
                Title = request.Title,
                Description = request.Description,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                CreatedDate = DateTime.UtcNow
            };

            await _eventSessionWriteRepository.AddAsync(eventSession);
            var saveChangesCount = await _eventSessionWriteRepository.SaveChangesAsync();

            if (saveChangesCount == 0)
            {
                return new DataResult<CreateEventSessionResponse>(new CreateEventSessionResponse
                {
                    Title = eventSession.Title
                }, ResultStatus.Error, "Event session eklenirken hata oluştu");   
            }

            return new DataResult<CreateEventSessionResponse>(new CreateEventSessionResponse
            {
                Title = eventSession.Title
            }, ResultStatus.Success, "Event session başarıyla eklendi");
        }
    }
}
