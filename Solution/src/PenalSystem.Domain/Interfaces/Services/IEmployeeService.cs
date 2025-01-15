using PenalSystem.Domain.DTOs;

namespace PenalSystem.Domain.Interfaces;

public interface IEmployeeService
{
    Task CreateEmployeeAsync(EmployeeCreateDTO employee);
    Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id);
    Task<EmployeeDTO> GetEmployeeByCpfAsync(string cpf);
    Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, EmployeeUpdateDTO updatedEmployee);
    Task DeleteEmployeeAsync(Guid id); 
    Task<List<EmployeeDTO>> GetEmployeesAsync();
}