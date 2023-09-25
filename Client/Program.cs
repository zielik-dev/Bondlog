using Blazor.SubtleCrypto;
using Blazored.LocalStorage;
using Bondlog.Client;
using Bondlog.Client.Handlers;
using Bondlog.Client.Helper;
using Bondlog.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor;
using MudBlazor.Services;
using System.Reflection.Metadata;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Api", options =>
{
    options.BaseAddress = new Uri("https://localhost:7165/");
});/*.AddHttpMessageHandler<CustomHttpHandler>();*/

builder.Services.AddSubtleCrypto(options => options.Key = "abcMichal");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<IMudPopoverService, MudPopoverService>();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


await builder.Build().RunAsync();
