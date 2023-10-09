using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Interfaces
{
    public interface IRemoveUserAndRoleService
    {
        public Task<IEnumerable<UserAndRoleModel>> DeleteUser(UserAndRoleModel userWithRole);
    }
}
