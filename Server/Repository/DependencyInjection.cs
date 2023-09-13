using Bondlog.Server.Repository.Identity;
using Bondlog.Server.Repository.Interfaces;

namespace Bondlog.Server.Repository
{
    public static class DependencyInjection
    {
        public static IServiceCollection RepositoryDI(this IServiceCollection services)
        {
            services.AddScoped<ILoginUserRepository, LoginUserRepository>();
            services.AddScoped<IAddRoleRepository, AddRoleRepository>();
            services.AddScoped<IAddUserToRoleRepository, AddUserToRoleRepository>();
            services.AddScoped<IRegisterUserRepository, RegisterUserRepository>();
            services.AddScoped<IRemoveRoleRepository, RemoveRoleRepository>();
            services.AddScoped<IRemoveUserFromRoleRepository, RemoveUserFromRoleRepository>();

            return services;
        }
    }
}