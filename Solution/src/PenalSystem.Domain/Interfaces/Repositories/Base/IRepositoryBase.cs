using System.Linq.Expressions;

namespace PenalSystem.Domain.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null);
    Task<TEntity> GetByIdAsync(Guid id);
    Task AddAsync(TEntity entity);
    Task Delete(TEntity entity);
    Task Update(TEntity entity);
}