using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IAddRoleService
    {
        public Task<IdentityRole> AddRoleAsync(string roleName);
        public Task AddRole(string roleName);
        public Task<IEnumerable<IdentityRole>> AddRolePost(string roleName);
        public Task AddRolePostVoid(string roleName);
    }
}
