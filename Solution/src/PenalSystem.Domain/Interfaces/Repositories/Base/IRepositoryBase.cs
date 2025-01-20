using System.Linq.Expressions;

namespace PenalSystem.Domain.Interfaces;

public interface IRepositoryBase<TEntity> where TEntity : class, IEntity
{
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? filter = null, CancellationToken cancellation = default);
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellation = default);
    Task AddAsync(TEntity entity, CancellationToken cancellation = default);
    Task Delete(TEntity entity, CancellationToken cancellation = default);
    Task Update(TEntity entity, CancellationToken cancellation = default);
}