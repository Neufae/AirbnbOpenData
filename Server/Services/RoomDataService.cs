using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Server.Models;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;

namespace Server.Services
{
    public class RoomDataService
    {
        private readonly AmazonDynamoDBClient _client;
        private readonly DynamoDBContext _context;
        public RoomDataService()
        {
            _client = new AmazonDynamoDBClient();
            _context = new DynamoDBContext(_client);
        }
        public async Task<List<RoomData>> GetAllRoomDataAsync()
        {
            var scanResult = await _context.ScanAsync<RoomData>([]).GetRemainingAsync();
            return scanResult;
        }

        public async Task<(List<RoomData> Data, string NextToken)> GetRoomDataPaginatedAsync(string? nextToken = null, int pageSize = 20)
        {
            var scanConfig = new ScanOperationConfig
            {
                Limit = pageSize,
                PaginationToken = nextToken
            };

            var search = _context.FromScanAsync<RoomData>(scanConfig);
            var data = await search.GetNextSetAsync();
            return (data, search.PaginationToken);
        }

        public async Task<int> GetItemCountWithParallelScanAsync(int totalSegments)
        {
            var tasks = new List<Task<int>>();
            for (int i = 0; i < totalSegments; i++)
            {
                int segmentIndex = i;
                tasks.Add(Task.Run(async () =>
                {
                    int count = 0;
                    string? lastEvaluatedKey = null;
                    do
                    {
                        var scanRequest = new ScanRequest
                        {
                            TableName = "airbnb-open-data",
                            Segment = segmentIndex,
                            TotalSegments = totalSegments,
                            ExclusiveStartKey = string.IsNullOrEmpty(lastEvaluatedKey) ? null : new Dictionary<string, AttributeValue> { { "Id", new AttributeValue { S = lastEvaluatedKey } } }
                        };

                        var response = await _client.ScanAsync(scanRequest);
                        count += response.Items.Count;

                        lastEvaluatedKey =
                            response.LastEvaluatedKey?.ContainsKey("Id") == true
                                ? response.LastEvaluatedKey["Id"].S
                                : null;

                    } while (lastEvaluatedKey != null);

                    return count;
                }));
            }

            var results = await Task.WhenAll(tasks);
            return results.Sum();
        }
    }
}
