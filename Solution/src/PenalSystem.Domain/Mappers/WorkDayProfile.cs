using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class WorkDayProfile : Profile
{
    public WorkDayProfile()
    {
        CreateMap<WorkDay, WorkDayDTO>();
        CreateMap<WorkDay, WorkDayCreateDTO>();

        CreateMap<WorkDayDTO, WorkDayCreateDTO>();
        CreateMap<WorkDayDTO, WorkDay>();

        CreateMap<WorkDayCreateDTO, WorkDay>();
    }
}