using AutoMapper;
using BowlingEF.Entities;

namespace Mapper;

public class EquipeProfile:Profile
{
    public EquipeProfile()
    {
        CreateMap<EquipeDTO, EquipeEntity>().ReverseMap();
    }
}