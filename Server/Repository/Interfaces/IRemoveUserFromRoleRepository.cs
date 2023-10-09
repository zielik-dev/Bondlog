namespace Bondlog.Server.Repository.Interfaces
{
    public interface IRemoveUserFromRoleRepository
    {
        public Task<bool> RemoveUserFromRoleAsync(string userId, string roleName);
    }
}
