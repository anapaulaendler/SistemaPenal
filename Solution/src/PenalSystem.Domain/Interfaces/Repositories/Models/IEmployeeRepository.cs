using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<EmployeeDTO> GetEmployeeByCpfAsync(string cpf);
}