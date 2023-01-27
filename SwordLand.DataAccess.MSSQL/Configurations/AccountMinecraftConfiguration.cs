using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwordLand.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwordLand.DataAccess.MSSQL.Configurations
{
    public class AccountMinecraftConfiguration : IEntityTypeConfiguration<MinecraftAccount>
    {
        public void Configure(EntityTypeBuilder<MinecraftAccount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserName).HasMaxLength(16).IsRequired();
            builder.Property(x => x.UUID).HasMaxLength(36).IsRequired();
        }
    }
}
