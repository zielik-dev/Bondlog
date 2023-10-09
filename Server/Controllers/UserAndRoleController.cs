using Bondlog.Server.Repository.Admin;
using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserAndRoleController : ControllerBase
    {
        private readonly IRemoveUserAndRoleRepository _removeUserAndRoleRepository;
        private readonly IGetUserRolesRepository _getUserRolesRepository;

        public UserAndRoleController(IRemoveUserAndRoleRepository removeUserAndRoleRepository, IGetUserRolesRepository getUserRolesRepository)
        {
            _removeUserAndRoleRepository = removeUserAndRoleRepository;
            _getUserRolesRepository = getUserRolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserAndRole()
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

        [HttpDelete]
        public async Task<IActionResult> Remove(string userId, string roleName)
        {
            await _removeUserAndRoleRepository.RemoveUserAndRoleAsync(userId, roleName);

            var usersRoles = await _getUserRolesRepository.GetUsersWithRoles();

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