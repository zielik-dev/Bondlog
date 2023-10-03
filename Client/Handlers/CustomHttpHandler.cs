using Blazored.LocalStorage;
using Bondlog.Shared.Domain.Models;
using Microsoft.JSInterop;

namespace Bondlog.Client.Handlers
{
    public class CustomHttpHandler : DelegatingHandler
    {
        private readonly ILocalStorageService localStorageService;
        private readonly IJSRuntime jsRuntime;

        public CustomHttpHandler(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;
            this.jsRuntime = jsRuntime;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri!.AbsolutePath.ToLower().Contains("login") || request.RequestUri!.AbsolutePath.ToLower().Contains("register"))
                return await base.SendAsync(request, cancellationToken);

            var token = await localStorageService.GetItemAsync<UserSessionModel>("UserData", cancellationToken = default);
            if (token.Token is not null)
            {
                request.Headers.Add("Authorization", $"Bearer {token.Token}");
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
