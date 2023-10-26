using Bondlog.Client.Services.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class AddUserAndRoleService : IAddUserAndRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddUserAndRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> AddUserAndRoleAsync(UserAndRoleModel model)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.PostAsJsonAsync("api/roles", model);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return false;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error Response Content: " + errorContent);

                return false;
            }
        }
    }
}