using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IUsersAndRolesService
    {
        public Task<IEnumerable<UserAndRoleModel>> GetUsersAndRolesAsync();
    }
}
