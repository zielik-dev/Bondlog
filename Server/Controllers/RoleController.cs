using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IAddRoleRepository _addRoleRepository;

        public RoleController(IAddRoleRepository addRoleRepository)
        {
            _addRoleRepository = addRoleRepository;   
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string roleName)
        {
            var result = await _addRoleRepository.AddRoleAsync(roleName);

            if (result)
            {
                return Ok();
            }
            else
            {
                return Conflict("The role already exists");
            }
        }
    }
}
