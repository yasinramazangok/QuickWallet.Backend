using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
        public static IServiceCollection AddUserInfrastructure(
            this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            return services;
        }
    }
}
