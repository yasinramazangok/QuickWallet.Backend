using QuickWallet.UserService.Application.Contracts.DTOs;
using QuickWallet.UserService.Application.Contracts.Requests;
using QuickWallet.UserService.Application.Interfaces;
using QuickWallet.UserService.Core.Entities;
using QuickWallet.UserService.Core.Interfaces;
using QuickWallet.UserService.Core.ValueObjects;

namespace QuickWallet.UserService.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDto> RegisterAsync(RegisterUserRequest request)
        {
            // Create Email VO
            var email = new Email(request.Email);

            // Check Email 
            var existingUser = await _userRepository.GetByEmailAsync(email);
            if (existingUser != null)
                throw new Exception("Email zaten kayıtlı!");

            // Password hash
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // Create User entity
            var user = new User(request.Name, email, passwordHash);

            // Assign Default role
            var role = await _roleRepository.GetByRoleNameAsync("User");
            if (role == null)
                throw new Exception("Default rol bulunamadı!");

            user.UserRoles.Add(new UserRole(user, role));

            // Save User
            await _userRepository.AddAsync(user);

            // Return DTO
            return new UserDto
            {
                Id = user.Id,
                Name = user.FullName,
                Email = user.Email.Value,
                Roles = user.UserRoles.Select(ur => ur.Role.Name).ToList()
            };
        }
    }
}
