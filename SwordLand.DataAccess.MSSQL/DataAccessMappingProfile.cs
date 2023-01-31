using AutoMapper;
using SwordLand.Core.Models;
using SwordLand.DataAccess.MSSQL.Entities;

namespace SwordLand.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Category, CategoryEntity>().ReverseMap();
            CreateMap<Comment, CommentEntity>().ReverseMap();
            CreateMap<MinecraftAccount, MinecraftAccountEntity>().ReverseMap();
            CreateMap<Post, PostEntity>().ReverseMap();
            CreateMap<Role, RoleEntity>().ReverseMap();
            CreateMap<Session, SessionEntity>().ReverseMap();
            CreateMap<User, UserEntity>().ReverseMap();
        }
    }
}
