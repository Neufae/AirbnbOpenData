using Amazon.DynamoDBv2.DataModel;

namespace AirbnbOpenData.Models
{
    [DynamoDBTable("airbnb-open-data")]
    public class RoomData
    {
        [DynamoDBHashKey] public string id { get; set; }
        [DynamoDBRangeKey] public string moduleType { get; set; }
        //id,
        //NAME,
        //host id,
        //host_identity_verified,
        //host name,
        //neighbourhood group,
        //neighbourhood,
        //lat,
        //long,
        //country,
        //country code,
        //instant_bookable,
        //cancellation_policy,
        //room type,
        //Construction year,
        //price,
        //service fee,
        //minimum nights,
        //number of reviews,
        //last review,
        //reviews per month,
        //review rate number,
        //calculated host listings count,
        //availability 365,
        //house_rules,
        //license

        [DynamoDBProperty] public string subType { get; set; }
        [DynamoDBProperty] public int sortOrder { get; set; }
    }
}
