﻿using Bondlog.Server.Repository.Interfaces;
using Bondlog.Shared.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Bondlog.Server.Repository.Identity
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterUserRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserSessionModel> RegisterUserAsync(RegisterModel model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };
            
            var exists = await _userManager.FindByEmailAsync(newUser.Email);
            if (exists is not null)
            {
                return new UserSessionModel { Successful = false, ErrorMessage = "Username Already Exists" };
            }

            var result = await _userManager.CreateAsync(newUser, model.Password!);
            if (!result.Succeeded)
            {
                return new UserSessionModel { Successful = false, ErrorMessage = "User Not Created" };
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            var role = await _roleManager.FindByNameAsync(model.UserRole);
            await _userManager.AddToRoleAsync(user, role.Name);

            UserSessionModel usm = new UserSessionModel()
            {
                Successful = true,
                Username = user.UserName,
                UserRole = role.Name,
            };
            
            return usm;
        }
    }
}