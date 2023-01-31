using AutoMapper;
using SwordLand.API.Contracts;
using SwordLand.Core.Models;

namespace SwordLand.API
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<Post, PostRequest>().ReverseMap();
        }
    }
}
