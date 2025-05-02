using EventSphere.Core.Enums;
using EventSphere.Core.Result;
using EventSphere.EventService.Application.Repositories;
using EventSphere.EventService.Domain.Entities;
using MediatR;

namespace EventSphere.EventService.Application.Features.Speaker.CreateSpeaker
{
    public class CreateSpeakerHandler : IRequestHandler<CreateSpeakerRequest, DataResult<CreateSpeakerResponse>>
    {
        private readonly ISpeakerWriteRepository _speakerWriteRepository;

        public CreateSpeakerHandler(ISpeakerWriteRepository speakerWriteRepository)
        {
            _speakerWriteRepository = speakerWriteRepository;
        }

        public async Task<DataResult<CreateSpeakerResponse>> Handle(CreateSpeakerRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Speaker speaker = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Bio = request.Bio,
                ProfilePictureUrl = request.ProfilePictureUrl,
                CreatedDate = DateTime.UtcNow
            };

            await _speakerWriteRepository.AddAsync(speaker);
            var saveChangesCount = await _speakerWriteRepository.SaveChangesAsync();

            CreateSpeakerResponse response = new CreateSpeakerResponse()
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            if (saveChangesCount == 0)
            {
                return new DataResult<CreateSpeakerResponse>(response, ResultStatus.Error, "Konuşmacı eklenirken hata meydana geldi");
            }

            return new DataResult<CreateSpeakerResponse>(response, ResultStatus.Success, "Konuşmacı başarıyla eklendi");
        }
    }
}
