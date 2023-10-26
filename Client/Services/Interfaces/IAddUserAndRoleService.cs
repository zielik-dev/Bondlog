using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IAddUserAndRoleService
    {
        public Task<bool> AddUserAndRoleAsync(UserAndRoleModel model);
    }
}
