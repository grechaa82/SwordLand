using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwordLand.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwordLand.DataAccess.MSSQL.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content).IsRequired();

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.ParentComment);
        }
    }
}
