using EventSphere.Core.Result;
using EventSphere.EventService.Application.Features.Events.CreateEvent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.EventService.Application.Features.Speaker.CreateSpeaker
{
    public class CreateSpeakerRequest : IRequest<DataResult<CreateSpeakerResponse>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
