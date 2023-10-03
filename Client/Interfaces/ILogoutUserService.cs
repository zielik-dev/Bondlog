using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Interfaces
{
    public interface ILogoutUserService
    {
        public Task LogoutUser();
    }
}