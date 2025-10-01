using QuickWallet.UserService.Application.Contracts.DTOs;
using QuickWallet.UserService.Application.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterUserRequest request);
    }
}
