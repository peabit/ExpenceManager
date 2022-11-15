using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class RepositoryBase<TEntity> where TEntity : Entity
{
	protected readonly RepositoryContext _context;

	protected virtual IQueryable<TEntity> Entities
		=> _context.Set<TEntity>().AsNoTracking();

    public RepositoryBase(RepositoryContext context)
		=> _context = context;

	public async virtual Task<TEntity> CreateAsync(TEntity entity)
	{
		_context.Set<TEntity>().Add(entity);
		await _context.SaveChangesAsync();
		return entity;
	}

	public async virtual Task<IReadOnlyCollection<TEntity>> GetAllAsync()
		=> await Entities.ToListAsync();

	public async virtual Task<TEntity> GetAsync(int id)
		=> await Entities.FirstAsync(e => e.Id == id);

	public async virtual Task UpdateAsync(TEntity entity)
	{
		_context.Set<TEntity>().Update(entity);
		await _context.SaveChangesAsync();
	}

	public async virtual Task DeleteAsync(int id)
	{
		_context.Set<TEntity>().Remove(
            _context.Set<TEntity>().First( e => e.Id == id )
        );

		await _context.SaveChangesAsync();
	}
}