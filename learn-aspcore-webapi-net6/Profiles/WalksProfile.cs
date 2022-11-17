using AutoMapper;
using learn_aspcore_webapi_net6.Dtos;
using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, CreateWalkDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkDto>().ReverseMap();
        }
    }
}