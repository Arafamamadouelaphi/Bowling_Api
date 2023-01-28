using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

public class FrameProfile:Profile
{
    public FrameProfile()
    {
        CreateMap<FrameDTO, FrameEntity>().ReverseMap();
    }
}