using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

public class PartieProfile:Profile
{
    public PartieProfile()
    {
        CreateMap<PartieDTO, PartieEntity>();
    }
}