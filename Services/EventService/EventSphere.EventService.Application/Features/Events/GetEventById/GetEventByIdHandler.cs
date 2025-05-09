using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.DTOs.Events.Response;
using EventSphere.EventService.Domain.DTOs.EventSessions.Response;
using EventSphere.EventService.Domain.DTOs.Speakers.Response;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.GetEventById
{
    public class GetEventByIdHandler : IRequestHandler<GetEventByIdRequest, DataResult<GetEventByIdResponse>>
    {
        private readonly IEventReadRepository _eventReadRepository;

        public GetEventByIdHandler(IEventReadRepository eventReadRepository)
        {
            _eventReadRepository = eventReadRepository;
        }
        public async Task<DataResult<GetEventByIdResponse>> Handle(GetEventByIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var eventDetails = await _eventReadRepository.GetEventDetailsByIdAsync(request.EventId);

                if (eventDetails == null) 
                {
                    return new DataResult<GetEventByIdResponse>(null, ResultStatus.Error, $"Event bulunamadı");
                }

                var eventDto = new EventDto
                {
                    RecordId = eventDetails.RecordId,
                    Name = eventDetails.Name,
                    Description = eventDetails.Description,
                    StartDate = eventDetails.StartDate,
                    EndDate = eventDetails.EndDate,
                    Capacity = eventDetails.Capacity,
                    Location = eventDetails.Location,
                    Price = eventDetails.Price,
                    IsStockCreated = eventDetails.IsStockCreated,
                    EventSessionDtos = eventDetails.EventSessions?.ToList()
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
                };

                var res = new GetEventByIdResponse { EventDto = eventDto };

                return new DataResult<GetEventByIdResponse>(res, ResultStatus.Success, "Event detay getirildi");
            }
            catch (Exception ex)
            {
                return new DataResult<GetEventByIdResponse>(null, ResultStatus.Error, $"Event detay listesi getirilirken bir hata ile karşılaşıldı: {ex.Message}");
            }
        }
    }

}
