using Bondlog.Shared.Domain.Models;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IUpdateUserAndRoleRepository
    {
        public Task<bool> UpdateRoleAsync(UserAndRoleModel model);
    }
}
