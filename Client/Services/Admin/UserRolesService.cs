using Bondlog.Client.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bondlog.Client.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserRolesService(HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<IdentityRole>> GetUserRolesAsync()
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.GetFromJsonAsync<IEnumerable<IdentityRole>>("api/roles");
            return response;
        }
    }
}
