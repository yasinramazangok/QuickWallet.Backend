using Microsoft.EntityFrameworkCore;
using QuickWallet.UserService.Core.Entities;
using QuickWallet.UserService.Core.Interfaces;
using QuickWallet.UserService.Core.ValueObjects;
using QuickWallet.UserService.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Infrastructure.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(UserDbContext dbContext) : base(dbContext) { }

        public async Task<User?> GetByEmailAsync(Email email)
        {
            return await _dbContext.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email.Value == email.Value);
        }
    }
}
