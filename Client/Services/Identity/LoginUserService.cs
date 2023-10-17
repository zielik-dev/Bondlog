using Bondlog.Shared.Domain.Models;
using System.Net.Http.Json;
using System.Net.Http;
using Bondlog.Client.Services.Interfaces;

namespace Bondlog.Client.Services.Identity
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginUserService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<UserSessionModel> LoginUser(LoginModel loginModel)
        {
            var httpClient = _httpClientFactory.CreateClient("MyApi");
            var user = await httpClient.PostAsJsonAsync("api/loginuser", loginModel);
            var response = await user.Content.ReadFromJsonAsync<UserSessionModel>();

            return response!;
        }
    }
}
