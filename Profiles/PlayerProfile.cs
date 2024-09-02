using AutoMapper;
using BokoSan_backend.Models;
using BokoSan_backend.Models.DTOS.incoming;
using BokoSan_backend.Models.DTOS.outcoming;

namespace BokoSan_backend.Profiles;

public class PlayerProfile: Profile
{
    public PlayerProfile()
    {
        CreateMap<Player, PlayerDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));

        CreateMap<PlayerForCreationDto, Player>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => 0))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
    }
}
