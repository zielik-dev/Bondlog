using Blazor.SubtleCrypto;
using Blazored.LocalStorage;
using Bondlog.Client.Helper;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Components.Authorization;
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
        private readonly ICryptoService _cryptoService;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, 
                           ILocalStorageService localStorageService, IHttpClientFactory httpClientFactory,
                           ICryptoService cryptoService)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorageService = localStorageService;
            _httpClientFactory = httpClientFactory;
            _cryptoService = cryptoService;
        }

        public async Task<UserSessionModel> Register(RegisterModel registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/registeruser", registerModel);
            var result = JsonSerializer.Deserialize<UserSessionModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }

        public async Task<UserSessionModel> Login (LoginModel loginModel)
        {
            //var loginAsJson = JsonSerializer.Serialize(loginModel);
            //var response = await _httpClient.PostAsync("api/loginuser", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            //var loginResult = JsonSerializer.Deserialize<UserSessionModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            
            var httpClient = _httpClientFactory.CreateClient();
            var user = await httpClient.PostAsJsonAsync("api/loginuser", loginModel);
            var response = await user.Content.ReadFromJsonAsync<UserSessionModel>();
    
            if (!response.Successful)
            {
                return response!;
            }

            if(response.Token is not null || response.Username is not null || response.UserRole is not null) 
            {
                //await _localStorageService.SetItemAsync("authToken", response!.Token);
                //((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginModel.Email);
                //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

                CryptoResult ecryptedUsername = await _cryptoService.EncryptAsync(response.Username);
                CryptoResult encryptUserRole = await _cryptoService.EncryptAsync(response.UserRole);
                var newEncryptedUserSession = new UserSessionModel() { Username = ecryptedUsername.Value, UserRole = encryptUserRole.Value, Token = response.Token, Successful = response.Successful };
                await _localStorageService.SetItemAsync("UserData", newEncryptedUserSession);
                (_authenticationStateProvider as CustomAuthenticationStateProvider).NotifyAuthenticationState();
            }
            else
            {

            }
        }

        public async Task Logout() 
        {
            await _localStorageService.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}