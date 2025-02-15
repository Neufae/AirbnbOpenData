using AirbnbOpenData.Models;
using CsvHelper;
using System.Globalization;

namespace AirbnbOpenData.Services
{
    public class TestService
    {
        private readonly HttpClient _httpClient;
        public TestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task RunAsync()
        {
            var csvData = await _httpClient.GetStringAsync("data/Airbnb_Open_Data.csv");
            using var reader = new StringReader(csvData);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<RawRoomData>().ToList();

            int breakpoint = 1;
        }
    }
}
