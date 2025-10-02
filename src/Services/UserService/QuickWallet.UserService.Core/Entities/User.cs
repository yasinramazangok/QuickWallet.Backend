using QuickWallet.UserService.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Core.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public Email Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // Navigation
        public ICollection<UserRole> UserRoles { get; private set; } = new List<UserRole>();

        private User() { } // for EF Core

        public User(string fullName, Email email, string passwordHash)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            PasswordHash = passwordHash;
        }

        public void Deactivate() => IsActive = false;
        public void UpdateName(string name) => FullName = name;
    }
}
