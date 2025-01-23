using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Domain.Interfaces;

public interface IEmployeeRepository : IRepositoryBase<Employee>
{
    Task<Employee> GetEmployeeByCpfAsync(string cpf, CancellationToken cancellation = default);
    Task<Employee> GetEmployeeByEmailAsync(string userEmail);
}