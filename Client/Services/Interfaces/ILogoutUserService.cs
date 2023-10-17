using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface ILogoutUserService
    {
        public Task LogoutUser();
    }
}