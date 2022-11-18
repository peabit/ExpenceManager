using Entities;
using System.Linq.Expressions;

namespace Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity, new()
{
    Task CreateAsync(TEntity entity);
    Task DeleteAsync(int id);
    Task<IReadOnlyCollection<TEntity>> Get(Expression<Func<TEntity, bool>> expression);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task UpdateAsync(TEntity entity);
}