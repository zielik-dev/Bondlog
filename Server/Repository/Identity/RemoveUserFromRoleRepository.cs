using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Identity
{
    public class RemoveUserFromRoleRepository : IRemoveUserFromRoleRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RemoveUserFromRoleRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RemoveUserFromRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
                return false;

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            return result.Succeeded;
        }
    }
}