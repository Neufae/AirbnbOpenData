using Amazon.DynamoDBv2.DataModel;

namespace AirbnbOpenData.Models
{
    [DynamoDBTable("airbnb-open-data")]
    public class RoomData
    {
        [DynamoDBHashKey] public long id { get; set; }
        [DynamoDBRangeKey] public string dataType { get; set; }

        [DynamoDBProperty] public string name { get; set; }
        [DynamoDBProperty] public long hostId { get; set; }
        [DynamoDBProperty] public string hostIdentityVerified { get; set; }
        [DynamoDBProperty] public string hostName { get; set; }
        [DynamoDBProperty] public string neighbourhoodGroup { get; set; }
        [DynamoDBProperty] public string neighbourhood { get; set; }
        [DynamoDBProperty] public double lat { get; set; }
        [DynamoDBProperty] public double @long { get; set; }
        [DynamoDBProperty] public string country { get; set; }
        [DynamoDBProperty] public string countryCode { get; set; }
        [DynamoDBProperty] public bool? instantBookable { get; set; }
        [DynamoDBProperty] public string cancellationPolicy { get; set; }
        [DynamoDBProperty] public string roomType { get; set; }
        [DynamoDBProperty] public int? constructionYear { get; set; }
        [DynamoDBProperty] public double price { get; set; }
        [DynamoDBProperty] public double serviceFee { get; set; }
        [DynamoDBProperty] public int minNights { get; set; }
        [DynamoDBProperty] public int reviewCount { get; set; }
        [DynamoDBProperty] public DateTime? lastReviewDate { get; set; }
        [DynamoDBProperty] public double reviewsPerMonth { get; set; }
        [DynamoDBProperty] public int reviewRating { get; set; }
        [DynamoDBProperty] public int hostListingCount { get; set; }
        [DynamoDBProperty] public int daysPerYearAvailable { get; set; }
        [DynamoDBProperty] public string roomRulesDescription { get; set; }
        [DynamoDBProperty] public string license { get; set; }

    }
}
