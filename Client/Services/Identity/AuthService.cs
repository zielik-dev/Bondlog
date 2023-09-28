using Blazor.SubtleCrypto;
using Blazored.LocalStorage;
using Bondlog.Client.Interfaces;
using Bondlog.Client.Providers;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Bondlog.Client.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorageService;
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, 
                           ILocalStorageService localStorageService, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserSessionModel> RegisterUser(RegisterModel registerModel)
        {
            //var httpClient = httpClientFactory.CreateClient("MyApi");
            //var user = await httpClient.PostAsJsonAsync("api/user/register", registrationEntity);
            //var response = await user.Content.ReadFromJsonAsync<Response>();
            //return (response!);

            var response = await _httpClient.PostAsJsonAsync("api/registeruser", registerModel);
            var result = JsonSerializer.Deserialize<UserSessionModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }

        public async Task<UserSessionModel> LoginUser (LoginModel loginModel)
        {
            //var loginAsJson = JsonSerializer.Serialize(loginModel);
            //var response = await _httpClient.PostAsync("api/loginuser", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            //var loginResult = JsonSerializer.Deserialize<UserSessionModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            var httpClient = _httpClientFactory.CreateClient("MyApi");
            var user = await httpClient.PostAsJsonAsync("api/loginuser", loginModel);
            var response = await user.Content.ReadFromJsonAsync<UserSessionModel>();
    
            return response!;
        }

        public async Task LogoutUser() 
        {
            await _localStorageService.RemoveItemAsync("UserData");
            var cs = (CustomAuthenticationStateProvider)_authenticationStateProvider;
            cs.NotifyAuthenticationState();

            //await _localStorageService.RemoveItemAsync("authToken");
            //((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            //_httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}