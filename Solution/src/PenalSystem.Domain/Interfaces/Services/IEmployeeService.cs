using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;

namespace PenalSystem.Domain.Interfaces;

public interface IEmployeeService
{
    Task<OperationResult<Employee>> CreateEmployeeAsync(EmployeeCreateDTO employeeCreateDTO, CancellationToken cancellation = default);
    Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id, CancellationToken cancellation = default);
    Task<EmployeeDTO> GetEmployeeByCpfAsync(string cpf, CancellationToken cancellation = default);
    Task<OperationResult<Employee>> UpdateEmployeeAsync(Guid id, EmployeeUpdateDTO updatedEmployee, CancellationToken cancellation = default);
    Task<OperationResult<Employee>> DeleteEmployeeAsync(Guid id, CancellationToken cancellation = default); 
    Task<List<EmployeeDTO>> GetEmployeesAsync(CancellationToken cancellation = default);
    Task<string> LoginAsync(UserLoginDTO userLoginDTO);
}