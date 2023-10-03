using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bondlog.Shared.Helpers;
using Bondlog.Server.Repository.Interfaces;

namespace Bondlog.Server.Repository.Identity
{
    public class LoginUserRepository : ILoginUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginUserRepository(IConfiguration configuration,
                                   SignInManager<IdentityUser> signInManager,
                                   UserManager<IdentityUser> userManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<UserSessionModel> LoginUserAsync(LoginModel loginModel)
        {
            string jwtSecurityKey = "JwtSecurityKey";
            string jwtExpiryInDays = "JwtExpiryInDays";
            string jwtIssuer = "JwtIssuer";
            string jwtAudience = "JwtAudience";

            //model validation
            if (string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.Password))
                return new UserSessionModel { Successful = false, ErrorMessage = "Email and password are required." };

            //model email format validation
            if (!InputEmailValidation.IsValidEmailFormat(loginModel.Email))
                return new UserSessionModel { Successful = false, ErrorMessage = "Invalid email format." };

            //db email validation
            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if (user == null)
                return new UserSessionModel { Successful = false, ErrorMessage = "User not found." };

            //password validation
            var passwordValid = await _userManager.CheckPasswordAsync(user, loginModel.Password);

            if (!passwordValid)
                return new UserSessionModel { Successful = false, ErrorMessage = "Invalid password." };

            //sign In
            var signInResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);

            if (!signInResult.Succeeded)
                return new UserSessionModel { Successful = false, ErrorMessage = "Invalid password." };

            //db user role fetch
            var userRoles = await _userManager.GetRolesAsync(user);
            if (!userRoles.Any())
                return new UserSessionModel { Successful = false, ErrorMessage = "No roles assigned" };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[jwtSecurityKey]!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, loginModel.Email),
                new Claim(ClaimTypes.Role, userRoles.FirstOrDefault())
            });

            var tokenExpiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration[jwtExpiryInDays]));

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Issuer = _configuration[jwtIssuer],
                Audience = _configuration[jwtAudience],
                Expires = tokenExpiry,
                SigningCredentials = signingCredentials,
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtTokenHandler.WriteToken(securityToken);

            return new UserSessionModel()
            {
                Username = loginModel.Email,
                UserRole = userRoles.FirstOrDefault(),
                Token = token,
                Successful = true,
            };
        }
    }
}