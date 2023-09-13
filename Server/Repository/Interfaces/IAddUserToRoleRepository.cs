namespace Bondlog.Server.Repository.Interfaces
{
    public interface IAddUserToRoleRepository
    {
        public Task<bool> AddUserToRoleAsync(string userId, string roleName);
    }
}
