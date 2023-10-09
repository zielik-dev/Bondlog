using Bondlog.Client.Interfaces;
using Bondlog.Shared.Domain.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Bondlog.Client.Services.Admin
{
    public class RemoveUserAndRoleService : IRemoveUserAndRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RemoveUserAndRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<UserAndRoleModel>> DeleteUser(UserAndRoleModel userWithRole)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.DeleteFromJsonAsync<IEnumerable<UserAndRoleModel>>($"api/userandrole/{userWithRole.UserId}");

            if(response.Any())
            {
                return response;
            }
            else //tbc
            {
                //var errorMessage = await response.Content.ReadAsStringAsync();
                //throw new Exception($"Something when Wrong: {errorMessage}");
                return response; 
            }
        }
    }
}
