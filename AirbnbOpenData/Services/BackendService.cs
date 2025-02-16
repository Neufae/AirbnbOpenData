using AirbnbOpenData.Models;
using System.Net.Http.Json;

namespace AirbnbOpenData.Services
{
    public class BackendService
    {
        private readonly HttpClient _httpClient;
        public BackendService(IConfiguration configuration, IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient(configuration["BackendHttpClientName"] ?? "");
        }

        public async Task<List<RoomData>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("/GetAllRoomData");
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<List<RoomData>>() ?? [];
            return results;
        }

        public async Task<int> GetCountAsync()
        {
            var response = await _httpClient.GetAsync("/GetRoomDataCount");
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<int>();
            return results;
        }

        public async Task<RoomDataPage> GetPageAsync(string? nextToken = null, int pageSize = 20)
        {
            var path = $"/GetRoomDataPage?pageSize={pageSize}";
            if (nextToken != null)
                path += $"&nextToken={nextToken}";
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var results = await response.Content.ReadFromJsonAsync<RoomDataPage>();
            return results;
        }

        public async Task RunTestAsync()
        {
            Console.WriteLine("It's running!");
        }
    }
}