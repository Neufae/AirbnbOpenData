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

                var records = csv.GetRecords<RawRoomData>().Select(x =>
                    new RoomData()
                    {
                        id = x.id,
                        dataType = "Room",
                        name = x.name,
                        hostId = x.hostId,
                        hostIdentityVerified = x.hostIdentityVerified,
                        hostName = x.hostName,
                        neighbourhoodGroup = x.neighbourhoodGroup,
                        neighbourhood = x.neighbourhood,
                        lat = double.TryParse(x.lat, out double latResult) ? latResult : 0,
                        @long = double.TryParse(x.@long, out double longResult) ? longResult : 0,
                        country = x.country,
                        countryCode = x.countryCode,
                        instantBookable = bool.TryParse(x.instantBookable, out bool bookableResult) ? bookableResult : null,
                        cancellationPolicy = x.cancellationPolicy,
                        roomType = x.roomType,
                        constructionYear = int.TryParse(x.constructionYear, out int yearResult) ? yearResult : null,
                        price = double.TryParse(x.price, out double priceResult) ? priceResult : 0,
                        serviceFee = double.TryParse(x.serviceFee, out double serviceFeeResult) ? serviceFeeResult : 0,
                        minNights = int.TryParse(x.minNights, out int minNightResult) ? minNightResult : 0,
                        reviewCount = int.TryParse(x.reviewCount, out int reviewCountResult) ? reviewCountResult : 0,
                        lastReviewDate = DateTime.TryParse(x.lastReviewDate, out DateTime dateResult) ? dateResult : null,
                        reviewsPerMonth = double.TryParse(x.reviewsPerMonth, out double reviewsPerMonthResult) ? reviewsPerMonthResult : 0,
                        reviewRating = int.TryParse(x.reviewRating, out int reviewRatingResult) ? reviewRatingResult : 0,
                        hostListingCount = int.TryParse(x.hostListingCount, out int hostListingCountResult) ? hostListingCountResult : 0,
                        daysPerYearAvailable = int.TryParse(x.daysPerYearAvailable, out int daysPerYearAvailableResult) ? daysPerYearAvailableResult : 0,
                        roomRulesDescription = x.roomRulesDescription,
                        license = x.license
                    }
                )
                 .ToList();
                var top10Parsed = records.Take(10).ToList();

                // INSERT CODE HERE TO UPLOAD TO AWS
                // RoomData already knows to point to which dynamoDb by name: [DynamoDBTable("airbnb-open-data")]
                // I might have to create the table first with Id and dataType
                // You also need local credentials which are activated with an AWS command line
                // I might need to add Drew to my AWS account so he can get permissions
                // Program.cs has commented code for additional appsettings, but it's just Region setup as 'us-east-2' (but a good example of how to not publicly release your settings)

                int breakpoint = 1;
            }
            catch (Exception ex)
            {
                int otherBreakpoint = 1;
            }
        }
    }
}
