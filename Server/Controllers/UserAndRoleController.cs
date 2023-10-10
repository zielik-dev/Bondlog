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

        public UserAndRoleController(IRemoveUserAndRoleRepository removeUserAndRoleRepository, IGetUsersAndRolesRepository getUserRolesRepository)
        {
            _removeUserAndRoleRepository = removeUserAndRoleRepository;
            _getUsersAndRolesRepository = getUserRolesRepository;
        }

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

        [HttpDelete]
        public async Task<IActionResult> Remove(string userId)
        {
            await _removeUserAndRoleRepository.RemoveUserAndRoleAsync(userId);

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