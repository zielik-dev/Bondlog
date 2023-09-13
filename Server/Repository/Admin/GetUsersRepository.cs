//using Bondlog.Shared.Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.ActionConstraints;
//using Microsoft.EntityFrameworkCore;

//namespace Bondlog.Server.Repository.Admin
//{
//    public class GetUsersRepository
//    {
//        private readonly UserManager<IdentityUser> _userManager;
//        private readonly RoleManager<IdentityRole> _roleManager;

//        public GetUsersRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
//        {
//            _userManager = userManager;
//            _roleManager = roleManager;
//        }

//        public async Task<IdentityUser> GetListOfAllUsers()
//        {
//            var users = await _userManager.Users.ToListAsync();

//            var roles = await _roleManager.Roles.ToListAsync();
//            var userRoles = await _roleManager.

//            roles.ForEach(x => Console.WriteLine(x.Id, " ", x.Name, x.NormalizedName)

//            var roles = await _roleManager.

//            //dopier

//            var UsersRoles = List<UserRolesEntity>
//        }
//    }
//}
