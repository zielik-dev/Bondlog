using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Admin
{
    public class UpdateUserAndRoleRepository : IUpdateUserAndRoleRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UpdateUserAndRoleRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> UpdateRoleAsync(UserAndRoleModel model)
        {
            return true;
        }
    }
}
