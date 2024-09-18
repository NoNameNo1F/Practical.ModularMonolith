using AdsManagementAPI.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Domain.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role");
        builder.HasKey(o => o.RoleId);

        builder.Property<Guid>("RoleId").HasColumnName("RoleId");
        builder.Property<string>("RoleName").HasColumnName("RoleName");

        builder
            .HasMany<Privilege>(r => r.Privileges)
            .WithMany(p => p.Roles)
            .UsingEntity("RolePrivilege");
    }
}