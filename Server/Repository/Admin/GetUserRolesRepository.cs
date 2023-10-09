using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bondlog.Server.Repository.Admin
{
    public class GetUserRolesRepository : IGetUserRolesRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public GetUserRolesRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<UserAndRoleModel>> GetUsersWithRoles()
        {
            var usersWithRoles = new List<UserAndRoleModel>();

            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var roleName = roles.FirstOrDefault();

                var userWithRole = new UserAndRoleModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    RoleName = roleName
                };

                usersWithRoles.Add(userWithRole);
            }

            return usersWithRoles;

        }
    }
}