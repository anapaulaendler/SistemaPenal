using AutoMapper;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Extensions;
using PenalSystem.Domain.Interfaces;

namespace PenalSystem.Domain.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork uow, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _uow = uow;
        _mapper = mapper;
    }

    public async Task<OperationResult<Employee>> CreateEmployeeAsync(EmployeeCreateDTO employeeCreateDTO, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Employee>();

        if (employeeCreateDTO is null)
        {
            return new OperationResult<Employee>(
                new ResultMessage("Invalid employee creation request.", ResultTypes.Error));
        }

        await _uow.BeginTransactionAsync();
        try
        {
            var employee = _mapper.Map<Employee>(employeeCreateDTO);

            await _employeeRepository.AddAsync(employee, cancellation);
            await _uow.CommitTransactionAsync();

            result = new OperationResult<Employee> { Value = employee };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Employee>(
                new ResultMessage($"Failed to create employee: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<OperationResult<Employee>> DeleteEmployeeAsync(Guid id, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Employee>();

        var employeeDTO = GetEmployeeByIdAsync(id);
        var employee = _mapper.Map<Employee>(employeeDTO);

        await _uow.BeginTransactionAsync();
        try
        {
            await _employeeRepository.Delete(employee, cancellation);
            await _uow.CommitTransactionAsync();

            result = new OperationResult<Employee> { Value = employee };
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Employee>(
                new ResultMessage($"Failed to delete employee: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }

    public async Task<EmployeeDTO> GetEmployeeByCpfAsync(string cpf, CancellationToken cancellation = default)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            throw new ArgumentException("Invalid employee CPF.");
        
        var employee = await _employeeRepository.GetEmployeeByCpfAsync(cpf, cancellation);
        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
        return employeeDTO;
    }

    public async Task<EmployeeDTO> GetEmployeeByIdAsync(Guid id, CancellationToken cancellation = default)
    {
        if (id == Guid.Empty)
            throw new ArgumentException("Invalid employee ID.");
        
        var employee = await _employeeRepository.GetByIdAsync(id, cancellation);
        var employeeDTO = _mapper.Map<EmployeeDTO>(employee);
        return employeeDTO;
    }

    public async Task<List<EmployeeDTO>> GetEmployeesAsync(CancellationToken cancellation = default)
    {
        var employees = await _employeeRepository.GetAsync(null, cancellation);
        return employees.Select(employee => _mapper.Map<EmployeeDTO>(employee)).ToList();
    }

    public async Task<OperationResult<Employee>> UpdateEmployeeAsync(Guid id, EmployeeUpdateDTO updatedEmployee, CancellationToken cancellation = default)
    {
        var result = new OperationResult<Employee>();

        var employeeDTO = GetEmployeeByIdAsync(id);
        var employee = _mapper.Map<Employee>(employeeDTO);

        await _uow.BeginTransactionAsync();

        try
        {
            employee.Name = updatedEmployee.Name;
            employee.Email = updatedEmployee.Email;
            employee.Role = updatedEmployee.Role;
            employee.Password = updatedEmployee.Password;

            await _employeeRepository.Update(employee, cancellation);
            await _uow.CommitTransactionAsync();
        }
        catch (Exception ex)
        {
            await _uow.RollbackTransactionAsync();
            return new OperationResult<Employee>(
                new ResultMessage($"Failed to update employee: {ex.Message}", ResultTypes.Error));
        }

        return result;
    }
}
