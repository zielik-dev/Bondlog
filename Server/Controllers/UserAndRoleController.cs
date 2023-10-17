using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAndRoleController : ControllerBase
    {
        private readonly IRemoveUserAndRoleRepository _removeUserAndRoleRepository;
        private readonly IGetUsersAndRolesRepository _getUsersAndRolesRepository;
        private readonly IGetUserAndRoleRepository _getUserAndRoleRepository;

        public UserAndRoleController(IRemoveUserAndRoleRepository removeUserAndRoleRepository, 
                                     IGetUsersAndRolesRepository getUserRolesRepository,
                                     IGetUserAndRoleRepository getUserAndRoleRepository)
        {
            _getUserAndRoleRepository = getUserAndRoleRepository;
            _getUsersAndRolesRepository = getUserRolesRepository;
            _removeUserAndRoleRepository = removeUserAndRoleRepository;
        }

        //[HttpGet("userandrole/{userId}")]
        //public async Task<IActionResult> GetUserAndRole(string userId)
        //{
        //    var result = await _getUserAndRoleRepository.GetUserAndRoleByIdAsync(userId);

        //    if (result is not null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest(); //to be improved
        //    }
        //}

        //[HttpGet("userandrole")]
        [HttpGet]
        public async Task<IActionResult> GetUsersAndRoles()
        {
            var result = await _getUsersAndRolesRepository.GetUsersAndRoles();

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(); //to be improved
            }
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Remove(string userId)
        {
            await _removeUserAndRoleRepository.RemoveUserAndRoleAsync(userId);
            //dodac resultat jesli

            var usersRoles = await _getUsersAndRolesRepository.GetUsersAndRoles();

            if (usersRoles is not null)
            {
                return Ok(usersRoles);
            }
            else
            {
                return BadRequest(); //to be improved
            }
        }
    }
}