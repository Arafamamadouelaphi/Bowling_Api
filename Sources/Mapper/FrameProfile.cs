using AutoMapper;
using BowlingEF.Entities;

namespace Mapper;

public class FrameProfile:Profile
{
    public FrameProfile()
    {
        CreateMap<FrameDTO, FrameEntity>().ReverseMap();
    }
}