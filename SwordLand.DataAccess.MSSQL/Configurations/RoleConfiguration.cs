﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwordLand.DataAccess.MSSQL.Entities;

namespace SwordLand.DataAccess.MSSQL.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NameRole).HasMaxLength(255);

            builder.HasMany(x => x.Users)
                .WithOne(x => x.Role);
        }
    }
}
