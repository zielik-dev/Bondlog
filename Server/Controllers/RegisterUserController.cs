using Bondlog.Server.Repository.Identity;
using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Route("api/[controller]"), Authorize]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegisterUserRepository _registerUserRepository;

        public RegisterUserController(IRegisterUserRepository registerUserRepository)
        {
            _registerUserRepository = registerUserRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var userSession = await _registerUserRepository.RegisterUserAsync(model);

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