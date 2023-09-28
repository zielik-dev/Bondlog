using Bondlog.Server.Repository.Admin;
using Bondlog.Server.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IGetRolesRepository _getRolesRepository;

        public RolesController(IGetRolesRepository getRolesRepository)
        {
            _getRolesRepository = getRolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _getRolesRepository.GetRoles();

            if(result is not null)
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
