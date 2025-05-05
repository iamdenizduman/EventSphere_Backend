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
        private readonly JsonSerializerOptions _jsonOptions;

        public EventServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase // Camel case özelliği ekleniyor
            };
        }

        public async Task<EventPriceDto> GetEventPriceById(int eventId)
        {
            var requestPayload = new
            {
                Id = eventId
            };

            var content = new StringContent(JsonSerializer.Serialize(requestPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/api/Events/GetEventPriceById", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<EventPriceDto>(responseContent, _jsonOptions);
        }
    }
}
