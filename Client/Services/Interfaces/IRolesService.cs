using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IRolesService
    {
        public Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
