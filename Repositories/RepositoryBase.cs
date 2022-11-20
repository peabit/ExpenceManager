using Entities;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Repositories.Interfaces;
using System.Linq;

namespace Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : Entity, new()
{
    protected readonly RepositoryContext _context;

    public RepositoryBase(RepositoryContext context)
        => _context = context;

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

    public async Task<IReadOnlyCollection<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        => await _context.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync();

    public async Task CreateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        _context.Set<TEntity>().Remove(new TEntity { Id = id });
        await _context.SaveChangesAsync();
    }

    public bool Contains(Expression<Func<TEntity, bool>> expression)
        => _context.Set<TEntity>().Any(expression);

    public bool Contains(int id)
        => Contains(e => e.Id == id);
}