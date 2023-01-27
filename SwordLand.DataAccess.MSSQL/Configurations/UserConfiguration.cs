using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwordLand.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwordLand.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NickName).HasMaxLength(36).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.HashPassword).IsRequired();

            builder.HasMany(x => x.MinecraftAccounts).WithOne(x => x.User);
            builder.HasMany(x => x.Posts).WithOne(x => x.User);
            builder.HasMany(x => x.Sessions).WithOne(x => x.User);
        }
    }
}
