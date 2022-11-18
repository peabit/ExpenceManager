using Entities;
using Repositories.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Repositories;

public class RepositoryBase<TEntity> : IRepository<TEntity> 
    where TEntity : Entity, new()
{
    protected readonly RepositoryContext _context;

    private DbSet<TEntity> Entities
        => _context.Set<TEntity>();

    public RepositoryBase(RepositoryContext context)
        => _context = context;

    public async Task CreateAsync(TEntity entity)
    {
        Entities.Add(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
        => await Entities.AsNoTracking().ToListAsync();

    public virtual async Task<IReadOnlyCollection<TEntity>> Get(Expression<Func<TEntity, bool>> expression)
        => await Entities.Where(expression).ToListAsync();

    public async Task UpdateAsync(TEntity entity)
    {
        Entities.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Entities.Remove(new TEntity() { Id = id });
        await _context.SaveChangesAsync();
    }
}