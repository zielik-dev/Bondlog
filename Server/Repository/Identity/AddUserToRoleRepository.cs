using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Identity
{
    public class AddUserToRoleRepository : IAddUserToRoleRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddUserToRoleRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddUserToRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.FindByNameAsync(userId);
            if (user == null)
                return false;

            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
                return false;

            var result = await _userManager.AddToRoleAsync(user, roleName);

            return result.Succeeded;
        }
    }
}