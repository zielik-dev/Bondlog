using Bondlog.Server.Repository.Admin;
using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
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
        private readonly IUpdateUserAndRoleRepository _updateUserAndRoleRepository;

        public UserAndRoleController(IRemoveUserAndRoleRepository removeUserAndRoleRepository,
                                     IGetUsersAndRolesRepository getUserRolesRepository,
                                     IGetUserAndRoleRepository getUserAndRoleRepository,
                                     IUpdateUserAndRoleRepository updateUserAndRoleRepository)
        {
            _getUserAndRoleRepository = getUserAndRoleRepository;
            _getUsersAndRolesRepository = getUserRolesRepository;
            _removeUserAndRoleRepository = removeUserAndRoleRepository;
            _updateUserAndRoleRepository = updateUserAndRoleRepository;
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

        [HttpPost]
        //do zrobienia

        [HttpPut]
        public async Task<IActionResult> UpdateUserAndRoleAsync([FromBody] UserAndRoleModel model)
        {
            var result = await _updateUserAndRoleRepository.UpdateRoleAsync(model);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
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