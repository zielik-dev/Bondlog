using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IRemoveUserAndRoleService
    {
        public Task<IEnumerable<UserAndRoleModel>> DeleteUser(string userId);
    }
}
