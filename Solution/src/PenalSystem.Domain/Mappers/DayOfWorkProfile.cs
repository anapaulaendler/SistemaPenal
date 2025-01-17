using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class DayOfWorkProfile : Profile
{
    public DayOfWorkProfile()
    {
        CreateMap<DayOfWork, DayOfWorkDTO>();
        CreateMap<DayOfWork, DayOfWorkCreateDTO>();

        CreateMap<DayOfWorkDTO, DayOfWorkCreateDTO>();
        CreateMap<DayOfWorkDTO, DayOfWork>();

        CreateMap<DayOfWorkCreateDTO, DayOfWork>();
    }
}