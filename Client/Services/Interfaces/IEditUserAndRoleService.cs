using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IEditUserAndRoleService
    {
        public Task<bool> EditUserAndRoleAsync(UserAndRoleModel model);
    }
}
