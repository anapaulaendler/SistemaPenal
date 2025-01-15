using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class DayOfWorkProfile
{
    public DayOfWorkProfile()
    {
        Mapper.CreateMap<DayOfWork, DayOfWorkDTO>();
    }
}