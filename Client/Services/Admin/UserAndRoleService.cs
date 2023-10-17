using Bondlog.Client.Services.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class UserAndRoleService : IUserAndRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public UserAndRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task <UserAndRoleModel> GetUserAndRoleByIdAsync(string userId)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.GetFromJsonAsync<UserAndRoleModel>($"/api/userandrole/{userId}");
            return response;
        }
    }
}