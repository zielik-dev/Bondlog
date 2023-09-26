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

        //[HttpPost("login")]
        [HttpPost]
        public async Task<IActionResult> Login (LoginModel loginModel)
        {
            var userSession = await _loginUserRepository.LoginUserAsync(loginModel);

            if (userSession.Successful)
            {
                //return Ok(new {token = userSession.Token});
                return Ok(userSession);
            }
            else
            {
                return Unauthorized();
            }
        }



        /*
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginUserController(IConfiguration configuration, SignInManager<IdentityUser> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }
        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Password!, false, false);

            if(!result.Succeeded)
            {
                return BadRequest(new LoginResultModel { Successful = false, Error = "Username and password are invalid." });
            }

            //names swaps
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Email!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
                );

            return Ok(new LoginResultModel { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }*/
    }
}
