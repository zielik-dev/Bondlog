using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IGetUsersAndRolesService
    {
        public Task<IEnumerable<UserAndRoleModel>> GetUsersAndRolesAsync();
    }
}
