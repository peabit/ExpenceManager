using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories;

public class ReceiptPositionRepository : RepositoryBase<ReceiptPosition>
{
    private IQueryable<ReceiptPosition> ReceiptPositions
        => _context.ReceiptPositions
            .Include(p => p.ProductCategory)
            .Include(p => p.UnitOfMeasurement)
            .AsNoTracking();

    public ReceiptPositionRepository(RepositoryContext context) : base(context) { }

    public override async Task<IReadOnlyCollection<ReceiptPosition>> GetAllAsync()
        => await ReceiptPositions.ToListAsync();

    public override async Task<IReadOnlyCollection<ReceiptPosition>> Get(Expression<Func<ReceiptPosition, bool>> expression)
        => await ReceiptPositions.Where(expression).ToListAsync();
}