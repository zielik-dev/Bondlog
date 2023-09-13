using Bondlog.Server.Infrastructure.DbContext;
using Bondlog.Server.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bondlog.Server.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection InfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext> (options => options.UseSqlServer(configuration.GetConnectionString("ApplicationDbConnection")));

            services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}
