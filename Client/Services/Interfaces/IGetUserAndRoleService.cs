using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IGetUserAndRoleService
    {
        public Task<UserAndRoleModel> GetUserAndRoleByIdAsync(string userId);
    }
}
