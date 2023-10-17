using Bondlog.Client.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class RemoveRoleService : IRemoveRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RemoveRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;    
        }

        public async Task<IEnumerable<IdentityRole>> DeleteRoleAsync(string roleName)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.DeleteFromJsonAsync<IEnumerable<IdentityRole>>("api/roles/" + roleName);

            if (response.Any())
            {
                return response;
            }
            else
            {
                return response;
            }
        }
    }
}
