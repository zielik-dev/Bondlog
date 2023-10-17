using Bondlog.Server.Repository.Admin;
using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRolesRepository _getRolesRepository;
        private readonly IAddRoleRepository _addRoleRepository;
        private readonly IRemoveRoleRepository _removeRoleRepository;

        public RolesController(IGetRolesRepository getRolesRepository, IAddRoleRepository addRoleRepository, IRemoveRoleRepository removeRoleRepository)
        {
            _getRolesRepository = getRolesRepository;
            _addRoleRepository = addRoleRepository;
            _removeRoleRepository = removeRoleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _getRolesRepository.GetRoles();

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] string roleName)
        {
            await _addRoleRepository.AddRoleAsync(roleName);

            var result = await _getRolesRepository.GetRoles();

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> Remove(string roleName)
        {
            await _removeRoleRepository.RemoveRoleAsync(roleName);

            var roles = await _getRolesRepository.GetRoles();

            if (roles is not null)
            {
                return Ok(roles);
            }
            else
            {
                return BadRequest(); //to be improved
            }
        }
    }
}