using Bondlog.Client.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class EditRoleService : IEditRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> EditRoleAsync(IdentityRole model)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.PutAsJsonAsync($"api/roles", model);

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
