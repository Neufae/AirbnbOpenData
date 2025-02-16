using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Server.Models;

namespace Server.Services
{
    public class RoomDataService
    {
        private readonly DynamoDBContext _context;
        public RoomDataService()
        {
            _context = new DynamoDBContext(new AmazonDynamoDBClient());
        }
        public async Task<List<RoomData>> GetAllRoomDataAsync()
        {
            var scanResult = await _context.ScanAsync<RoomData>([]).GetRemainingAsync();
            return scanResult;
        }
    }
}
