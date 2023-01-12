using AutoMapper;
using BowlingEF.Entities;

namespace Mapper;

public class JoueurProfile:Profile
{
    public JoueurProfile()
    {
        CreateMap<JoueurDTO, JoueurEntity>().ReverseMap();
    }
}