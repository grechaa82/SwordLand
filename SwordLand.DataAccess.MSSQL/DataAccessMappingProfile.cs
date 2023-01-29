using AutoMapper;

namespace SwordLand.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Core.Models.Post, Entities.Post>().ReverseMap();
        }
    }
}
