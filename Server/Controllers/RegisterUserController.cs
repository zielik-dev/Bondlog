using Bondlog.Server.Infrastructure.Interfaces;
using Bondlog.Server.Repository.Identity;
using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Entities;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

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
            var roleExist = _roleManager.RoleExistsAsync(model.UserRole).GetAwaiter().GetResult(); //do obrobki

            var result = await _userManager.CreateAsync(newUser, model.Password!);
            var role = await _roleManager.FindByNameAsync(model.UserRole);  //do obrobki
            var user = await _userManager.FindByEmailAsync(model.Email);    //do obrobki

            if (!result.Succeeded)
            {
                return Ok (new UserSessionModel { Successful = false/*, ErrorMessage = errors*/ });
            }


            //Role names: Administrator or Operative

            await _userManager.AddToRoleAsync(newUser, model.UserRole); //huj z jakiegos powodu nie aktualizuje tabeli AspNetUserRoles

            return Ok(new UserSessionModel { Successful = true });
        }
    }
}