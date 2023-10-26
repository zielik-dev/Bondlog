using Bondlog.Client.Services.Admin;
using Bondlog.Client.Services.Identity;
using Bondlog.Client.Services.Interfaces;

namespace Bondlog.Client.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection ServiceDI(this IServiceCollection services)
        {
            //Identity
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<ILogoutUserService, LogoutUserService>();
            services.AddScoped<IRegisterUserService, RegisterUserService>();
            
            //Admin
            services.AddScoped<IAddRoleService, AddRoleService>();
            services.AddScoped<IAddUserAndRoleService, AddUserAndRoleService>();
            services.AddScoped<IEditRoleService, EditRoleService>();
            services.AddScoped<IRemoveRoleService, RemoveRoleService>();
            services.AddScoped<IRemoveUserAndRoleService, RemoveUserAndRoleService>();
            services.AddScoped<IGetRolesService, GetRolesService>();
            services.AddScoped<IGetUserAndRoleService, GetUserAndRoleService>();
            services.AddScoped<IGetUsersAndRolesService, GetUsersAndRolesService>();

            return services;
        }
    }
}