using EventSphere.OrderService.Application.Dtos.Events;
using EventSphere.OrderService.Application.Interfaces.External;
using MongoDB.Bson.IO;
using System.Text;
using System.Text.Json;

namespace EventSphere.OrderService.Infrastructure.External.Services
{
    public class EventServiceClient : IEventServiceClient
    {
        private readonly HttpClient _httpClient;

        public async Task<EventPriceDto> GetEventPriceById(long eventId)
        {
            var requestPayload = new
            {
                EventId = eventId
            };

            var content = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Events/GetEventPriceById", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EventPriceDto>(responseContent);
        }
    }
}
