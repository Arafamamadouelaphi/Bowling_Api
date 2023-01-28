using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

public class EquipeProfile:Profile
{
    public EquipeProfile()
    {
        CreateMap<EquipeDTO, EquipeEntity>().ReverseMap();
    }
}