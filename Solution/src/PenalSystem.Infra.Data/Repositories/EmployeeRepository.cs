using PenalSystem.Domain.Entities;
using PenalSystem.Infra.Data.Context;
using PenalSystem.Infra.Data.Repositories.Base;

namespace PenalSystem.Infra.Data.Repositories;

public class EmployeeRepository : RepositoryBase<Employee>
{
    public EmployeeRepository(AppDbContext appContext) : base(appContext)
    {
    }
}