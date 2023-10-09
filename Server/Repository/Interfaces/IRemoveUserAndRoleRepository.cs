namespace Bondlog.Server.Repository.Interfaces
{
    public interface IRemoveUserAndRoleRepository
    {
        public Task<bool> RemoveUserAndRoleAsync(string userId, string roleName);
    }
}
