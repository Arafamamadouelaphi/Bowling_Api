using AutoMapper;
using BowlingEF.Entities;

namespace Mapper;

public class PartieProfile:Profile
{
    public PartieProfile()
    {
        CreateMap<PartieDTO, PartieEntity>().ReverseMap();
    }
}