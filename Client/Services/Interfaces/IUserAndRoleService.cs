using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IUserAndRoleService
    {
        public Task<UserAndRoleModel> GetUserAndRoleByIdAsync(string userId);
    }
}
