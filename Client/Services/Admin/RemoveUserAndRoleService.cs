﻿using Bondlog.Client.Services.Interfaces;
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

        public async Task<IEnumerable<UserAndRoleModel>> DeleteUserAndRoleAsync(string userId)
        {
            var httpClientFactory = _httpClientFactory.CreateClient("MyApi");
            //var response = await httpClientFactory.DeleteFromJsonAsync<IEnumerable<UserAndRoleModel>>($"api/userandrole/{userId}"); //? a moze jako parametr a w kontrolerze [FromBody]
            var response = await httpClientFactory.DeleteFromJsonAsync<IEnumerable<UserAndRoleModel>>("api/userandrole/" + userId);

            if (response.Any())
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
