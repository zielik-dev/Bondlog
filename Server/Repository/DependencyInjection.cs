using Bondlog.Server.Repository.Admin;
using Bondlog.Server.Repository.Identity;
using Bondlog.Server.Repository.Interfaces;

namespace Bondlog.Server.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection RepositoryDI(this IServiceCollection services)
        {
            //Admin
            services.AddScoped<IGetRolesRepository, GetRolesRepository>();
            services.AddScoped<IGetUserAndRoleRepository, GetUserAndRoleRepository>();
            services.AddScoped<IGetUsersAndRolesRepository, GetUsersRolesRepository>();
            services.AddScoped<IRemoveUserAndRoleRepository, RemoveUserAndRoleRepository>();
            services.AddScoped<IRemoveUserFromRoleRepository, RemoveUserFromRoleRepository>();

            //Identity
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();

            //need sorting
            services.AddScoped<IAddUserToRoleRepository, AddUserToRoleRepository>();
            services.AddScoped<IAddRoleRepository, AddRoleRepository>();
            services.AddScoped<IRemoveRoleRepository, RemoveRoleRepository>();

            return services;
        }
    }
}