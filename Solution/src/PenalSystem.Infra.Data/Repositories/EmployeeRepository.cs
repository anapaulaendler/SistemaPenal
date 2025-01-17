using Microsoft.EntityFrameworkCore;
using PenalSystem.Domain.DTOs;
using PenalSystem.Domain.Entities;
using PenalSystem.Domain.Interfaces;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext appContext) : base(appContext)
    {
    }

    public async Task<Employee> GetEmployeeByCpfAsync(string cpf)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Cpf == cpf);

        if (entity is null)
        {
            throw new KeyNotFoundException();
        }

        return entity;
    }
}