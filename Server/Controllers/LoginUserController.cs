using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly ILoginUserRepository _loginUserRepository;

        public LoginUserController(ILoginUserRepository loginUserRepository)
        {
            _loginUserRepository = loginUserRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginModel loginModel)
        {
            var userSession = await _loginUserRepository.LoginUserAsync(loginModel);

            if (userSession.Successful)
            {
                return Ok(userSession);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}