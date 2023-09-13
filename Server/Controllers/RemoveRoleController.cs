using Bondlog.Server.Repository.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveRoleController : ControllerBase
    {
        private readonly RemoveRoleRepository _removeRoleRepository;
        
        public RemoveRoleController(RemoveRoleRepository removeRoleRepository)
        {
            _removeRoleRepository = removeRoleRepository;
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string roleName)
        {
            bool result = await _removeRoleRepository.RemoveRoleAsync(roleName);

            if (result)
            {
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Role Not Found");
            }
        }

    }
}
