using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IGetUsersAndRolesRepository
    {
        public Task<List<UserAndRoleModel>> GetUsersAndRoles();
    }
}
