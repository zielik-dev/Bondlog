using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface ILoginUserService
    {
        public Task<UserSessionModel> LoginUser(LoginModel loginModel);
    }
}
