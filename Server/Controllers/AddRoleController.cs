using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddRoleController : ControllerBase
    {
        private readonly IAddRoleRepository _addRoleRepository;

        public AddRoleController(IAddRoleRepository addRoleRepository)
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
