using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

/// <summary>
/// Profile de mapping entre les PartieDTOs et les PartieEntity
/// </summary>
public class PartieProfile:Profile
{
    public PartieProfile()
    {
        CreateMap<PartieDTO, PartieEntity>().ReverseMap();
    }
}