using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

public class JoueurProfile:Profile
{
    public JoueurProfile()
    {
        CreateMap<JoueurDTO, JoueurEntity>().ReverseMap();
    }
}