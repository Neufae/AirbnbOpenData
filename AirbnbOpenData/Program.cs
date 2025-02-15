using AirbnbOpenData;
using AirbnbOpenData.Services;
using Amazon.DynamoDBv2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// configuration
//builder.Configuration.AddSystemsManager(builder.Configuration["AWS:ConfigPath"]);

// aws services
//builder.Services.AddAWSService<IAmazonDynamoDB>();

// project services
builder.Services.AddScoped<TestService>();

await builder.Build().RunAsync();
