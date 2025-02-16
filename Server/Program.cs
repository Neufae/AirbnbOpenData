using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
builder.Services.AddCors();

// configuration
builder.Configuration.AddSystemsManager(builder.Configuration["AWS:ConfigPath"]);

// aws services
builder.Services.AddAWSService<IAmazonDynamoDB>();

// msft services
builder.Services.AddHttpContextAccessor();

// project services
builder.Services.AddScoped<DebugService>();
builder.Services.AddScoped<RoomDataService>();

var app = builder.Build();

app.UseCors(options =>
    options
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()
);

app.MapGet("/PopulateData", async (DebugService service) =>
    {
        await service.PopulateDataAsync();
        return Results.Ok();
    }
);

app.MapGet("/GetAllRoomData", async (RoomDataService service) =>
    {
        var data = await service.GetAllRoomDataAsync();
        return Results.Json(data);
    }
);

app.MapGet("/GetRoomDataPage", async (RoomDataService service, string? nextToken, int pageSize = 20) =>
    {
        var result = await service.GetRoomDataPaginatedAsync(nextToken, pageSize);
        //return Results.Json(data);
        return Results.Ok(new
        {
            Data = result.Data,
            NextToken = result.NextToken
        });
    }
);

app.MapGet("/GetRoomDataCount", async (RoomDataService service) =>
    {
        var result = await service.GetItemCountWithParallelScanAsync(1000);
        return Results.Json(result);
    }
);

app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
app.UseStaticFiles();
app.UseRouting();

app.Run();
