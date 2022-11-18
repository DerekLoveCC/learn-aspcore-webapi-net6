using AutoMapper;
using learn_aspcore_webapi_net6.Dtos;
using learn_aspcore_webapi_net6.Models.Domains;

namespace learn_aspcore_webapi_net6.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<WalkDifficulty, WalkDifficultyDto>().ReverseMap();
            CreateMap<WalkDifficulty, CreateWalkDifficultyDto>().ReverseMap();
            CreateMap<WalkDifficulty, UpdateWalkDifficultyDto>().ReverseMap();
        }
    }
}
