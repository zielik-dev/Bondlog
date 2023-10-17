using Bondlog.Client.Services.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class UsersAndRolesService : IUsersAndRolesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UsersAndRolesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<UserAndRoleModel>> GetUsersAndRolesAsync()
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.GetFromJsonAsync<IEnumerable<UserAndRoleModel>>("api/userandrole");
            return response;
        }
    }
}