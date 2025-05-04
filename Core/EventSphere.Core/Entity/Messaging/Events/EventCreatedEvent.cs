using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSphere.Core.Entity.Messaging.Events
{
    public class EventCreatedEvent
    {
        public int EventId { get; set; }
        public int Capacity { get; set; }
    }
}
