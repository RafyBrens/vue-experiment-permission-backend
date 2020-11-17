using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RequestPermission.Business.Entities.Identity;
using System;

namespace RequestPermission.Database.EntityConfigurations
{
    public class PermissionTypeEntityConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.CreatedAt).HasDefaultValue(DateTime.Now)
                  .IsRequired();

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);
        }
    }
}
