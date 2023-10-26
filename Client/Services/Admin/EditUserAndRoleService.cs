using Bondlog.Client.Services.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class EditUserAndRoleService : IEditUserAndRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EditUserAndRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> EditUserAndRoleAsync(UserAndRoleModel model)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.PutAsJsonAsync($"api/userandrole", model);

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
