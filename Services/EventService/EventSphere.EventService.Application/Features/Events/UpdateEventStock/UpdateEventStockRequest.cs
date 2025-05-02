using EventSphere.Core.Result;
using EventSphere.EventService.Application.Features.Events.CreateEvent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.EventService.Application.Features.Events.UpdateEventStock
{
    public class UpdateEventStockRequest : IRequest<DataResult<UpdateEventStockResponse>>
    {
        public int EventId { get; set; }
    }
}
