using AutoMapper;

namespace NZWalks.API.Profiles;

public class WalkProfile : Profile
{
    public WalkProfile()
    {
        CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
            .ReverseMap();

        CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficulty>()
            .ReverseMap();

        CreateMap<Models.Domain.Walk, Models.DTO.AddWalkRequest>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
            .ForMember(dest => dest.WalkDifficultyId, opt => opt.MapFrom(src => src.WalkDifficultyId))
            .ReverseMap();

        CreateMap<Models.Domain.Walk, Models.DTO.UpdateWalkRequest>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Length))
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId))
            .ForMember(dest => dest.WalkDifficultyId, opt => opt.MapFrom(src => src.WalkDifficultyId))
            .ReverseMap();
    }
}
