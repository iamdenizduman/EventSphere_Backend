using EventSphere.EventService.Application.Repositories;
using MediatR;

namespace EventSphere.EventService.Application.Features.Events.GetEventPriceById
{
    public class GetEventPriceByIdHandler : IRequestHandler<GetEventPriceByIdRequest, GetEventPriceByIdResponse>
    {
        private readonly IEventReadRepository _eventReadRepository;

        public GetEventPriceByIdHandler(IEventReadRepository eventReadRepository)
        {
            _eventReadRepository = eventReadRepository;
        }

        public async Task<GetEventPriceByIdResponse> Handle(GetEventPriceByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _eventReadRepository.GetSingleAsync(e => e.RecordId == request.Id);

            var res = new GetEventPriceByIdResponse
            {
                Id = entity.RecordId,
                Price = entity.Price,
                Name = entity.Name
            };

            return res;
        }
    }
}
