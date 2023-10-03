using Bondlog.Client.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Json;

namespace Bondlog.Client.Services
{
    public class RolesService : IRolesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RolesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<IdentityRole>> GetRolesAsync()
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.GetFromJsonAsync<IEnumerable<IdentityRole>>("api/roles");
            return response;
        }
    }
}