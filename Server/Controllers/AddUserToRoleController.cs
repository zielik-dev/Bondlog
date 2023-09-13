using Bondlog.Server.Repository.Identity;
using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bondlog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddUserToRoleController : ControllerBase
    {
        private readonly IAddUserToRoleRepository _addUserToRoleRepository;

        public AddUserToRoleController(IAddUserToRoleRepository addUserToRoleRepository)
        {
            _addUserToRoleRepository = addUserToRoleRepository;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddUserToRole (UserRoleEntity userRoleEntity)//(string userId, string roleName)
        //{

        //}
    }
}
