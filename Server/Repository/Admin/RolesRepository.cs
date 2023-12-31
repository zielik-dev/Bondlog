﻿using Bondlog.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Bondlog.Server.Repository.Admin
{
    public class RolesRepository
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesRepository(IApplicationDbContext dbContext, IConfiguration configuration,
                                   SignInManager<IdentityUser> signInManager,
                                   UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<List<IdentityRole>> GetRolesAsync()
        {
            if (await _roleManager.Roles.AnyAsync())
            {
                var roles = await _roleManager.Roles.ToListAsync();
                return roles;
            }
            else
            {
                return new List<IdentityRole>();
            }
        }
    }
}