using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Client.Interfaces
{
    public interface IUserRolesService
    {
        public Task<IEnumerable<UserWithRole>> GetUserRolesAsync();
    }
}
