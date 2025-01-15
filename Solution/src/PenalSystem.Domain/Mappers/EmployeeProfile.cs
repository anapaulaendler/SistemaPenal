using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class EmployeeProfile
{
    public EmployeeProfile()
    {
        Mapper.CreateMap<Employee, EmployeeDTO>();
    }
}