using Microsoft.EntityFrameworkCore;
using SwordLand.DataAccess.MSSQL.Configurations;
using SwordLand.DataAccess.MSSQL.Entities;

namespace SwordLand.DataAccess.MSSQL
{
    public class SwordLandDbContext : DbContext
    {
        public SwordLandDbContext(DbContextOptions<SwordLandDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryEntity> Category { get; set; }
        public DbSet<CommentEntity> Comment { get; set; }
        public DbSet<MinecraftAccountEntity> MinecraftAccount { get; set; }
        public DbSet<PostEntity> Post { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<SessionEntity> Session { get; set; }
        public DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new MinecraftAccountConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SessionConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);

            /*
                insert into[Role] (Id, NameRole)
                values('a49bcc20-cff0-4e2c-9637-36251b93e806', 'Test-Role');

                insert into[Category]
                values('d3e951be-24cd-495a-99e1-d738da11fbf6', 'Test-Category');

                insert into[User] (Id, NickName, Email, Rating, HashPassword, Salt, UserUrl, RoleId, CreatetAt)
                values('1378009c-d7c1-49c9-8997-94b1981a899c', 'Test', 'Test@gmail.com', 0, '9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08', 'test', 'Blogs/Test', 'a49bcc20-cff0-4e2c-9637-36251b93e806', '2022-11-29 16:00:00.0000000');

                insert into[Session] (Id, UserId, Token, CreatedAt)
                values('cac4dd7b-b90f-4cef-bd3d-454eb88750dc', '1378009c-d7c1-49c9-8997-94b1981a899c', 'Test-Token', '2022-11-29 16:00:00.0000000');

                insert into[Post] (Id, UserId, Title, Content, Summery, CategoryId, PostUrl, CreatedAt, IsPublished, LastModified)
                values('807a2b81-df82-411a-a7cb-044809c7e2f3', '1378009c-d7c1-49c9-8997-94b1981a899c', 'Test-Title', 'Test-Content', 'Test-Summery', 'd3e951be-24cd-495a-99e1-d738da11fbf6', 'Post/807a2b81-df82-411a-a7cb-044809c7e2f3', '2022-11-29 16:00:00.0000000', 1, '2022-11-29 16:00:00.0000000');

                insert into[MinecraftAccount] (Id, UserId, UserName, UUID, Email, SkinLink)
                values('ebb6b921-e2cd-4a3b-9ca8-0c66b82c4666', '1378009c-d7c1-49c9-8997-94b1981a899c', 'Test-MinAcc', 'Test-UUID', 'Test@gmail.com', 'img/skin/Test-UUID.png');

                insert into[Comment] (Id, UserId, PostId, Content, ParentCommentId, CreatedAt, IsPublished, LastModified)
                values('f4058946-6db9-4871-ac20-e88ee18c3478', '1378009c-d7c1-49c9-8997-94b1981a899c', '807a2b81-df82-411a-a7cb-044809c7e2f3', 'Test-Content-1', 'f4058946-6db9-4871-ac20-e88ee18c3478', '2022-11-29 16:00:00.0000000', 1, '2022-11-29 16:00:00.0000000');

                insert into[Comment] (Id, UserId, PostId, Content, ParentCommentId, CreatedAt, IsPublished, LastModified)
                values('3527d2ff-8d57-440d-8e12-a12b07e1c36d', '1378009c-d7c1-49c9-8997-94b1981a899c', '807a2b81-df82-411a-a7cb-044809c7e2f3', 'Test-Content-1-1', 'f4058946-6db9-4871-ac20-e88ee18c3478', '2022-11-29 16:00:00.0000000', 1, '2022-11-29 16:00:00.0000000');

                insert into[Comment] (Id, UserId, PostId, Content, ParentCommentId, CreatedAt, IsPublished, LastModified)
                values('e82d9d80-d6d1-4ff1-a0a4-b75839265b25', '1378009c-d7c1-49c9-8997-94b1981a899c', '807a2b81-df82-411a-a7cb-044809c7e2f3', 'Test-Content-2', 'e82d9d80-d6d1-4ff1-a0a4-b75839265b25', '2022-11-29 16:00:00.0000000', 1, '2022-11-29 16:00:00.0000000');
            */
        }
    }
}
