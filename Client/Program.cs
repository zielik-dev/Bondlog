using Blazor.SubtleCrypto;
using Blazored.LocalStorage;
using Bondlog.Client;
using Bondlog.Client.Handlers;
using Bondlog.Client.Providers;
using Bondlog.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//Custom DI extension
builder.Services.ServiceDI();

builder.Services.AddHttpClient("MyApi", options =>
{
    options.BaseAddress = new Uri("https://localhost:7165/");
}).AddHttpMessageHandler<CustomHttpHandler>();

builder.Services.AddSubtleCrypto(options => options.Key = "ELE9xOyAyJHCsIPLMbbZHQ7pVy7WUlvZ60y5WkKDGMSw5xh5IM54kUPlycKmHF9VGtYUilglL8iePLwr");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<CustomHttpHandler>();

await builder.Build().RunAsync();
