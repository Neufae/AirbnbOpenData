using Amazon.DynamoDBv2;
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
//builder.Services.AddScoped<DebugService>();
builder.Services.AddScoped<RoomDataService>();

var app = builder.Build();

app.UseCors(options =>
    options
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()
);

//app.MapGet("/PopulateData", async (DebugService service) =>
//    {
//        await service.PopulateDataAsync();
//        return Results.Ok();
//    }
//);

app.MapGet("/GetAllRoomData", async (RoomDataService service) =>
    {
        var data = await service.GetAllRoomDataAsync();
        return Results.Json(data);
    }
);

app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();
app.UseStaticFiles();
app.UseRouting();

app.Run();
