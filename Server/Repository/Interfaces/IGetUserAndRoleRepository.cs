using Bondlog.Shared.Domain.Models;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IGetUserAndRoleRepository
    {
        public Task<UserSessionModel> GetUserAndRoleByIdAsync(string userId);
    }
}