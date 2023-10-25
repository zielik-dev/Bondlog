using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Bondlog.Server.Repository.Admin
{
    public class UpdateRoleRepository : IUpdateRoleRepository
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UpdateRoleRepository(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<bool> UpdateRoleAsync(IdentityRole model)
        {
            if (model is null)
                return false;

            var role = await _roleManager.FindByIdAsync(model.Id);

            if (role is null)
                return false;

            role.Name = model.Name;

            var result = await _roleManager.UpdateAsync(role);

            return result.Succeeded;
        }
    }
}
