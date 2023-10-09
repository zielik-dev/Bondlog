using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IGetUserRolesRepository
    {
        public Task<List<UserAndRoleModel>> GetUsersWithRoles();
    }
}
