using QuickWallet.UserService.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Core.Interfaces
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role?> GetByRoleNameAsync(string roleName);
    }
}
