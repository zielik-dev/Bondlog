using Bondlog.Shared.Domain.Models;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface ILoginUserRepository
    {
        public Task<UserSessionModel> LoginUserAsync(LoginModel loginModel);
    }
}
