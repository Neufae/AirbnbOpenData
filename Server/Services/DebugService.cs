using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CsvHelper;
using Server.Models;
using System.Globalization;
using System.Reflection;

namespace Server.Services
{
    public class DebugService
    {
        private readonly DynamoDBContext _context;
        public DebugService()
        {
            _context = new DynamoDBContext(new AmazonDynamoDBClient());
        }
        public async Task PopulateDataAsync()
        {
            try
            {
                using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Server.Airbnb_Open_Data.csv")
                    ?? throw new NullReferenceException($"failed to load resource stream");
                using var reader = new StreamReader(stream);
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
                        price = double.TryParse(x.price.TrimStart('$'), out double priceResult) ? priceResult : 0,
                        serviceFee = double.TryParse(x.serviceFee.TrimStart('$'), out double serviceFeeResult) ? serviceFeeResult : 0,
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
                //var top10Parsed = records.Take(10).ToList();

                var batchWrite = _context.CreateBatchWrite<RoomData>();
                batchWrite.AddPutItems(records);
                await batchWrite.ExecuteAsync();

                int breakpoint = 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
