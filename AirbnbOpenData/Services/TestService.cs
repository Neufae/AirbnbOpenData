using AirbnbOpenData.Models;
using CsvHelper;
using System.Globalization;

namespace AirbnbOpenData.Services
{
    public class TestService
    {
        public void Run()
        {
            using var reader = new StreamReader("data/Airbnb_Open_Data.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            var records = csv.GetRecords<RawRoomData>().ToList();

            int breakpoint = 1;
        }
    }
}
