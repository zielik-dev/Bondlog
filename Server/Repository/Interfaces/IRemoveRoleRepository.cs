namespace Bondlog.Server.Repository.Interfaces
{
    public interface IRemoveRoleRepository
    {
        public Task<bool> RemoveRoleAsync(string roleName);
    }
}
