using AutoMapper;
using BokoSan_backend.Models;
using BokoSan_backend.Models.DTOS.incoming;
using BokoSan_backend.Models.DTOS.outcoming;

namespace BokoSan_backend.Profiles;

public class LevelProfile: Profile
{
    public LevelProfile()
    {
        CreateMap<LevelForCreationDto, Level>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CreatorId, opt => opt.MapFrom(src => src.CreatorId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.CreatorTime, opt => opt.MapFrom(src => src.CreatorTime))
            .ForMember(dest => dest.Creator, opt => opt.MapFrom(src => (Player) null));

        CreateMap<Level, LevelDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.NameOfCreator, opt => opt.MapFrom(src => src.Creator.Username))
            .ForMember(dest => dest.CreatorTime, opt => opt.MapFrom(src => src.CreatorTime));
    }
}
