using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Mappers;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Employee, EmployeeCreateDTO>();
        CreateMap<Employee, EmployeeUpdateDTO>();

        CreateMap<EmployeeDTO, EmployeeCreateDTO>();
        CreateMap<EmployeeDTO, EmployeeUpdateDTO>();
        CreateMap<EmployeeDTO, Employee>();

        CreateMap<EmployeeCreateDTO, Employee>();
        
        CreateMap<EmployeeUpdateDTO, Employee>();
    }
}