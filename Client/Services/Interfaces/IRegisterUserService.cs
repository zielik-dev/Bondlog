using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Services.Interfaces
{
    public interface IRegisterUserService
    {
        public Task<UserSessionModel> RegisterUser(RegisterModel registerModel);
    }
}