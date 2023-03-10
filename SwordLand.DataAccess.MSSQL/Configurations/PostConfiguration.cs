using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SwordLand.DataAccess.MSSQL.Entities;
namespace SwordLand.DataAccess.MSSQL.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<PostEntity>
    {
        public void Configure(EntityTypeBuilder<PostEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(x => x.Content)
                .IsRequired();
            builder.Property(x => x.Summery)
                .HasMaxLength(255)
                .IsRequired();

            /*builder.HasMany(x => x.Comments)
                .WithOne(x => x.Post);*/
        }
    }
}
