using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services
{
    public interface IAuthService
    {
        Task<UserSessionModel> Register(RegisterModel registerModel);
        Task<UserSessionModel> Login(LoginModel loginModel);
        Task Logout();
    }
}