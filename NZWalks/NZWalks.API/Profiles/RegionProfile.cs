using AutoMapper;

namespace NZWalks.API.Profiles;

public class RegionProfile : Profile
{
	public RegionProfile()
	{
		CreateMap<Models.Domain.Region, Models.DTO.Region>()
			.ReverseMap();

		CreateMap<Models.Domain.Region, Models.DTO.AddRegionRequest>()
			.ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
			.ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
			.ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
			.ForMember(dest => dest.Long, opt => opt.MapFrom(src => src.Long))
			.ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
			.ReverseMap();

		CreateMap<Models.Domain.Region, Models.DTO.UpdateRegionRequest>()
			.ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
			.ForMember(dest => dest.Area, opt => opt.MapFrom(src => src.Area))
			.ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
			.ForMember(dest => dest.Long, opt => opt.MapFrom(src => src.Long))
			.ForMember(dest => dest.Population, opt => opt.MapFrom(src => src.Population))
			.ReverseMap();
	}
}
