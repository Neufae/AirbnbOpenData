namespace AirbnbOpenData.Models
{
    public class RoomData
    {
        public long id { get; set; }
        public string dataType { get; set; }

        public string name { get; set; }
        public long hostId { get; set; }
        public string hostIdentityVerified { get; set; }
        public string hostName { get; set; }
        public string neighbourhoodGroup { get; set; }
        public string neighbourhood { get; set; }
        public double lat { get; set; }
        public double @long { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public bool? instantBookable { get; set; }
        public string cancellationPolicy { get; set; }
        public string roomType { get; set; }
        public int? constructionYear { get; set; }
        public double price { get; set; }
        public double serviceFee { get; set; }
        public int minNights { get; set; }
        public int reviewCount { get; set; }
        public DateTime? lastReviewDate { get; set; }
        public double reviewsPerMonth { get; set; }
        public int reviewRating { get; set; }
        public int hostListingCount { get; set; }
        public int daysPerYearAvailable { get; set; }
        public string roomRulesDescription { get; set; }
        public string license { get; set; }

    }
}
