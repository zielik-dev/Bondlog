using Blazored.LocalStorage;
using Bondlog.Client.Interfaces;
using Bondlog.Client.Providers;
using Microsoft.AspNetCore.Components.Authorization;

namespace Bondlog.Client.Services
{
    public class LogoutUserService : ILogoutUserService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;
        
        public LogoutUserService(AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorageService)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
        }

        public async Task LogoutUser() 
        {
            await _localStorageService.RemoveItemAsync("UserData");
            var cs = (CustomAuthenticationStateProvider)_authenticationStateProvider;
            cs.NotifyAuthenticationState();
        }
    }
}