using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Interfaces
{
    public interface ILoginUserService
    {
        public Task<UserSessionModel> LoginUser(LoginModel loginModel);
    }
}
