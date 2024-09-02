using AutoMapper;
using BokoSan_backend.Models;
using BokoSan_backend.Models.DTOS.incoming;
using BokoSan_backend.Models.DTOS.outcoming;

namespace BokoSan_backend.Profiles;

public class HighScoreProfile: Profile
{
    public HighScoreProfile()
    {
        CreateMap<HighScoreForCreationDto, HighScore>()
            .ForMember(dest => dest.PlayerId, opt => opt.MapFrom(src => src.PlayerId))
            .ForMember(dest => dest.LevelId, opt => opt.MapFrom(src => src.LevelId))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
            .ForMember(dest => dest.NumberOfSteps, opt => opt.MapFrom(src => src.NumberOfSteps))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));

        CreateMap<HighScore, HighScoreDto>()
            .ForMember(dest => dest.UsernamePlayer, opt => opt.MapFrom(src => src.Player.Username))
            .ForMember(dest => dest.NameOfLevel, opt => opt.MapFrom(src => src.Level.Name))
            .ForMember(dest => dest.Time, opt => opt.MapFrom(src => src.Time))
            .ForMember(dest => dest.NumberOfSteps, opt => opt.MapFrom(src => src.NumberOfSteps))
            .ForMember(dest => dest.Score, opt => opt.MapFrom(src => src.Score));
    }
}
