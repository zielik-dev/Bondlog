using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IGetRolesService
    {
        public Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
