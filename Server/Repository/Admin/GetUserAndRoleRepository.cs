using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Admin
{
    public class GetUserAndRoleRepository : IGetUserAndRoleRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetUserAndRoleRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserSessionModel> GetUserAndRoleByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
                return null;

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault();

            if (role == null)
                return null;

            UserSessionModel usm = new UserSessionModel()
            {
                Successful = true,
                Username = user.UserName,
                UserRole = role,
            };

            return usm;
        }
    }
}