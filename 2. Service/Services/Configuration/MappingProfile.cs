using AutoMapper;
using Data.Entities;
using Data.Model.Entities;
using DnDBeyondAPI.Models;
using Dtos;

namespace Services.Configuration;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Character, CharacterDto>()
            .ForMember(dest => dest.HitPoints, opt => opt.MapFrom(src => src.MaxHitPoints))
            .ForMember(dest => dest.HitPoints, opt => opt.MapFrom(src => src.ActualHitPoints))
            .ReverseMap();
        CreateMap<Class, ClassDto>().ReverseMap();
        CreateMap<Defense, DefenseDto>().ReverseMap();
        CreateMap<Item, ItemDto>().ReverseMap();
        CreateMap<Modifier, ModifierDto>().ReverseMap();
        CreateMap<Stats, StatsDto>().ReverseMap();
    }
}
