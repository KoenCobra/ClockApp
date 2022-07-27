using ClockApp;
using ClockApp.Sdk;
using ClockApp.Sdk.Abstractions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<IQuoteApi, QuoteApi>();
builder.Services.AddTransient<IWorldTimeApi, WorldTimeApi>();
builder.Services.AddTransient<IIpBaseApi, IpBaseApi>();

await builder.Build().RunAsync();
