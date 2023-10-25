using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IEditRoleService
    {
        public Task<bool> EditRoleAsync(IdentityRole model);
    }
}
