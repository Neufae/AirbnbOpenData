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
            try
            {
                var csvStream = await _httpClient.GetStreamAsync("data/Airbnb_Open_Data.csv");
                using var reader = new StreamReader(csvStream);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<RawRoomData>().ToList();
                var top10 = records.Take(10).ToList();

                int breakpoint = 1;
            }
            catch (Exception ex)
            {
                int otherBreakpoint = 1;
            }
        }
    }
}
