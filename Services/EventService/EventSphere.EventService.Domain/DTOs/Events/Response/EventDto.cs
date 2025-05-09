﻿using EventSphere.EventService.Domain.DTOs.EventSessions.Response;

namespace EventSphere.EventService.Domain.DTOs.Events.Response
{
    public class EventDto
    {
        public int RecordId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public bool IsStockCreated { get; set; }
        public List<EventSessionDto>? EventSessionDtos { get; set; }
    }
}
