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
    public class RolesController : ControllerBase
    {
        private readonly IGetRolesRepository _getRolesRepository;
        private readonly IAddRoleRepository _addRoleRepository;
        private readonly IRemoveRoleRepository _removeRoleRepository;
        private readonly IUpdateRoleRepository _updateRoleRepository;

        public RolesController(IGetRolesRepository getRolesRepository, IAddRoleRepository addRoleRepository, IRemoveRoleRepository removeRoleRepository, IUpdateRoleRepository updateRoleRepository)
        {
            _getRolesRepository = getRolesRepository;
            _addRoleRepository = addRoleRepository;
            _removeRoleRepository = removeRoleRepository;
            _updateRoleRepository = updateRoleRepository;
            _updateRoleRepository = updateRoleRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetRolesAsync()
        {
            var result = await _getRolesRepository.GetRolesAsync();

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
        public async Task<IActionResult> AddRoleAsync([FromBody] string roleName)
        {
            await _addRoleRepository.AddRoleAsync(roleName);

            var result = await _getRolesRepository.GetRolesAsync();  //do likwidacji, rezygnacja z pomyslu

            if (result is not null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole([FromBody] IdentityRole roleName)
        {
            var result = await _updateRoleRepository.UpdateRoleAsync(roleName);

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{roleName}")]
        public async Task<IActionResult> RemoveAsync(string roleName)
        {
            try
            {
                bool roleDeleted = await _removeRoleRepository.RemoveRoleAsync(roleName);

                if (roleDeleted)
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Role not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}