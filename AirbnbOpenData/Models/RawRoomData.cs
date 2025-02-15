using CsvHelper.Configuration.Attributes;

namespace AirbnbOpenData.Models
{
    public class RawRoomData
    {
        [Name("id")] public long id { get; set; }
        [Name("NAME")] public string name { get; set; }
        [Name("host id")] public long hostId { get; set; }
        [Name("host_identity_verified")] public string hostIdentityVerified { get; set; }
        [Name("host name")] public string hostName { get; set; }
        [Name("neighbourhood group")] public string neighbourhoodGroup { get; set; }
        [Name("neighbourhood")] public string neighbourhood { get; set; }
        [Name("lat")] public string lat { get; set; } // should be double
        [Name("long")] public string @long { get; set; } // should be double
        [Name("country")] public string country { get; set; }
        [Name("country code")] public string countryCode { get; set; }
        [Name("instant_bookable")] public string instantBookable { get; set; } // should be bool
        [Name("cancellation_policy")] public string cancellationPolicy { get; set; }
        [Name("room type")] public string roomType { get; set; }
        [Name("Construction year")] public string constructionYear { get; set; } // should be int
        [Name("price")] public string price { get; set; } // should be int or double
        [Name("service fee")] public string serviceFee { get; set; } // should be int or double
        [Name("minimum nights")] public string minNights { get; set; } // should be int
        [Name("number of reviews")] public string reviewCount { get; set; } // should be int
        [Name("last review")] public string lastReviewDate { get; set; } // should be DateTime
        [Name("reviews per month")] public string reviewsPerMonth { get; set; } // should be double
        [Name("review rate number")] public string reviewRating { get; set; } // should be int
        [Name("calculated host listings count")] public string hostListingCount { get; set; } // should be int
        [Name("availability 365")] public string daysPerYearAvailable { get; set; } // should be int
        [Name("house_rules")] public string roomRulesDescription { get; set; }
        [Name("license")] public string license { get; set; }

    }
}
