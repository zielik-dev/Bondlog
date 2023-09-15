using Bondlog.Server.Infrastructure.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    //[Authorize(Roles = "Admin, Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IApplicationDbContext _dbContext;

        public RegisterUserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
            var roleExists = _roleManager.RoleExistsAsync(model.UserRole).GetAwaiter().GetResult(); //do obrobki

            var result = await _userManager.CreateAsync(newUser, model.Password!);

            if (!result.Succeeded)
            {
                return Ok(new UserSessionModel
                {
                    Successful = false,
                    ErrorMessage = string.Join(' ', result.Errors.Select(e => e.Description))
                });
            }


            //Role names: Administrator or Operative

            var usm = new UserSessionModel()
            {
                Successful = true,
                Username = newUser.UserName
            };

            if (!roleExists)
                return Ok(usm);

            await _userManager.AddToRoleAsync(newUser, model.UserRole);

            usm.Role = model.UserRole;

            return Ok(usm);
        }
    }
}