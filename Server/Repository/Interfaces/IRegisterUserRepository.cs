using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Repository.Interfaces
{
    public interface IRegisterUserRepository
    {
        public Task<UserSessionModel> RegisterUserAsync(RegisterModel model);
    }
}
