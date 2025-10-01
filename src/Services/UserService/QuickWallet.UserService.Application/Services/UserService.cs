using QuickWallet.UserService.Application.Contracts.DTOs;
using QuickWallet.UserService.Application.Contracts.Requests;
using QuickWallet.UserService.Application.Interfaces;
using QuickWallet.UserService.Core.Interfaces;
using QuickWallet.UserService.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Application.Services
{
    public class UserService : IUserService
    {
        public Task<UserDto> RegisterAsync(RegisterUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
