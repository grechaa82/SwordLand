using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwordLand.DataAccess.MSSQL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwordLand.DataAccess.MSSQL.Configurations
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.User).IsRequired();
            builder.Property(x => x.Token).IsRequired();
        }
    }
}
