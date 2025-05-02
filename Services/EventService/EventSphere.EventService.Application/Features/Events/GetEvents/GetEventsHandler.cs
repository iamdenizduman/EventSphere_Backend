using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.DTOs.Events.Response;
using EventSphere.EventService.Domain.DTOs.EventSessions.Response;
using MediatR;
using System.Text.Json;
using System.Text.Json.Serialization;

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
                        Speaker = es.Speaker,
                        StartTime = es.StartTime,
                        Title = es.Title
                    })?.ToList()
                }).ToList();

                var jsonResponse = JsonSerializer.Serialize(new GetEventsResponse
                {
                    EventDtos = eventDtoList
                });

                return new DataResult<GetEventsResponse>(JsonSerializer.Deserialize<GetEventsResponse>(jsonResponse),
                  ResultStatus.Success, "Event detay listesi getirildi");
            }
            catch (Exception ex)
            {
                return new DataResult<GetEventsResponse>(null,
                               ResultStatus.Error, $"Event detay listesi getirilirken bir hata ile karşılaşıldı: {ex.Message}");
            }
        }
    }
}
