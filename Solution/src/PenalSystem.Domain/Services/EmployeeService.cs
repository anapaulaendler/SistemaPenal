using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _uow;

    public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork uow)
    {
        _employeeRepository = employeeRepository;
        _uow = uow;
    }

    public Task CreateEmployeeAsync(EmployeeCreateDTO employee)
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployeeAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> GetEmployeeByCpfAsync(string cpf)
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<EmployeeDTO>> GetEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<EmployeeDTO> UpdateEmployeeAsync(Guid id, EmployeeUpdateDTO updatedEmployee)
    {
        throw new NotImplementedException();
    }
}
