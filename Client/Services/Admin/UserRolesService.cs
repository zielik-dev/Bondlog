using Bondlog.Client.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserRolesService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<UserAndRoleModel>> GetUserRolesAsync()
        {
            var httpClientFactort = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactort.GetFromJsonAsync<IEnumerable<UserAndRoleModel>>("api/userandrole");
            return response;
        }
    }
}
