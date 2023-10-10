using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Admin
{
    public class RemoveUserAndRoleRepository : IRemoveUserAndRoleRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RemoveUserAndRoleRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> RemoveUserAndRoleAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return false;

            var userRoles = await _userManager.GetRolesAsync(user);

            var roleName = "";
            if (userRoles.Any())
            {
                roleName = userRoles.FirstOrDefault();
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExists)
                return false;

            var result = await _userManager.DeleteAsync(user);

            return result.Succeeded;
        }
    }
}
