using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Business.Entities.Identity;
using System;

namespace RequestPermission.Database.EntityConfigurations
{
    public class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.RequestDate).HasDefaultValue(DateTime.Now)
                    .IsRequired();

            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now)
                    .IsRequired();

            builder.HasOne(x => x.Employees)
                .WithMany(x => x.Permissions)
               .HasForeignKey(x => x.EmployeeId);

            builder.HasOne(x => x.PermissionTypes)
              .WithMany(x => x.Permissions)
             .HasForeignKey(x => x.PermissionTypeId);

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);
        }
    }
}
