using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickWallet.UserService.Core.Entities;
using QuickWallet.UserService.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickWallet.UserService.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.OwnsOne(u => u.Email, email =>
            email.Property(e => e.Value)
                 .IsRequired()
                 .HasMaxLength(255)
                 .HasColumnName("Email")
            );

            builder.Property(u => u.PasswordHash)
                   .IsRequired();

            builder.HasMany(u => u.UserRoles)
                   .WithOne(ur => ur.User)
                   .HasForeignKey(ur => ur.UserId);
        }
    }
}
