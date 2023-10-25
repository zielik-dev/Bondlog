using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IUpdateRoleRepository
    {
        public Task<bool> UpdateRoleAsync(IdentityRole model);
    }
}
