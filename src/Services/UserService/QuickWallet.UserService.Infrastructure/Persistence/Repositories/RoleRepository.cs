using Microsoft.EntityFrameworkCore;
using QuickWallet.UserService.Core.Entities;
using QuickWallet.UserService.Core.Interfaces;
using QuickWallet.UserService.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuickWallet.UserService.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(UserDbContext dbContext) : base(dbContext) { }

        public async Task<Role?> GetByRoleNameAsync(string roleName)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
    }
}
