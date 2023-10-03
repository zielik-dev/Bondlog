using Bondlog.Client.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace Bondlog.Client.Services.Identity
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly HttpClient _httpClient;

        public RegisterUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UserSessionModel> RegisterUser(RegisterModel registerModel)
        {
            var response = await _httpClient.PostAsJsonAsync("api/registeruser", registerModel);
            var result = JsonSerializer.Deserialize<UserSessionModel>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }
    }
}