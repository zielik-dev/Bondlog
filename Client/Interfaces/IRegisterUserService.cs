using Bondlog.Shared.Domain.Models;

namespace Bondlog.Client.Interfaces
{
    public interface IRegisterUserService
    {
        public Task<UserSessionModel> RegisterUser(RegisterModel registerModel);
    }
}