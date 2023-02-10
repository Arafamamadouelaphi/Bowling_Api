using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

/// <summary>
/// Profile de mapping entre les JoueurDTOs et les JoueurEntity
/// </summary>
public class JoueurProfile:Profile
{
    public JoueurProfile()
    {
        CreateMap<JoueurDTO, JoueurEntity>().ReverseMap();
    }
}