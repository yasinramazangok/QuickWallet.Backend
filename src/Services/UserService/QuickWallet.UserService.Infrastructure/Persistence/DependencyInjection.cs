using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickWallet.UserService.Application.Interfaces;
using QuickWallet.UserService.Core.Interfaces;
using QuickWallet.UserService.Infrastructure.Persistence.Contexts;
using QuickWallet.UserService.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUserServiceInfrastructure(
            this IServiceCollection services, string connectionString)
        {
            // DbContext
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Application Services
            services.AddScoped<IUserService, Application.Services.UserService>();

            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
