using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services
{
    public interface IAuthService
    {
        Task<UserSessionModel> RegisterUser(RegisterModel registerModel);
        Task<UserSessionModel> LoginUser(LoginModel loginModel);
        Task LogoutUser();
    }
}