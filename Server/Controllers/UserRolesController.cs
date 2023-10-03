using Bondlog.Server.Repository.Admin;
using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IGetUserRolesRepository _getUserRolesRepository;

        public UserRolesController(IGetUserRolesRepository getUserRolesRepository)
        {
            _getUserRolesRepository = getUserRolesRepository;
        }

        [HttpGet]
        public async Task <IActionResult> GetUserRoles()
        {
            var result = await _getUserRolesRepository.GetUsersWithRoles();

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(); //to be improved
            }
        }
    }
}