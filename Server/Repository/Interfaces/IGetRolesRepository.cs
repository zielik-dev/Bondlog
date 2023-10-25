using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IGetRolesRepository
    {
        public Task<IEnumerable<IdentityRole>> GetRolesAsync();
    }
}
