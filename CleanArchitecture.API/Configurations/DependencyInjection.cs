using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();

            return services;
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CleanArchitectureDbContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            return services;
        }
    }
}
