﻿using Bondlog.Client.Services.Interfaces;
using System.Net;

namespace Bondlog.Client.Services.Admin
{
    public class RemoveRoleService : IRemoveRoleService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RemoveRoleService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;    
        }

        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            var response = await httpClientFactory.DeleteAsync("api/roles/" + roleName);

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