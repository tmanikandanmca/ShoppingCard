using AuthServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServices.DBModels.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity
            .ToTable("Users");
        entity
            .Property(e => e.Email)
            .IsRequired();
        entity
            .Property(e => e.Name)
            .IsRequired();
        entity
            .Property(e => e.Password)
            .IsRequired();
        entity
            .Property(e => e.PhoneNumber)
            .IsRequired();

        entity
            .HasMany(d => d.Roles)
            .WithMany(p => p.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                j =>
                {
                    j.HasKey("UserId", "RoleId");
                    j.ToTable("UserRoles");
                });
    }
}
