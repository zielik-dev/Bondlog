namespace Bondlog.Server.Repository.Interfaces
{
    public interface IAddRoleRepository
    {
        public Task<bool> AddRoleAsync(string role);
    }
}