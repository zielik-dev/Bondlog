using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Identity
{
    public class RemoveRoleRepository : IRemoveRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RemoveRoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> RemoveRoleAsync(string roleName)
        {
            if (string.IsNullOrEmpty(roleName))
                return false;

            var role = await _roleManager.FindByNameAsync(roleName);

            if(role == null) 
                return false;

            var result = await _roleManager.DeleteAsync(role);

            return result.Succeeded;
        }
    }
}