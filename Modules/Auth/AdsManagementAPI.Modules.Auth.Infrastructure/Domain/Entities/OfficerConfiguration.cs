using AdsManagementAPI.Modules.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdsManagementAPI.Modules.Auth.Infrastructure.Domain.Entities;

public class OfficerConfiguration : IEntityTypeConfiguration<Officer>
{
    public void Configure(EntityTypeBuilder<Officer> builder)
    {
        builder.ToTable("Officer");
        builder.HasKey(o => o.OfficerId);

        builder.Property<Guid>("OfficerId").HasColumnName("OfficerId");
        builder.Property<string>("FullName").HasColumnName("FullName");
        builder.Property<DateTime>("DoB").HasColumnName("DoB");
        builder.Property<string>("Email").HasColumnName("Email");
        builder.Property<string>("PhoneNumber").HasColumnName("PhoneNumber");
        builder.Property<string>("PasswordHash").HasColumnName("PasswordHash");
        builder.Property<int>("WardId").HasColumnName("WardId");
        builder.Property<Guid>("RoleId").HasColumnName("RoleId");

        builder
            .HasOne<Role>()
            .WithOne(r => r.Officer)
            .HasForeignKey<Officer>(o => o.RoleId);

        builder
            .HasMany<Privilege>(r => r.Privileges)
            .WithMany(p => p.Officers)
            .UsingEntity("OfficerPrivilege");
    }
}