using AuthServices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServices.DBModels.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> entity)
    {
        entity
            .ToTable("Roles");
        entity
            .HasKey(e=>e.Id) ;
        
        entity
            .Property(e => e.Name)
            .IsRequired();
        entity
            .HasIndex(e => e.Name)
            .IsUnique();
    }
}
