using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Admin
{
    public class AddRoleRepository : IAddRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> AddRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return false;

            if (await _roleManager.RoleExistsAsync(roleName))
                return false;

            var result = await _roleManager.CreateAsync(new IdentityRole { Name = roleName });

            return result.Succeeded;
        }
    }
}