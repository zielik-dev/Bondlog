using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bondlog.Server.Repository.Admin
{
    public class GetRolesRepository : IGetRolesRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public GetRolesRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<IdentityRole>> GetRoles() => await _roleManager.Roles.ToListAsync();
    }
}