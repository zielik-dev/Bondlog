using Bondlog.Client.Services.Interfaces;
using System.Net.Http.Json;
using System.Net;

namespace Bondlog.Client.Services.Admin
{
    public class AddRoleService : IAddRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AddRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> AddRoleAsync(string roleName)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.PostAsJsonAsync("api/roles", roleName);
            
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

        //public async Task AddRole(string roleName)
        //{
        //    var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
        //    var requestUri = $"api/roles/{roleName}";

        //    var role = new { RoleName = roleName };

        //    var content = new StringContent(JsonSerializer.Serialize(role), Encoding.UTF8, "application/json");

        //    var response = await httpClientFactory.PostAsync(requestUri, content);

        //    response.EnsureSuccessStatusCode();
        //}

        //public async Task AddRolePostVoid(string roleName)  //dziala
        //{
        //    var httpClient = _httpClientFactory.CreateClient("MyApi");
        //    var response = await httpClient.PostAsJsonAsync("api/roles", roleName);
        //}

        //public async Task<IEnumerable<IdentityRole>> AddRolePost(string roleName)
        //{
        //    var httpClient = _httpClientFactory.CreateClient("MyApi");
        //    var response = await httpClient.PostAsJsonAsync("api/roles", roleName);
        //    var result = JsonSerializer.Deserialize<IEnumerable<IdentityRole>>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        //    return result;
        //}
    }
}