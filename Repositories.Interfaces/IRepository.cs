using Entities;
using System.Linq.Expressions;

namespace Repositories.Interfaces;

public interface IRepository<TEntity> 
    where TEntity : Entity, new()
{
    Task CreateAsync(TEntity entity);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(int id);
    bool Contains(Expression<Func<TEntity, bool>> expression);
    bool Contains(int id);
}