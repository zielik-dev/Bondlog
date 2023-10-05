using Bondlog.Client.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;

namespace Bondlog.Client.Services.Identity
{
    public class RegisterUserService : IRegisterUserService
    {
        //private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public RegisterUserService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            //_httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserSessionModel> RegisterUser(RegisterModel registerModel)
        {
            var httpClient = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClient.PostAsJsonAsync("api/registeruser", registerModel);
            var result = JsonSerializer.Deserialize<UserSessionModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }
    }
}