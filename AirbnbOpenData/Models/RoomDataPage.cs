namespace AirbnbOpenData.Models
{
    public class RoomDataPage
    {
        public List<RoomData> Data { get; set; } = [];
        public string? NextToken { get; set; } = null;
    }
}
