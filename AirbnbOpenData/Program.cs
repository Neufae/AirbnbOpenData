using AirbnbOpenData;
using AirbnbOpenData.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var backendClientName = builder.Configuration["BackendHttpClientName"];
var backendAddress = builder.Configuration["BackendAddress"];

if (backendClientName == null)
    throw new ArgumentNullException(nameof(backendClientName));

if (backendAddress == null)
    throw new ArgumentNullException(nameof(backendAddress));

// http clients
builder.Services.AddHttpClient();
builder.Services.AddHttpClient(backendClientName, client => client.BaseAddress = new Uri(backendAddress));
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// project services
builder.Services.AddScoped<BackendService>();

await builder.Build().RunAsync();
