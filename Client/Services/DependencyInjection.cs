using Bondlog.Client.Interfaces;
using Bondlog.Client.Services.Admin;
using Bondlog.Client.Services.Identity;

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
            
            //Domain
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<IUserRolesService, UserRolesService>();

            return services;
        }
    }
}
