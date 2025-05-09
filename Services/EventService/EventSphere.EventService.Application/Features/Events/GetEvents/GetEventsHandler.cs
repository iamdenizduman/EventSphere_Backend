using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.DTOs.Events.Response;
using EventSphere.EventService.Domain.DTOs.EventSessions.Response;
using EventSphere.EventService.Domain.DTOs.Speakers.Response;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.GetEvents
{
    public class GetEventsHandler : IRequestHandler<GetEventsRequest, DataResult<GetEventsResponse>>
    {
        private readonly IEventReadRepository _eventReadRepository;

        public GetEventsHandler(IEventReadRepository eventReadRepository)
        {
            _eventReadRepository = eventReadRepository;
        }
        public async Task<DataResult<GetEventsResponse>> Handle(GetEventsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var eventDetailsList = await _eventReadRepository.GetEventDetailsAsync();
                var eventDtoList = eventDetailsList?.Select(e => new EventDto
                {
                    RecordId = e.RecordId,
                    Name = e.Name,
                    Description = e.Description,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Capacity = e.Capacity,
                    Location = e.Location,
                    Price = e.Price,
                    IsStockCreated = e.IsStockCreated,
                    EventSessionDtos = e.EventSessions?.ToList()
                    ?.Select(es => new EventSessionDto
                    {
                        Description = es.Description,
                        EndTime = es.EndTime,
                        SpeakerDto = new SpeakerDto
                        {
                            Bio = es.Speaker.Bio,
                            FirstName = es.Speaker.FirstName,
                            LastName = es.Speaker.LastName,
                            ProfilePictureUrl = es.Speaker.ProfilePictureUrl
                        },
                        StartTime = es.StartTime,
                        Title = es.Title
                    })?.ToList()
                }).ToList();

                var res = new GetEventsResponse { EventDtos = eventDtoList };

                return new DataResult<GetEventsResponse>(res, ResultStatus.Success, "Event detay listesi getirildi");
            }
            catch (Exception ex)
            {
                return new DataResult<GetEventsResponse>(null, ResultStatus.Error, $"Event detay listesi getirilirken bir hata ile karşılaşıldı: {ex.Message}");
            }
        }
    }
}
