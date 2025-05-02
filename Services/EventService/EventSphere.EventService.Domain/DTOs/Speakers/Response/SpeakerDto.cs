using EventSphere.EventService.Domain.Entities;

namespace EventSphere.EventService.Domain.DTOs.Speakers.Response
{
    public class SpeakerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
