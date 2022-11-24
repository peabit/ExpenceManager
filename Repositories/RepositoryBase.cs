using Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Repositories.Interfaces;

namespace Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : Entity, new()
{
    protected readonly RepositoryContext _context;

    protected virtual IQueryable<TEntity> Entities
        => _context.Set<TEntity>().AsNoTracking();

    public RepositoryBase(RepositoryContext context)
        => _context = context;

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        => await Entities.ToListAsync();

    public async Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        => await Entities.Where(expression).ToListAsync();

    public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> expression)
        => await Entities.FirstAsync(expression);

    public bool Contains(Expression<Func<TEntity, bool>> expression)
        => Entities.Any(expression);

    public virtual async Task CreateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}