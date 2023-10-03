using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Interfaces
{
    public interface IRolesService
    {
        public Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
