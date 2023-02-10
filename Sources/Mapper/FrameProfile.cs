using AutoMapper;
using BowlingEF.Entities;
using DTOs;

namespace Mapper;

/// <summary>
/// Profile de mapping entre les FrameDTOs et les FrameEntity
/// </summary>
public class FrameProfile:Profile
{
    public FrameProfile()
    {
        CreateMap<FrameDTO, FrameEntity>().ReverseMap();
    }
}